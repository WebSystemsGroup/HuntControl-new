using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Membership.ValidateUser(model.Name, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный пароль или логин");
                    }
                }
                catch (Exception ex)
                {
                    return PartialView(ex);
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEditPassword(ChangePasswordModel model)
        {
            if (User.IsInRole("superadmin") || (User.IsInRole("admin")) || User.IsInRole("seniorspecialist"))
                ModelState["Password"].Errors.Clear();
            if (ModelState.IsValid)
            {
                if (User.IsInRole("superadmin") || (User.IsInRole("admin")) || User.IsInRole("seniorspecialist"))
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var dbEntry = db.spr_employees.SingleOrDefault(u => u.employees_login == model.Login);
                        if (dbEntry != null)
                        {
                            dbEntry.employees_pass = System.Web.Helpers.Crypto.HashPassword(model.NewPassword);
                        }
                        db.SaveChanges();
                        return Json("Пароль успешно изменен", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    if (Membership.ValidateUser(model.Login, model.Password))
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            db.spr_employees.SingleOrDefault(u => u.employees_login == model.Login).employees_pass = Crypto.HashPassword(model.NewPassword);
                            db.SaveChanges();
                        }
                        return Json("Пароль успешно изменен", JsonRequestBehavior.AllowGet);
                    }
                    throw new Exception("Пароль неверный");
                }
            }
            throw new Exception("Ошибка валидации");
        }
    }
}