using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Interface;
using Core.ViewModel;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mardani.Controllers
{
    [Authorize]
    public class TestController : Controller
    {

        private IAdminRepository _admin;
        private IUserRepository _user;

        public TestController(IAdminRepository admin , IUserRepository user)
        {
            _admin = admin;
            _user = user;
        }


        [Route("/Test")]
        public IActionResult DoTest()
        {
            List<Degree> degrees = _admin.GetAllDegrees();
            List<SpentMoney> spentMoney = _admin.GetAllSpentMoney();
            //TestViewModel viewModel = new TestViewModel()
            //{
            //    Test=test,
            //    Degrees=degrees,
            //    SpentMoney=spentMoney
            //};
            ViewBag.Degree = new SelectList(degrees, "Id", "Name");
            ViewBag.Spent = new SelectList(spentMoney, "Id", "Money");
            ViewBag.LangId = new SelectList(_admin.GetAllLanguages(), "Id", "Name");
            

            return View();


            
        }

        [Route("/Test")]
        [HttpPost]
        public IActionResult DoTest(Test test)
        {
            int percent = 0;
            List<Country> countries = _admin.ReslutCountry(test.SpentMoneyId,test.DegreeId, test.LangId, test.Ielts,test.Visa);

            //_user.AddTest(test.SpentMoneyId, test.LangId, test.DegreeId, test.Ielts, test.Visa,test.UserId);
            Test doneTest = new Test()
            {
                SpentMoneyId=test.SpentMoneyId,
                DegreeId=test.DegreeId,
                Date=DateTime.Now,
                UserId= test.UserId,
                Visa=test.Visa,
                Ielts=test.Ielts,
                LangId=test.LangId

            };
            _user.AddTest(doneTest);
            //int userId= _user.GetUserIdByKeyName(User.Identity.Name);
           // Test tests = _user.GetTest(doneTest.Id);

            foreach(var item in countries)
            {
                CountryTest countryTest = new CountryTest();

                countryTest.CountryId = item.Id;
                countryTest.TestId = doneTest.Id;
                _user.AddTestCountry(countryTest);
            }
            
            return View("ResultTest",countries);
        }
    }
}
