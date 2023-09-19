using LoveChat.Domain.Entities.Users;

namespace LoveChat.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);

}
