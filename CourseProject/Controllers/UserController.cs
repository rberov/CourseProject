using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Repositories;

namespace CourseProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserCount()
        {
            UserRepository repo = new UserRepository();

            int count = repo.GetAll().Count;

            TempData["Count"] = count;
            return View();
        }
    }
}