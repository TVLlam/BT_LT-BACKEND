using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [MaxLength(100)]
        [Required]
        public string GradeName { get; set; }
        public ICollection<Student> Students { get; set; } // Navigation - điều hướng đến danh sách Student
    }
}
