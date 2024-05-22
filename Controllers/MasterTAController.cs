// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using D1_Training.Models;
// using D1_Training.Interfaces;
// using AutoMapper;
// using D1_Training.ViewModels.MasterTA;
// using Microsoft.Extensions.DependencyInjection;


// namespace D1_Training.Controllers;

// public class MasterTAController : Controller{
//     private readonly IMasterTARepository _master;
//     private readonly IMapper _mapper;


//     public MasterTAController(ILogger<MasterTAController> logger, IMasterTARepository master, IMapper mapper)
//     {
//         _master = master;
//         _mapper = mapper;
//     }
//     public async Task<IActionResult> Index()
//     {
//         var model = await _master.Get();
//         return View(model);
        
//     }
//     public  IActionResult Create()
//     {
//         var model = new MasterTAViewModel();
//         return View(model);
        
//     }


  
    
// }

using Microsoft.AspNetCore.Mvc;
using D1_Training.Interfaces;
using D1_Training.Models;
using D1_Training.ViewModels.MasterTA;
using AutoMapper;

namespace D1_Training.Controllers;

public class MasterTAController : Controller {
    private readonly IMasterTARepository _master;
    private readonly IMapper _mapper;
    private readonly ILogger<MasterTAController> _logger;
    public MasterTAController(ILogger<MasterTAController> logger, IMasterTARepository master, IMapper mapper)
    {
        _logger = logger;
        _master = master;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _master.Get();
        return View(model);
        
    }
    public  IActionResult Create()
    {
        var model = new MasterTAViewModel();
        return View(model);
        
    }
    [HttpPost]
    public async Task<IActionResult> Create(MasterTAViewModel model )
    {
        if(!ModelState.IsValid) return View(model);
    
        var mhs = _mapper.Map<MasterTA>(model);
    
        try
        {
            await _master.Insert(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil ditambahkan</div>" ;
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal menambahkan data. Error: " + e.Message + "</div>" + e.Message;
            return RedirectToAction("Create");
        }
    }

    public async Task<IActionResult> Update(long Id)
    {
        var mhs = await _master.GetById(Id);
        var model = _mapper.Map<MasterTAViewModel>(mhs);
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Update(MasterTAViewModel model )
    {
        var mhs = _mapper.Map<MasterTA>(model);
        try
        {
            await _master.Update(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil diupdate</div>" ;
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal mengupdate data. Error: " + e.Message + "</div>";
            return RedirectToAction("Update");
        }
       
    }
    
    public async Task<IActionResult> Delete(long Id)
    {
        var mhs = await _master.GetById(Id);
        var model = _mapper.Map<MasterTAViewModel>(mhs);
        return View(model);
    }

    [HttpPost]
     public async Task<IActionResult> Delete(MasterTAViewModel model )
    {
        var mhs = _mapper.Map<MasterTA>(model);
        try
        {
            await _master.Delete(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil dihapus</div>" ;
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal menghaous data. Error: " + e.Message + "</div>";
            return RedirectToAction("Delete");
        }
       
    }

    // public async Task<IActionResult> Delete(long Id, MasterTAViewModel model)
    // {
    //     var mhs = _mapper.Map<MasterTA>(model);
    //     mhs.Id = Id;
    //     try
    //     {
    //         await _master.Delete(mhs);
    //         TempData["message"] = "Berhasil";
    //         return RedirectToAction("Index");
    //     }
    //     catch (Exception e)
    //     {
    //         TempData["message"] = "Gagal Menghapus data. Error: " + e.Message;
    //         return RedirectToAction("Index");
    //     }
    // }


}
    

   



        

    


  

