using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.UI.Controllers;

[Authorize]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}