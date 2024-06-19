using Microsoft.AspNetCore.Identity;

namespace Postman.API.Model.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser identityUser, List<string> roles);
    }
}
