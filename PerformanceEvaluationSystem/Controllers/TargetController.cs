using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceEvaluationSystem.Controllers
{
    public class TargetController : Controller
    {
        PerformanceEvaluation db = new PerformanceEvaluation();
        // GET: Target
        public ActionResult Index()
        {
            var TargetAssignmentManagerID = ((User)Session["CurrentUser"]).ID;
            var TargetedUserList = db.Users.
                Where(x => x.TargetAssignmentManagerID ==TargetAssignmentManagerID).
                Select(x => x).ToList();
            return View(TargetedUserList);
        }
        public ActionResult AddTarget(int id)
        {
            User user = db.Users.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.targetTypes = db.TargetTypes.ToList();
            ViewBag.targetCategories = db.TargetCategories.ToList();
            return View(user);
        }
        [HttpPost]
        public void AddTarget(List<Target> targets)
        {
            foreach (Target t in targets)
            {
                t.CreUser = ((User)Session["CurrentUser"]).ID;
                t.CreationTime = DateTime.Now;
                t.IsDeleted = false;
                db.Targets.Add(t);
                db.SaveChanges();
            }

        }
    }
}