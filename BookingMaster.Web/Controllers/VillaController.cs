﻿using BookingMaster.Domain.Entities;
using BookingMaster.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookingMaster.Web.Controllers
{


    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The descriptiob cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u=>u.Id == villaId);
           // Villa? obj = _db.Villas.Find(villaId);

          //  var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);

            if(obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }

    }
}
