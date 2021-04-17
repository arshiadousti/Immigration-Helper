using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Classes;
using Core.Interface;
using Core.ViewModel;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mardani.Controllers
{
    [RoleAttribue(3)]
    public class AdminController : Controller
    {
        
        private IAdminRepository _admin;
        public AdminController(IAdminRepository admin)
        {
            _admin = admin;
        }


        public IActionResult Index()
        {
            return View();
        }


        #region Permission

        public IActionResult PermissionList()
        {
            List<Permission> permissions = _admin.GetAllPermissions();
            return View(permissions);
        }


        public IActionResult AddPermission()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddPermission(PermissionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Permission permission = new Permission()
                {
                    Name = viewModel.Name
                };
                _admin.AddPermission(permission);
                return RedirectToAction(nameof(PermissionList));
            }
            return View(viewModel);
        }


        public IActionResult EditPermission(int id)
        {
            Permission permission = _admin.GetPermission(id);

            PermissionViewModel viewModel = new PermissionViewModel()
            {
                Name = permission.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPermission(int id, PermissionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.EditPermission(id, viewModel.Name);

                return RedirectToAction(nameof(PermissionList));
            }
            return View(viewModel);
        }

        public void DeletePermission(int id)
        {
            _admin.DeletePermission(id);
        }


        #endregion

        #region Role

        public IActionResult RoleList()
        {
            List<Role> roles = _admin.GetAllRoles();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddRole(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                Role role = new Role()
                {
                    Name = viewModel.Name
                };
                _admin.AddRole(role);
                return RedirectToAction(nameof(RoleList));

            }
            return View(viewModel);
        }

        public IActionResult EditRole(int id)
        {
            Role role = _admin.GetRole(id);
            RoleViewModel viewModel = new RoleViewModel()
            {
                Name = role.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditRole(int id,RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                _admin.EditRole(id, viewModel.Name);
                return RedirectToAction(nameof(RoleList));

            }
            return View(viewModel);
        }

        public void DeleteRole(int id)
        {
            _admin.DeleteRole(id);
        }


        #endregion

        #region RolePermission

        public IActionResult ManageRolePermission(int id)
        {
            List<Permission> permissions = _admin.GetAllPermissions();
            ViewBag.RoleID = id;
            return View(permissions);
        }

        [HttpPost]
        public IActionResult ManageRolePermission(int id , List<int> rolepermissions)
        {
            _admin.DeleteAllRolePermission(id);
            foreach(int item in rolepermissions)
            {
                RolePermission rolePermission = new RolePermission()
                {
                    RoleId=id,
                    PermissionId=item
                };
                _admin.AddRolePermission(rolePermission);
            }

            return RedirectToAction(nameof(RoleList));
        }


        #endregion

        #region Degree

        public IActionResult DegreeList()
        {
            List<Degree> degrees = _admin.GetAllDegrees();
            return View(degrees);
        }


        public IActionResult AddDegree()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddDegree(DegreeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Degree degree = new Degree()
                {
                    Name=viewModel.Name
                };
                _admin.AddDegree(degree);
                return RedirectToAction(nameof(DegreeList));

            }
            return View(viewModel);
        }



        public IActionResult EditDegree(int id)
        {
            Degree degree = _admin.GetDegree(id);
            DegreeViewModel viewModel = new DegreeViewModel()
            {
                Name=degree.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditDegree(int id,DegreeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.EditDegree(id, viewModel.Name);
                return RedirectToAction(nameof(DegreeList));

            }
            return View(viewModel);
        }


        public void DeleteDegree(int id)
        {
            _admin.DeleteDegree(id);
        }

        #endregion


        #region SpentMoney
        [RoleAttribue(9)]
        public IActionResult SpentMoneyList()
        {
            List<SpentMoney> spentMoney = _admin.GetAllSpentMoney();
            return View(spentMoney);
        }

        public IActionResult AddSpentMoney()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpentMoney(SpentMoneyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SpentMoney spentMoney = new SpentMoney()
                {
                    Money=viewModel.Money
                };
                _admin.AddSpentMoney(spentMoney);
                return RedirectToAction(nameof(SpentMoneyList));
            }
            return View(viewModel);
        }


        public IActionResult EditSpentMoney(int id)
        {
            SpentMoney spentMoney = _admin.GetSpent(id);
            SpentMoneyViewModel viewModel = new SpentMoneyViewModel()
            {
                Money=spentMoney.Money
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditSpentMoney(int id,SpentMoneyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.EditSpentMoney(id, viewModel.Money);
                return RedirectToAction(nameof(SpentMoneyList));
            }
            return View(viewModel);
        }

        public void DeleteSpentMoney(int id)
        {
            _admin.DeleteSpentMoney(id);
        }


        #endregion

        #region Country

        public IActionResult CountryList()
        {
            ViewBag.LangList = _admin.GetAllLanguages();
            return View(_admin.GetAllCountries());
        }

        public IActionResult AddCountry()
        {
            ViewBag.DegreeId= _admin.GetAllDegrees();
            List<Language> languages = _admin.GetAllLanguages();
            List<SpentMoney> spentMoney = _admin.GetAllSpentMoney();

           // ViewBag.DegreeId = new SelectList(degrees, "Id", "Name");
            ViewBag.LangId = new SelectList(languages, "Id", "Name");
            ViewBag.BudgetId = new SelectList(spentMoney, "Id", "Money");


            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(CounrtyViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                if (viewModel.Image!=null)
                {
                    viewModel.ImageName = CodeGenerators.FileCode() + Path.GetExtension(viewModel.Image.FileName);
                    string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Country/", viewModel.ImageName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        viewModel.Image.CopyTo(stream);
                    }
                    Country country = new Country()
                    {
                        BudgetId = viewModel.BudgetId,
                        //DegreeId = viewModel.DegreeId,
                        //LangId = viewModel.LangId,
                        Image = viewModel.ImageName,
                        Visa = viewModel.Visa,
                        Description = viewModel.Description,
                        Ielts = viewModel.Ielts,
                        Name = viewModel.Name
                    };
                    _admin.AddCountry(country);
                    int countryid = country.Id;
                    ViewBag.CountryID = countryid;
                    
                    return RedirectToAction(nameof(CountryList));
                }
                else
                {
                    ModelState.AddModelError("Image", "لطفا تصویر را وارد کنید");
                   

                    //ViewBag.DegreeId = new SelectList(_admin.GetAllDegrees(), "Id", "Name", ViewBag.Country1);
                    ViewBag.LangId = new SelectList(_admin.GetAllLanguages(), "Id", "Name", ViewBag.Country1);
                    ViewBag.BudgetId = new SelectList(_admin.GetAllSpentMoney(), "Id", "Money", ViewBag.Country1);
                }

            }
            

           // ViewBag.DegreeId = new SelectList(_admin.GetAllDegrees(), "Id", "Name", ViewBag.Country1);
            ViewBag.LangId = new SelectList(_admin.GetAllLanguages(), "Id", "Name", ViewBag.Country1);
            ViewBag.BudgetId = new SelectList(_admin.GetAllSpentMoney(), "Id", "Money", ViewBag.Country1);
            return View(viewModel);
        }


        public IActionResult EditCountry(int id)
        {
            Country country = _admin.GetCountry(id);
            CounrtyViewModel viewModel = new CounrtyViewModel()
            {
                BudgetId = country.BudgetId,
                //DegreeId= country.BudgetId,
                //LangId=country.LangId,
                Description=country.Description,
                Ielts=country.Ielts,
                ImageName=country.Image,
                Name=country.Name,
                Visa=country.Visa,
            };

            //List<Degree> degrees = _admin.GetAllDegrees();
            List<Language> languages = _admin.GetAllLanguages();
            List<SpentMoney> spentMoney = _admin.GetAllSpentMoney();

            //ViewBag.DegreeId = new SelectList(degrees, "Id", "Name",1);
           // ViewBag.LangId = new SelectList(languages, "Id", "Name",country.LangId);
            ViewBag.BudgetId = new SelectList(spentMoney, "Id", "Money",country.BudgetId);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditCountry(int id,CounrtyViewModel viewModel)
        {
            Country country = _admin.GetCountry(id);
            if (ModelState.IsValid)
            {
                if (viewModel.Image != null)
                {
                    viewModel.ImageName = CodeGenerators.FileCode() + Path.GetExtension(viewModel.Image.FileName);
                    string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Country/", viewModel.ImageName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        viewModel.Image.CopyTo(stream);
                    }
                    _admin.EditCountry(id, viewModel.BudgetId, viewModel.LangId, viewModel.Name, 
                        viewModel.ImageName, viewModel.Visa, viewModel.Description, viewModel.Ielts);
                    return RedirectToAction(nameof(CountryList));

                }
                else
                {
                    
                    _admin.EditCountry(id, viewModel.BudgetId,  viewModel.LangId, viewModel.Name,
                        country.Image, viewModel.Visa, viewModel.Description, viewModel.Ielts);
                    return RedirectToAction(nameof(CountryList));
                }

            }
           // List<Degree> degrees = _admin.GetAllDegrees();
            List<Language> languages = _admin.GetAllLanguages();
            List<SpentMoney> spentMoney = _admin.GetAllSpentMoney();

            //ViewBag.DegreeId = new SelectList(degrees, "Id", "Name", 1);
            //ViewBag.LangId = new SelectList(languages, "Id", "Name", country.LangId);
            ViewBag.BudgetId = new SelectList(spentMoney, "Id", "Money", country.BudgetId);
            return View(viewModel);
        }

        public void DeleteCountry(int id)
        {
            _admin.DeleteCountry(id);
        }



        public IActionResult ManageDegreeCountry(int id)
        {
            ViewBag.CountryID = id;

            return View(_admin.GetAllDegrees());
        }

        [HttpPost]
        public IActionResult ManageDegreeCountry(int id , List<int> degreecountry)
        {
            _admin.DeleteAllDegreeCountry(id);

            foreach (var item in degreecountry)
            {
                DegreeCountry degreeCountry = new DegreeCountry()
                {
                    DegreeId=item,
                    CountryId=id
                };
                _admin.AddDegreeCounrty(degreeCountry);
                
            }
            return RedirectToAction(nameof(CountryList));
        }


        public IActionResult ManageLangCountry(int id)
        {
            ViewBag.CountryID = id;
            
            return View(_admin.GetAllLanguages());
        }

        [HttpPost]
        public IActionResult ManageLangCountry(int id,List<int> Languagecountry)
        {
            //ViewBag.CountryID = id;

            _admin.DeleteAllLangCountry(id);

            foreach (var item in Languagecountry)
            {
                LangCountry langCountry = new LangCountry()
                {
                    CountryId = id,
                    LangId = item
                };
                _admin.AddLangCountry(langCountry);
               
            }

            return RedirectToAction(nameof(CountryList));
        }

        #endregion


    }
}
