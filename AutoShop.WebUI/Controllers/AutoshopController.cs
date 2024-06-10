using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Autoshop.Domain;
using Autoshop.Infrastructure;

namespace Autoshop.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AutoshopController : Controller
    {
        private CarShopContext db = new CarShopContext();

        // GET: Autoshop
        public ActionResult Index()
        {
            return View();
        }

        // GET: Autoshop/Manufacturers
        public ActionResult Manufacturers()
        {
            var manufacturers = db.Manufacturers.ToList();
            return View(manufacturers);
        }

        // GET: Autoshop/ManufacturerDetails/5
        public ActionResult ManufacturerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Autoshop/CreateManufacturer
        public ActionResult CreateManufacturer()
        {
            return View();
        }

        // POST: Autoshop/CreateManufacturer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateManufacturer([Bind(Include = "ManufacturerId,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction("Manufacturers");
            }

            return View(manufacturer);
        }

        // GET: Autoshop/EditManufacturer/5
        public ActionResult EditManufacturer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Autoshop/EditManufacturer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManufacturer([Bind(Include = "ManufacturerId,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manufacturers");
            }
            return View(manufacturer);
        }

        // GET: Autoshop/DeleteManufacturer/5
        public ActionResult DeleteManufacturer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Autoshop/DeleteManufacturer/5
        [HttpPost, ActionName("DeleteManufacturer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteManufacturerConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();
            return RedirectToAction("Manufacturers");
        }

        // GET: Autoshop/Cars
        public ActionResult Cars()
        {
            var cars = db.Cars.Include("Manufacturer").ToList();
            return View(cars);
        }

        // GET: Autoshop/CarDetails/5
        public ActionResult CarDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Include("Manufacturer").FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Autoshop/CreateCar
        public ActionResult CreateCar()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            return View();
        }

        // POST: Autoshop/CreateCar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCar([Bind(Include = "CarId,Model,ManufacturerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Cars");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", car.ManufacturerId);
            return View(car);
        }

        // GET: Autoshop/EditCar/5
        public ActionResult EditCar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", car.ManufacturerId);
            return View(car);
        }

        // POST: Autoshop/EditCar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCar([Bind(Include = "CarId,Model,ManufacturerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Cars");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", car.ManufacturerId);
            return View(car);
        }

        // GET: Autoshop/DeleteCar/5
        public ActionResult DeleteCar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Autoshop/DeleteCar/5
        [HttpPost, ActionName("DeleteCar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCarConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Cars");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
