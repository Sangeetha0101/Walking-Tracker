namespace IndiaWalks.Models.Domain
{
    public class Walk
    {

        public Guid ID { get; set; }
        public  String Name { get; set; }
        public String? Description { get; set; }
        public Double LengthInKM { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid RegionID { get; set; }
        public Guid DifficultyID { get; set; }



        public required Region Region { get; set; }
        public required Difficulty Difficulty { get; set; }
    }
}
