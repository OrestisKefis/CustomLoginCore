using Microsoft.Extensions.Configuration;

namespace CustomLoginCore.Services
{
    public interface ITokenService
    {
        string GetToken();
    }
}
