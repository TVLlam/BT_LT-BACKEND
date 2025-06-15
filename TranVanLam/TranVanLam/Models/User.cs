using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TranVanLam.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Navigation
        public ICollection<Comment>? Comments { get; set; }

        public class Comment
        {
        }
    }
}
