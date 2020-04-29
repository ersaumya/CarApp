using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGalleryApp.Models;
using CarGalleryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGalleryApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService _carService;
        public CarsController(CarService carService)
        {
            this._carService = carService;
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View(_carService.Get());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Create(car);
                    return RedirectToAction(nameof(Index));
                }
                return View(car);

            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            try
            {

                if (id != car.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _carService.Update(id, car);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(car);
                }


            }
            catch
            {
                return View(car);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}