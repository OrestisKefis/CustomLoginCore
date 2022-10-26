namespace CustomLoginCore.Services.TokenValidationService
{
    public interface ITokenValidationService
    {
        bool Validate(string givenToken);
    }
}
