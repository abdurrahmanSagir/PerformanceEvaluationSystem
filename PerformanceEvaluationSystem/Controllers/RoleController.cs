using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceEvaluationSystem.Controllers
{
    public class RoleController : Controller
    {
        PerformanceEvaluation ctx = new PerformanceEvaluation();

        // GET: Role
        public ActionResult Index()
        {
            List<Role> role = ctx.Roles.ToList();
            return View(role);
        }

        public ActionResult DeleteRole(int id)
        {
            Role r = ctx.Roles.FirstOrDefault(x => x.ID == id);
            r.IsDeleted = true;
            r.DeletionTime = DateTime.Now;
            //değiştirelecek
            r.ModUser = ((User)Session["CurrentUser"]).ID;
            ctx.SaveChanges();
            return RedirectToAction("Index", "Role");
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role rl)
        {
            rl.CreationTime = DateTime.Now;
            //değiştirilecek
            rl.CreUser = ((User)Session["CurrentUser"]).ID;
            rl.IsDeleted = false;
            ctx.Roles.Add(rl);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Role");
        }
    }
}