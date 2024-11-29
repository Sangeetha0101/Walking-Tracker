using System.ComponentModel.DataAnnotations;

namespace IndiaWalks.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String UserName { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public String Password { get; set; }
        
    }
}
