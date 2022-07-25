using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Animal_Shelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly Animal_ShelterContext _db;

    public AnimalsController(Animal_ShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.Include(animal => animal.Phylum).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PhylumId = new SelectList(_db.Phylums, "PhylumId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Edit(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      ViewBag.PhylumId = new SelectList(_db.Phylums, "PhylumId", "Name");
      return View(thisAnimal);
    }

    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}