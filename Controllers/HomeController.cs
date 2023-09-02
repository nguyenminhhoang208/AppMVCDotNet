using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Controller_View.Models;

namespace Controller_View.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // this.HtmlContext
        // this.Request
        // this.Response
        // this.ViewData
        // this.ViewBag
        // this.TempData
        // this.Url
        // this.RouteData
        // this.User
        // this.ModelState

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
