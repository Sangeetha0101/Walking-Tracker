using System.ComponentModel.DataAnnotations;

namespace IndiaWalks.Models.DTO
{
    public class RegisterRequestDTO
    {       
        [Required]
        [DataType(DataType.EmailAddress)]
        public String User_Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password  { get; set; }
        public string[] Roles { get; set; }
    }
}
