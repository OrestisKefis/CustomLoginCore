namespace CustomLoginCore.Services.TokenValidationService
{
    public class TokenValidationService : ITokenValidationService
    {
        ITokenService _tokenService;

        public TokenValidationService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public bool Validate(string givenToken)
        {
            return (_tokenService.GetToken() == givenToken) ? true : false;
        }
    }
}
