using System.ComponentModel.DataAnnotations;
using TranVanLam.Models;

namespace TranVanLam.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        // Khóa ngoại liên kết với bảng User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
