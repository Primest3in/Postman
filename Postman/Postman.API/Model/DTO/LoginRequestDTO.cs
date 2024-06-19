using System.ComponentModel.DataAnnotations;

namespace Postman.API.Model.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
