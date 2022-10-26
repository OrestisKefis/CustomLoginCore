using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomLoginCore.Pages
{
    [EnableCors("_myAllowSpecificOrigins")]
    [IgnoreAntiforgeryToken(Order = 1001)] //That is used to get post request through
    public class LoginModel : PageModel
    {
        public JsonResult OnGet(string username, string password)
        {
            return new JsonResult(new { result = (username == "username@qqq" && password == "password") ? true : false });
        }

        public JsonResult OnPost([FromBody]LoginData loginData)
        {
            return new JsonResult(new { result = (loginData.username == "username@qqq" && loginData.password == "password") ? true : false });
        }
    }

    public class LoginData
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
