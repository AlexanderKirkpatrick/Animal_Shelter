using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Animal_Shelter.Controllers
{
  public class PhylumsController : Controller
  {
    private readonly Animal_ShelterContext _db;

    public PhylumsController(Animal_ShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Phylum> model = _db.Phylums.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Phylum phylum)
    {
      _db.Phylums.Add(phylum);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Phylum thisPhylum = _db.Phylums.FirstOrDefault(phylum => phylum.PhylumId == id);
      return View(thisPhylum);
    }
    public ActionResult Edit(int id)
    {
      var thisPhylum = _db.Phylums.FirstOrDefault(phylum => phylum.PhylumId == id);
      return View(thisPhylum);
    }

    [HttpPost]
    public ActionResult Edit(Phylum phylum)
    {
      _db.Entry(phylum).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPhylum = _db.Phylums.FirstOrDefault(phylum => phylum.PhylumId == id);
      return View(thisPhylum);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPhylum = _db.Phylums.FirstOrDefault(phylum => phylum.PhylumId == id);
      _db.Phylums.Remove(thisPhylum);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}