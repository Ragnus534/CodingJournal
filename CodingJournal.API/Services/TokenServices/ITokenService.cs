using CodingJournal.API.Entities;

namespace CodingJournal.API.Services.TokenServices
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
