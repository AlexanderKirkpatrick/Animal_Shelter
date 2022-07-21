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
      List<Animal> model = _db.Animals.ToList();
      return View(model);
    }
  }
}