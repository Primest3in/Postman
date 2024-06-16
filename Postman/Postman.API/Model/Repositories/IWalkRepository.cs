using Microsoft.AspNetCore.Mvc;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;

namespace Postman.API.Model.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy = null, [FromQuery] bool isAscending = true);
        Task<Walk> GetByIdAsync(Guid id);
        Task<UpdateWalkDTO> UpdateAsync(Guid id, UpdateWalkDTO updateWalkDTO);
        Task<Walk> DeleteAsync(Guid id);
    }
}
