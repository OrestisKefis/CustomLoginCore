using CustomLoginCore.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CustomLoginCore.Pages
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class TokenModel : PageModel
    {
        ITokenService _tokenService;

        public TokenModel(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public JsonResult OnGet()
        {
            string token = _tokenService.GetToken();
            ViewData["token"] = token;
            return new JsonResult(token);
        }
    }
}
