﻿using Postman.API.Model.Domain;

namespace Postman.API.Model.DTO
{
    public class AddWalkDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImgUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        
    }
}
