using Postman.API.Model.Domain;

namespace Postman.API.Model.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImgUrl { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public RegionDTO Region { get; set; }
    }
}
