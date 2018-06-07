using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using CourseProject.Models;
using DataAccess;
using CourseProject.Helpers;

namespace CourseProject.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Edit()
        {

            CarsRepository repo = new CarsRepository();

            CarViewModel model = new CarViewModel(repo.GetAll());

            return View(model);
        }

        [HttpGet]
        public ActionResult EditCar(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            BrandRepository brandRepo = new BrandRepository();

            List<Brand> brands = brandRepo.GetAll();
            Brand brand = new Brand();

            ViewBag.Brands = new SelectList(brands, "ID", "Name");

            CarsRepository carRepo = new CarsRepository();

            CarViewModel car;

            if(id != 0)
            {
                car = new CarViewModel(carRepo.GetByID(id));
            }
            else
            {
                car = new CarViewModel(new Car());
            }

            return View(car);
                   
        }

        [HttpPost]
        public ActionResult EditCar(CarViewModel viewModel)
        {
            if (LoginUserSession.Current.IsAuthenticated)
            {
                if (viewModel == null)
                {
                    TempData["Message"] = "No View Model";
                    return RedirectToAction("Edit");
                }

                CarsRepository repo = new CarsRepository();
                Car car = repo.GetByID(viewModel.ID);

                if (car == null)
                {
                    car = new Car();
                }

                car.Model = viewModel.Model;
                car.Brand = viewModel.Brand;
                car.Color = viewModel.Color;
                car.HP = viewModel.HP;

                repo.Save(car);

                TempData["Mesage"] = "Car was successfully saved!";
                return RedirectToAction("Edit");
            }


            TempData["ErrorMessage"] = "Please log in";
            return RedirectToAction("Login", "Login");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            CarsRepository repo = new CarsRepository();
            if (repo.GetByID(id) != null)
            {
                repo.DeleteByID(id);
                TempData["Message"] = "Successfully deleted car!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such car!";
            }
            return RedirectToAction("Edit");
        }


    }
}