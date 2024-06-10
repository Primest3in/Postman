using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Postman.API.Model.Domain;
using Postman.API.Model.DTO;

namespace Postman.API.Model.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<UpdateRegionDTO?> UpdateAsync(Guid id, UpdateRegionDTO updateRegionDTO);
        Task<Region?> DeleteAsync(Guid id);
    }
}
