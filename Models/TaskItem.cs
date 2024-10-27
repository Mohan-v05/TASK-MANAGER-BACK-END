using System.ComponentModel.DataAnnotations;

namespace Activity26.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public string Priority { get; set; }

        public User? User { get; set; }

        public int? UserId { get; set; }

        public ICollection<Checklist>? Checklist { get; set; }
 
    }
}
