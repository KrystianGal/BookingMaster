using BookingMaster.Application.Common.Interfaces;
using BookingMaster.Domain.Entities;
using BookingMaster.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookingMaster.Web.Controllers
{


    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;
        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
        }
        public IActionResult Index()
        {
            var villas = _villaRepo.GetAll();
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
                ModelState.AddModelError("name", "Nieprawidłowy opis.");
            }
            if (ModelState.IsValid)
            {
                _villaRepo.Add(obj);
                _villaRepo.Save();
                TempData["success"] = "Obiekt został utworzony prawidłowo";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _villaRepo.Get(u=>u.Id == villaId);
           // Villa? obj = _db.Villas.Find(villaId);

          //  var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);

            if(obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Update(Villa obj)
        {
           
            if (ModelState.IsValid && obj.Id>0)
            {
                _villaRepo.Update(obj);
                _villaRepo.Save();
                TempData["success"] = "Obiekt został edytowany prawidłowo";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepo.Get(u => u.Id == villaId);
           
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepo.Get(u => u.Id==obj.Id);
            if (objFromDb is not null)
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();
                TempData["success"] = "Obiekt został usunięty.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Obiekt nie może zostać usunięty.";
            return View();
        }

    }
}
