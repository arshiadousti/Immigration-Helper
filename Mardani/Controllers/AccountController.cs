using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using Core.Interface;
using Core.Classes;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Mardani.Controllers
{
    
    public class AccountController : Controller
    {
        private IUserRepository _user;
        private IViewRenderService _render;
        public AccountController(IUserRepository userRepository , IViewRenderService render)
        {
            _user = userRepository;
            _render = render;
        }

        #region Register

        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_user.ExistUser(viewModel.Email.ToLower().Trim()))
                {
                    User user = new User()
                    {
                        Email = viewModel.Email.ToLower().Trim(),
                        Password = HashGenerators.MD5Encoding(viewModel.Password),
                        ActiveCode = CodeGenerators.ActiveCode(),
                        RegisterDate = DateTime.Now,
                        FullName = null,
                        IsActive = false,
                        RoleId = 2
                    };
                    _user.AddUser(user);

                    MessageSender message = new MessageSender();
                    string body = _render.RenderToStringAsync("_activateaccount", user);

                    message.SendEmail(user.Email, "کد فعالسازی حساب", body);

                    return RedirectToAction(nameof(ActivateAccount));
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با ایمیل وارد شده در قبلا در سایت ثبت نام کرده است");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }


        [Route("/ActivateAccount")]
        public IActionResult ActivateAccount()
        {
            return View();
        }

        [Route("/ActivateAccount")]
        [HttpPost]
        public IActionResult ActivateAccount(ActivateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_user.ExistActiveCode(viewModel.ActiveCode))
                {
                    _user.ActivateUser(viewModel.ActiveCode);
                    return RedirectToAction(nameof(Login));
                    
                }
                else
                {
                    ModelState.AddModelError("ActiveCode", "کد وارد شده نادرست است");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }



        #endregion


        #region Login

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        
        
        [Route("/Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string password = HashGenerators.MD5Encoding(viewModel.Password);
                if (_user.CheckUserForLogin(viewModel.Email,password))
                {
                    if (_user.IsActive(viewModel.Email))
                    {
                        User user = _user.GetUserByKeyName(viewModel.Email);

                        var claim = new List<Claim>();
                        claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                        claim.Add(new Claim(ClaimTypes.Name, user.Email));

                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = viewModel.RememberMe
                        };

                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("Index", "Home");
                        
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");
                        return View(viewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "ایمیل یا کلمه عبور وارد شده نادرست است ");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }


        [Route("/Logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region UserPanel
        [RoleAttribue(8)]
        public IActionResult UserPanel()
        {
            User user = _user.GetUserByKeyName(User.Identity.Name);
            return View(user);
        }
        [RoleAttribue(8)]
        public IActionResult EditUserPanel()
        {
            //int userid = _user.GetUserIdByKeyName(User.Identity.Name);
            User user = _user.GetUserByKeyName(User.Identity.Name);
            UpdateUserPanelViewModel viewModel = new UpdateUserPanelViewModel()
            {
                FullName=user.FullName
            };
            return View(viewModel);
        }
        [RoleAttribue(8)]
        [HttpPost]
        public IActionResult EditUserPanel(UpdateUserPanelViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = _user.GetUserByKeyName(User.Identity.Name);
               // user.FullName = viewModel.FullName;
                _user.UpdateUser(user, viewModel.FullName);
               // user.Email = users.Email;
                return RedirectToAction(nameof(UserPanel));
            }
            return View(viewModel);
        }

        [RoleAttribue(8)]
        public IActionResult TestDetail()
        {
            int userId = _user.GetUserIdByKeyName(User.Identity.Name);

            List<Test> tests = _user.GetTestsByUser(userId);

            List<int> testId = tests.Select(x => x.Id).ToList();

            List<CountryTest> countryTests = new List<CountryTest>();


            //List<Country> countries = new List<Country>();

            foreach (var item in testId)
            {
                countryTests.AddRange(_user.GetCountryTestsByUser(item));
                //countries = _user.GetCountriesByUser(item);
            }

           

            TestDetailViewModel viewModel = new TestDetailViewModel()
            {
                Tests=tests,
                CountryTests= countryTests
            };

            return View(viewModel);
        }



      

        #endregion


    }
}
