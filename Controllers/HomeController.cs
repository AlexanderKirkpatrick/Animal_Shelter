using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Animal_Shelter.Models;

namespace Animal_Shelter.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
      
    }
}
