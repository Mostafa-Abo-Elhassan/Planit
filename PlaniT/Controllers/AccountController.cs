using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlaniT.Models;

namespace PlaniT.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,
                                     SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    JobTitle = model.JobTitle // Uncomment if you have a JobTitle field in RegisterViewModel
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userrole = await userManager.AddToRoleAsync(user, "User");
                    if (userrole.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("register");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult login(string ReturnUrl)
        {
            //var model = new LoginVM
            //{
            //    ReturnUrl = ReturnUrl
            //};
            return View(/*model*/);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // البحث عن المستخدم باستخدام البريد الإلكتروني
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    // التحقق من كلمة المرور
                    bool passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
                    if (passwordValid == true)
                    {
                        //if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                        //{
                        //    return RedirectToPage(model.ReturnUrl);
                        //}
                        // تسجيل الدخول
                        await signInManager.SignInAsync(user, model.RememberMe);
                        // توجيه المستخدم إلى الصفحة الرئيسية أو لوحة التحكم
                        return RedirectToAction("Index", "Home");
                    }


                    // كلمة المرور غير صحيحة
                    ModelState.AddModelError("", "Invalid user name or password.");

                }


                // البريد الإلكتروني غير موجود
                ModelState.AddModelError("", "Invalid email or password.");

            }

            // العودة إلى صفحة تسجيل الدخول مع عرض رسائل الأخطاء
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }





        //[Authorize(Roles = "Admin,Super_Admin")]
        //[HttpGet("GetAllUsers")]
        //public async Task<IActionResult> Users()
        //{
        //    // الحصول على جميع المستخدمين
        //    var users = userManager.Users.ToList();

        //    // إذا كانت القائمة فارغة
        //    if (users == null || !users.Any())
        //    {
        //        return NotFound("No users found.");
        //    }

        //    // تجهيز البيانات للعرض
        //    //var userList = users.Select(user => new
        //    //{
        //    //    user.Id,
        //    //    user.UserName,
        //    //    user.Email,

        //    //}).ToList();

        //    return View("GetAllUsers", users);

        //}




    }
}
