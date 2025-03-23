using Microsoft.AspNetCore.Mvc;

namespace WhiteLagoon.Web.Controllers;

public class VillaController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}