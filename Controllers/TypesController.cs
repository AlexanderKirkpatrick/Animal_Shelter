using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Animal_Shelter.Controllers
{
  public class TypesController : Controller
  {
    private readonly Animal_ShelterContext _db;

    public TypesController(Animal_ShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Type> model = _db.Types.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Type type)
    {
      _db.Types.Add(type);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Type thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      return View(thisType);
    }
    public ActionResult Edit(int id)
    {
      var thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(Type type)
    {
      _db.Entry(type).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      return View(thisType);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisType = _db.Types.FirstOrDefault(type => type.TypeId == id);
      _db.Types.Remove(thisType);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}