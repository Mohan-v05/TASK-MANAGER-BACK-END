using System.ComponentModel.DataAnnotations;

namespace Activity26.Models
{
    public class UserRegisterReq
    {
        [Required]
       
        public string name { get; set; }
        public string phone { get; set; }
        [Required]
        public string email { get; set; }

        public Address? Address { get; set; }

        public string password { get; set; }

        public Role role { get; set; }
    }
}
