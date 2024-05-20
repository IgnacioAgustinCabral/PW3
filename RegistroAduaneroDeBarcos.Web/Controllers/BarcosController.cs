using Microsoft.AspNetCore.Mvc;
using RegistroAduaneroDeBarcos.Logica.Services;
using RegistroAduaneroDeBarcos.Web.Models;

namespace RegistroAduaneroDeBarcos.Web.Controllers;

public class BarcosController : Controller
{
    private readonly IBarcosService _barcosService;

    public BarcosController(IBarcosService barcosService)
    {
        _barcosService = barcosService;
    }

    public IActionResult RegistrarBarco()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrarBarco(BarcoModel barcoModel)
    {
        if(!ModelState.IsValid)
        {
            return View(barcoModel);
        }

        _barcosService.RegistrarBarco(barcoModel.MapToEntity());

        return RedirectToAction("ListarBarcos");
    }

    public IActionResult ListarBarcos()
    {
        var barcos = _barcosService.ListarBarcos();

        var barcosModelList = BarcoModel.MapToBarcoModelList(barcos);
        return View(barcosModelList);
    }
}

