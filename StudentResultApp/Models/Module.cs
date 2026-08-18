using System.ComponentModel.DataAnnotations;

namespace StudentResultApp.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Module code is required.")]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Module name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(2020, 2100)]
        public int AcademicYear { get; set; } = 2026;

        [Range(0, 10000)]
        public int StudentCount { get; set; }

        [Required]
        public string Status { get; set; } = "Active";
    }
}