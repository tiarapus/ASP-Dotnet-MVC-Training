using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using D1_Training.Models;

namespace D1_Training.Controllers;

public class MasterJAController : Controller{
    private readonly ILogger<MasterJAController> _logger;
    public MasterJAController(ILogger<MasterJAController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index([FromForm] string JA, string KA, string NA, string S)
    {
        Console.WriteLine("Jenis Angket: {0}",JA);
        Console.WriteLine("Kode Angket: {0}",KA);
        Console.WriteLine("Nama Angket: {0}",NA);
        Console.WriteLine("Singkatan: {0}",S);
        return RedirectToAction("Index");
    }
}