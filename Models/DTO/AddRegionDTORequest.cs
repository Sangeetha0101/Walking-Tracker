using System.ComponentModel.DataAnnotations;

namespace IndiaWalks.Models.DTO
{
    public class AddRegionDTORequest
    {
        [MinLength(2,ErrorMessage="Name Has to be a minimum of 2 character and maximum of 25")] 
        [MaxLength(25, ErrorMessage = "Name Has to be a minimum of 2 character and maximum of 25")]
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
