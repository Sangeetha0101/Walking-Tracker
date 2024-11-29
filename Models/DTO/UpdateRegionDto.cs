using System.ComponentModel.DataAnnotations;

namespace IndiaWalks.Models.DTO
{
    public class UpdateRegionDto
    {
        [MinLength(2, ErrorMessage = "Name Has to be a minimum of 2 character and maximum of 25")]
        [MaxLength(25, ErrorMessage = "Name Has to be a minimum of 2 character and maximum of 25")]
        public required string Name { get; set; }
       
        [MaxLength(30, ErrorMessage = "Name Has to be a minimum of 3 character and maximum of 30 ")]
        public required string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    
}
}
