using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public static CarPark carPark = new();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCars()
        {
            return View(carPark.Cars);
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            carPark.AddCar(car);
            return RedirectToAction("GetCars", carPark.Cars);
        }
        public IActionResult EditCar(int id)
        {
            return View(carPark.Cars.Find(car => car.Id == id));
        }
        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            var exsistCar = carPark.Cars.Find(x => x.Id == car.Id);
            exsistCar.Price = car.Price;
            exsistCar.Name = car.Name;
            exsistCar.Color = car.Color;
            return RedirectToAction("GetCars", carPark.Cars);
        }
        [HttpPost]
        public IActionResult RemoveCar(int id)
        {
            carPark.RemoveCar(id);
            return RedirectToAction("GetCars", carPark.Cars);
        }
        [HttpGet]
        public IActionResult RemoveCarView(int id)
        {
            return View("RemoveCar",carPark.Cars.Find(car => car.Id == id));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}