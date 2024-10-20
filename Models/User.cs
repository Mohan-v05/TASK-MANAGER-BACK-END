using System.ComponentModel.DataAnnotations;

namespace Activity26.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}
