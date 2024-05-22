using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using D1_Training.Models;

namespace D1_Training.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() //yang pertama kaku du run (running default)
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Form()
    {
        return View();
    }
    public IActionResult Table()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Form([FromForm] string nim, string nama)
    {
        Console.WriteLine("Nim: {0}",nim);
        Console.WriteLine("Nama: {0}",nama);
        return RedirectToAction("Form");
    }

    [HttpGet("Home/Table/{id}/{nama}")]
     public IActionResult Detail( string? id, string? nama) // string? : bisa null
    {
        Console.WriteLine("id: {0}",id);
        Console.WriteLine("Nama: {0}",nama);
        return RedirectToAction("Table");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
