using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private SignInManager<IdentityUser> signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
      this.signInManager = signInManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null)
    {
      var provider = "Google";
      var redirectUrl = Url.Action("LoginCallback", "Account", new { ReturnUrl = returnUrl });
      var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
      return new ChallengeResult(provider, properties);
    }

    [AllowAnonymous]
    public async Task<IActionResult> LoginCallback(string returnUrl = null, string remoteError = null)
    {
      if (remoteError != null)
      {
        return Content("Authentication failed. Details: " + remoteError);
      }

      var info = await signInManager.GetExternalLoginInfoAsync();
      if (info == null)
      {
        return Content("Error loading external login info.");
      }


      var claims = string.Join("\n", from claim in info.Principal.Claims select $"{claim.Type}: {claim.Value}");
      return Content($"User info:\n{claims}");
    }
  }
}
