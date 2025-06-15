using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
  
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        [Required]
        public string StudentName { get; set; }
        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public Grade? Grade { get; set; } // Navigation - điều hướng đến Grade
    }
}
