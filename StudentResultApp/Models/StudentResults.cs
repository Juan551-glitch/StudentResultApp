namespace StudentResultApp.Models
{
    public class StudentResults
    {
        public int Id { get; set; }
        // ADD A LINE

        public string StudentNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Module { get; set; } = string.Empty;

        public double Mark { get; set; }

        public string GetResult()
        {
            return Mark >= 50 ? "Pass" : "Fail";
        }
    }
}
