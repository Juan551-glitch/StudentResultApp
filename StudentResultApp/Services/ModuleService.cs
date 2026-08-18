using StudentResultApp.Models;

namespace StudentResultApp.Services
{
    public class ModuleService
    {
        private readonly List<Module> _modules = new()
        {
            new Module
            {
                Id = 1,
                Code = "MDB622",
                Name = "Database Manipulation",
                AcademicYear = 2026,
                StudentCount = 14,
                Status = "Active"
            },

            new Module
            {
                Id = 2,
                Code = "AZ400",
                Name = "Designing and Implementing Microsoft DevOps Solutions",
                AcademicYear = 2026,
                StudentCount = 14,
                Status = "Active"
            },

            new Module
            {
                Id = 3,
                Code = "SDT621",
                Name = "Software Development",
                AcademicYear = 2026,
                StudentCount = 12,
                Status = "Active"
            },

            new Module
            {
                Id = 4,
                Code = "DAG511",
                Name = "Data Analytics",
                AcademicYear = 2026,
                StudentCount = 10,
                Status = "Inactive"
            }
        };

        public List<Module> GetAll()
        {
            return _modules
                .OrderBy(m => m.Code)
                .ToList();
        }

        public Module? GetById(int id)
        {
            return _modules.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Module module)
        {
            module.Id = _modules.Count == 0
                ? 1
                : _modules.Max(m => m.Id) + 1;

            _modules.Add(module);
        }

        public void Update(Module updatedModule)
        {
            var existingModule =
                _modules.FirstOrDefault(m => m.Id == updatedModule.Id);

            if (existingModule == null)
                return;

            existingModule.Code = updatedModule.Code;
            existingModule.Name = updatedModule.Name;
            existingModule.AcademicYear = updatedModule.AcademicYear;
            existingModule.StudentCount = updatedModule.StudentCount;
            existingModule.Status = updatedModule.Status;
        }

        public void Delete(int id)
        {
            var module = _modules.FirstOrDefault(m => m.Id == id);

            if (module != null)
            {
                _modules.Remove(module);
            }
        }
    }
}