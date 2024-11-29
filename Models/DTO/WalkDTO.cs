using IndiaWalks.Models.Domain;

namespace IndiaWalks.Models.DTO
{
    public class WalkDTO
    {
        public Guid ID { get; set; }
        public  String Name { get; set; }
        public String? Description { get; set; }
        public Double LengthInKM { get; set; }
        public String? WalkImageUrl { get; set; }
      
        public required RegionDTO Region { get; set; }
        public required DifficultyDTO Difficulty { get; set; }
}
}
