using CustomLoginCore.Services.TokenValidationService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace CustomLoginCore.Pages
{
    [EnableCors("_myAllowSpecificOrigins")]
    [IgnoreAntiforgeryToken(Order = 1001)] //That is used to get post request through
    public class LoginModel : PageModel
    {
        ITokenValidationService _tokenValidationService;

        public LoginModel(ITokenValidationService tokenValidationService)
        {
            _tokenValidationService = tokenValidationService;
        }

        public JsonResult OnGet(string username, string password)
        {
            return new JsonResult(new { result = (username == "username@qqq" && password == "password") ? true : false });
        }

        public JsonResult OnPost([FromBody]LoginData loginData)
        {
            StringValues returnedToken = "";
            Request.Headers.TryGetValue("X-XSRF-TOKEN", out returnedToken);

            if (!(_tokenValidationService.Validate(returnedToken)))
            {
                return new JsonResult(new { });
            }

            return new JsonResult(new { result = (loginData.username == "username@qqq" && loginData.password == "password") ? true : false });
        }
    }

    public class LoginData
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
