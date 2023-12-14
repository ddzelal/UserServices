using System.ComponentModel.DataAnnotations.Schema;

namespace UserRepository.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("AuthorId")]
        public User Author { get; set; } = null!;
        public int AuthorId { get; set; }

    }
}