using Microsoft.EntityFrameworkCore; // needed so we can use ToListAsync(), FindAsync(), etc.
using StudentResultApp.Data; // this gives us access to AppDbContext (the database connection)
using StudentResultApp.Models;

namespace StudentResultApp.Services
{
    public class ModuleService
    {
        // This is the database connection. It gets "injected" (given to us)
        // automatically because we registered AppDbContext in Program.cs.
        private readonly AppDbContext _db;

        // The constructor now asks for the database connection instead of
        // building a fake in-memory list.
        public ModuleService(AppDbContext db)
        {
            _db = db;
        }

        // Reads all modules from the real database table, sorted by Code.
        // "async Task<...>" + "await" means: go talk to the database, and
        // don't block the app while waiting for the answer.
        public async Task<List<Module>> GetAllAsync()
        {
            return await _db.Modules
                .OrderBy(m => m.Code)
                .ToListAsync();
        }

        // Finds one module by its Id directly in the database.
        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _db.Modules.FindAsync(id);
        }

        // Adds a new module row to the database.
        public async Task AddAsync(Module module)
        {
            _db.Modules.Add(module); // stage the new row
            await _db.SaveChangesAsync(); // actually save it to the database
        }

        // Updates an existing module row in the database.
        public async Task UpdateAsync(Module updatedModule)
        {
            var existingModule = await _db.Modules.FindAsync(updatedModule.Id);

            if (existingModule == null)
                return;

            // Copy the new values onto the row EF Core is already tracking.
            existingModule.Code = updatedModule.Code;
            existingModule.Name = updatedModule.Name;
            existingModule.AcademicYear = updatedModule.AcademicYear;
            existingModule.StudentCount = updatedModule.StudentCount;
            existingModule.Status = updatedModule.Status;

            await _db.SaveChangesAsync(); // save the changes to the database
        }

        // Deletes a module row from the database.
        public async Task DeleteAsync(int id)
        {
            var module = await _db.Modules.FindAsync(id);

            if (module != null)
            {
                _db.Modules.Remove(module); // stage the delete
                await _db.SaveChangesAsync(); // actually delete it from the database
            }
        }
    }
}
