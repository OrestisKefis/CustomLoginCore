using Microsoft.Extensions.Configuration;

namespace CustomLoginCore.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken()
        {
            string test = _configuration["Token:"];
            return test;
        }
    }
}
