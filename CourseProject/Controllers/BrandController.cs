using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;
using Repositories;
using DataAccess;
using CourseProject.Helpers;

namespace CourseProject.Controllers
{
    public class BrandController : Controller
    {
        public ActionResult Edit()
        {
            BrandRepository repo = new BrandRepository();

            BrandsViewModel model = new BrandsViewModel(repo.GetAll());
            return View(model);
        }

        [HttpGet]
        public ActionResult EditBrand(int id = 0)
        {
            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            BrandRepository repo = new BrandRepository();

            BrandsViewModel brand = new BrandsViewModel();

            Brand brandDb = repo.GetByID(id);

            if(brandDb != null)
            {
                brand = new BrandsViewModel(brandDb);
            }

            return View(brand);

        }

        [HttpPost]
        public ActionResult EditBrand(BrandsViewModel model)
        {

            BrandRepository repo = new BrandRepository();
            Brand brand = repo.GetByID(model.ID);
            if (brand == null) brand = new Brand();
            brand.Name = model.Name;
            brand.CountryOfOrigin = model.CountryOfOrigin;
            repo.Save(brand);
            return RedirectToAction("Edit");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            BrandRepository repo = new BrandRepository();

            if (repo.GetByID(id) != null)
            {
                CarsRepository carRepo = new CarsRepository();
                Brand brand = repo.GetByID(id);

                repo.DeleteByID(brand.ID);

                TempData["Message"] = "Successfully deleted brand!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such brand!";
            }
            return RedirectToAction("Edit");
        }


    }
}