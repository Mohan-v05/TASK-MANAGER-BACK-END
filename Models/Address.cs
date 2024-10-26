using System.ComponentModel.DataAnnotations;

namespace Activity26.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string firstLine { get; set; }

        public string secondLine { get; set; }

        public string city { get; set; }
        
        public User? user { get; set; }

        public int? userId { get; set; }
    }
}
