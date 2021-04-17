using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mardani.Controllers
{
    public class HomeController : Controller
    {
        private IAdminRepository _admin;
        public HomeController(IAdminRepository admin)
        {
            _admin = admin;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public string Test()
        {
            return "Hello";
        }


        public IActionResult Country(int id)
        {
            Country country = _admin.GetCountry(id);


            ViewBag.LangLists = _admin.GetLangCountries(id);
            ViewBag.DegreeLists = _admin.GetDegreeCountries(id);


            return View(country);
        }

    }
}
