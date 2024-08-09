using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}