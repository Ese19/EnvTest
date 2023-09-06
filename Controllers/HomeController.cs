using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnvTest.Models;

namespace EnvTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(Phrase phrase)
    {
        var word = Environment.GetEnvironmentVariable("MY_VAR");
        if(word != null)
        {
            phrase.MyVar = word;
        }
        return View(phrase);
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
