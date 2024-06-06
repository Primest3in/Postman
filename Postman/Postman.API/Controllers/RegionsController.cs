using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postman.API.Model.Domain;

namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET BY: api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Sylhet Region",
                    Code = "Syl",
                    RegionImgUrl = "https://www.tbsnews.net/sites/default/files/styles/amp_metadata_content_image_min_696px_wide/public/images/2022/01/28/sylhet_talha-chowdhury.jpg"

                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Dhaka Region",
                    Code = "Dhk",
                    RegionImgUrl = "https://www.gettyimages.com/photos/dhaka"
                }


            };

            return Ok(regions);
        }
    }
}
