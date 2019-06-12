using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PerformanceEvaluationSystem.Models;

namespace PerformanceEvaluationSystem.Controllers
{
    public class UserController : Controller
    {
        
        // GET: EmployeeLogin
        public ActionResult UserLogin()
        {
            ViewBag.LoginMessage = "";
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(LoginInformation logInf)
        {
            using (PerformanceEvaluation ctx = new PerformanceEvaluation())
            {
                LoginInformation loginInformation = new LoginInformation();
                loginInformation = ctx.LoginInformations.Where(x => x.Username == logInf.Username && x.Password ==  logInf.Password).FirstOrDefault();
                
                if(loginInformation==null)
                {
                    ViewBag.LoginMessage = "**Kulanıcı Adı veya Parola Hatalı**".ToUpper();
                    return View();
                }
                else if(ctx.Users.Where(x=>x.LoginID==loginInformation.ID).FirstOrDefault().IsDeleted)
                {
                    ViewBag.LoginMessage = "**Girdiğiniz bilgilere ait kullanıcı aktif değil**".ToUpper();
                    return View();
                }else if(loginInformation.IsDeleted)
                {
                    ViewBag.LoginMessage = "**Eski bir şifre girdiniz**".ToUpper();
                    return View();
                }
                var usr = ctx.Users.Where(x => x.LoginID == loginInformation.ID).FirstOrDefault();
                Session["CurrentUser"] = usr;
                var roleID = ctx.UserRoles.Where(x => x.UserID == usr.ID).Select(x => x.RoleID).FirstOrDefault();
                Session["Role"] = ctx.Roles.Where(x => x.ID == roleID).Select(x => x.Name).FirstOrDefault();
                var str = Session["Role"];


                return RedirectToAction("Index", "Home");
            }
        }
    }
   
}