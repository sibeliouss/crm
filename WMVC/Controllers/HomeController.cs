using Microsoft.AspNetCore.Mvc;

namespace WMVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}