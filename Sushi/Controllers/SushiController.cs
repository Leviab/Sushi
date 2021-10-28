using Microsoft.AspNetCore.Mvc;
using Sushi.Data;
using Sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Controllers
{
    public class SushiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SushiController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public IActionResult Index()
        {
            List<SushiEntity> Sushies  = new List<SushiEntity>(_db.Sushi); 
            return View(Sushies);
        }
        [HttpGet]
        public IActionResult Index(string search)
        {
            List<SushiEntity> Sushies = null;
            if (search != null)
                Sushies = new List<SushiEntity>(_db.Sushi.Where(x => x.Name.Contains(search)));
            else
                Sushies  = new List<SushiEntity>(_db.Sushi);

            return View(Sushies);
           
        }
        //public IActionResult Index(string searchInfo)
        //{
        //    List<SushiEntity> Sushies = new List<SushiEntity>(_db.Sushi);
        //    return View(Sushies);
        //}

        public IActionResult Show(int Id)
        {
            SushiEntity Sushi = _db.Sushi.Find(Id);
            return View(Sushi);
        }
    }
}
