using Microsoft.AspNetCore.Mvc;
using Task4.Service.DTOs;
using Task4.Service.IServices;
using Task4.Service.ViewModels;

public class AccountController : Controller
{
    private IUserService userService;
    private IConfiguration configuration;
    private IAuthenticationService authenticationService;

    public AccountController(IAuthenticationService authenticationService, IUserService userService, IConfiguration configuration)
    {
        this.userService = userService;
        this.configuration = configuration;
        this.authenticationService = authenticationService;
    }

    // GET: Registration
    public ActionResult Registration(UserCreationDto creationDto)
    {
        return View("Registration", creationDto);
    }

    // POST: Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(UserCreationDto creationDto)
    {
        if (ModelState.IsValid)
        {
            var createdUser = await this.userService.AddAsync(creationDto);

            if (createdUser is null)
            {
                ModelState.AddModelError("error", "This email is already used.");
                return Registration(creationDto);
            }

            return RedirectToAction("Login");
        }

        return Registration(creationDto);
    }

    // GET: Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(UserLoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            string token = await this.authenticationService.AuthenticateAsync(model);

            if (token is null)
            {
                ModelState.AddModelError("error", "Invalid password or email.");
                return View(model);
            }
            else if (token == "b")
            {
                ModelState.AddModelError("error", "Your account was blocked!");
                return View(model);
            }

            Response.Cookies.Append("Token", token);

            return RedirectToAction("Index", "UserManagement");
        }

        return View(model);
    }
}
