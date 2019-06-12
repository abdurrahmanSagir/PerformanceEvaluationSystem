using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceEvaluationSystem.Controllers
{
    public class EvaluationController : Controller
    {
        PerformanceEvaluation db = new PerformanceEvaluation();
        public ActionResult Index(int isFirstManagerEvaluation)
        {
            var FirstManagerID = ((User)Session["CurrentUser"]).ID;
            var userList = db.Users.
                Where(x => x.FirstManagerID == FirstManagerID).
                Select(x => x).ToList();
            ViewBag.isFirstManagerEvaluation = isFirstManagerEvaluation == 1 ? true:false ;
            return View(userList);
            
        }
        public ActionResult PersonalEvaluation()
        {
            int userID = ((User)Session["CurrentUser"]).ID;
            List<Target> targets = db.Targets.Where(x => x.UserID ==userID ).ToList();
            ViewBag.targetTypes = db.TargetTypes.ToList();
            ViewBag.targetCategories = db.TargetCategories.ToList();
            return View(targets);
        }
        [HttpPost]
        public void PersonalEvaluation(List<Data> data)
        {
            int evaluatorPersonalID = ((User)Session["CurrentUser"]).ID;
            Evaluation ev =new Evaluation();
            ev.IsDeleted = false;
            ev.EvaluationTypeID = 1;
            ev.EvaluatorPersonalID = evaluatorPersonalID;
            ev.EvaluatedPersonalID = data[0].evaluatedPersonalID;
            ev.CreationTime = DateTime.Now;
            ev.CreUser = evaluatorPersonalID;
            db.Evaluations.Add(ev);
            db.SaveChanges();

            var lastEvaluation = db.Evaluations.OrderByDescending(x=>x.ID).FirstOrDefault();
            int lastEvaluationID = lastEvaluation.ID;
            foreach(Data d in data)
            {
                EvaluationDetail evDet = new EvaluationDetail();
                evDet.TargetID = d.targetID;
                evDet.Description = d.description;
                evDet.Mark = d.mark;

                evDet.EvaluationID = lastEvaluationID;
                evDet.CreUser = evaluatorPersonalID;
                evDet.IsDeleted = false;
                evDet.CreationTime = DateTime.Now;
                db.EvaluationDetails.Add(evDet);
                db.SaveChanges();

            }
            
        }

        public ActionResult FirstManagerEvaluation(int id)
        {
            List<Target> targets = db.Targets.Where(x => x.UserID == id).ToList();
            ViewBag.targetTypes = db.TargetTypes.ToList();
            ViewBag.targetCategories = db.TargetCategories.ToList();
            Evaluation ev = db.Evaluations.Where(x => x.EvaluatedPersonalID == id && x.EvaluatorPersonalID == id).OrderByDescending(x=>x.ID).FirstOrDefault();
            ViewBag.personalEvaluationDetails = db.EvaluationDetails.Where(x => x.EvaluationID == ev.ID).ToList();
            return View(targets);
        }
        [HttpPost]
        public void FirstManagerEvaluation(List<Data> data)
        {
            int evaluatorPersonalID = ((User)Session["CurrentUser"]).ID;
            Evaluation ev = new Evaluation();
            ev.IsDeleted = false;
            ev.EvaluationTypeID = 6;
            ev.EvaluatorPersonalID = evaluatorPersonalID;
            ev.EvaluatedPersonalID = data[0].evaluatedPersonalID;
            ev.CreationTime = DateTime.Now;
            ev.CreUser = evaluatorPersonalID;
            db.Evaluations.Add(ev);
            db.SaveChanges();

            var lastEvaluation = db.Evaluations.OrderByDescending(x => x.ID).FirstOrDefault();
            int lastEvaluationID = lastEvaluation.ID;
            foreach (Data d in data)
            {
                EvaluationDetail evDet = new EvaluationDetail();
                evDet.TargetID = d.targetID;
                evDet.Description = d.description;
                evDet.Mark = d.mark;

                evDet.EvaluationID = lastEvaluationID;
                evDet.CreUser = evaluatorPersonalID;
                evDet.IsDeleted = false;
                evDet.CreationTime = DateTime.Now;
                db.EvaluationDetails.Add(evDet);
                db.SaveChanges();

            }
        }
        public class Data
        {
            public int evaluatedPersonalID { get; set; }
            public int targetID { get; set; }
            public int mark { get; set; }
            public string description { get; set; }
        }
    }
}