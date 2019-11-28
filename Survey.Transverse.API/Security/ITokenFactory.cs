using Microsoft.IdentityModel.Tokens;

namespace Survey.API.Security
{
    public interface ITokenFactory
    {
        string createToken(string userId, out SecurityToken securityToken);
    }
}
