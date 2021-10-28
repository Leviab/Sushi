using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sushi.Data;
using Sushi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext db)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            _db = db;
        }
        //get - register
        public IActionResult Register()
        {
            return View();
        }
        //post - register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {

                var IdUser = new User()
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    SafeWord = user.SafeWord,
                    UserName = user.UserName
                };

                var result = await userManager.CreateAsync(IdUser, user.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(IdUser, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        //get
        public IActionResult Login()
        {
            return View();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {
                var result = await signInManager.PasswordSignInAsync(model.UserName,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Ivalid Login Attempt");
            }
            
            return View();
    
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> UserPageAsync()
        {
            //await signInManager.SignOutAsync();
            //return  RedirectToAction("Login");
            return View(await userManager.FindByNameAsync(User.Identity.Name));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("UserPage");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        //unique checking

        public JsonResult EmailIsUnique(string Email)
        {
            if (_db.Users.Any(x => x.Email == Email))
                return Json(false);
            return Json(true);
        }
        public JsonResult NameIsUnique(string Name)
        {
            if (_db.Users.Any(x => x.UserName == Name))
                return Json(false);
            return Json(true);
        }
        public JsonResult PhoneNumIsUnique(string PhoneNumber)
        {
            if (_db.Users.Any(x => x.PhoneNumber == PhoneNumber))
                return Json(false);
            return Json(true);
        }
    }
}
