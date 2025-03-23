using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers;

public class VillaController : Controller
{
    private readonly ApplicationDbContext _db;
    public VillaController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        var villas = _db.Villas.OrderBy(v => v.Id).ToList();
        return View(villas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Villa villa)
    {
        if (villa.Name == villa.Description)
        {
                ModelState.AddModelError("", "Villa name can not match description.");
        }
        if (ModelState.IsValid)
        {
            _db.Villas.Add(villa);
            _db.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
        
    }
      
    public IActionResult Edit(int id)
    {
        Villa? villa = _db.Villas.Single(v => v.Id == id);
        if (villa==null)
        {
            return NotFound();
        }
        return View(villa);
    }
}