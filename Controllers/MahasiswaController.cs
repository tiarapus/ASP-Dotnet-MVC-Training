using Microsoft.AspNetCore.Mvc;
using D1_Training.Interfaces;
using D1_Training.Models;
using D1_Training.ViewModels.Mahasiswa;
using AutoMapper;

namespace D1_Training.Controllers;

public class MahasiswaController : Controller {
    private readonly IMahasiswaRepository _mahasiswa;
    private readonly IMapper _mapper;
    private readonly ILogger<MahasiswaController> _logger;
    public MahasiswaController(ILogger<MahasiswaController> logger, IMahasiswaRepository mahasiswa, IMapper mapper)
    {
        _logger = logger;
        _mahasiswa = mahasiswa;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        //IEnumerable<Mahasiswa> data = (IEnumerable<Mahasiswa>)_mahasiswa.Get();
        
        var model = await _mahasiswa.Get();
        return View(model);
    }
    public IActionResult Create()
    {
        var model = new CreateMahasiswaViewModel();
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateMahasiswaViewModel model )
    {
         


        if(!ModelState.IsValid) return View(model);
        // var mhs = new Mahasiswa
        // {
        //     Nim = model.Nim,
        //     Nama = model.Nama,
        //     Prodi = model.Prodi,
        //     Fakultas = model.Fakultas,
        //     Alamat = model.Alamat,
        //     Agama = model.Agama,
        //     Gender = model.Gender,
        //     CreatedAt = ow,
        //     UpdatedAt = DateTime.Now,
        // };
        var mhs = _mapper.Map<Mahasiswa>(model);
        
        try
        {
            await _mahasiswa.Insert(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil ditambahkan</div>" ;
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal menambahkan data. Error: " + e.Message + "</div>";
            return RedirectToAction("Create");
        }

    }
    
    
  
    public async Task<IActionResult> Update(long Id)
    {
        var mhs = await _mahasiswa.GetById(Id);
        var model = _mapper.Map<MahasiswaViewModel>(mhs);
        return View(model);
    }
     
    [HttpPost]
    public async Task<IActionResult> Update(MahasiswaViewModel model )
    {
        var mhs = _mapper.Map<Mahasiswa>(model);
        try
        {
            await _mahasiswa.Update(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil diupdate</div>" ;
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal mengupdate data. Error: " + e.Message + "</div>";
            return RedirectToAction("Update", new{id = model.Id});
        }
       
    }

    public async Task<IActionResult> Delete(long Id, MahasiswaViewModel model)
    {
        var mhs = _mapper.Map<Mahasiswa>(model);
        mhs.Id = Id;
        try
        {
            await _mahasiswa.SoftDelete(mhs);
            TempData["message"] = "<div class='alert alert-info mb-3'>Data berhasil dihapus</div>";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["message"] = "<div class='alert alert-danger mb-3'>Gagal menghapus data. Error: " + e.Message + "</div>";
            return RedirectToAction("Index");
        }
    }
  
}
