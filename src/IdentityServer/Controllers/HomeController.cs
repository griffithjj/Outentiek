using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

[Route("/")]
public class HomeController : Controller
{
    [HttpGet]
    // GET
    public IActionResult Index()
    {
        return View();
    }
}