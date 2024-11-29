namespace IndiaWalks.Models.DTO
{
    public class AddWalkDTORequest
    {
        public required String Name { get; set; }
        public String? Description { get; set; }
        public Double LengthInKM { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid RegionID { get; set; }
        public Guid DifficultyID { get; set; }

    }
}
