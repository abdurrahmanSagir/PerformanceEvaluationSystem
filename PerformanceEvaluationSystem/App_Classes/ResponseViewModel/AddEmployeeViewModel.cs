using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceEvaluationSystem.App_Classes.ResponseViewModel
{
    public class AddEmployeeViewModel
    {
        public AddEmployeeViewModel()
        {
            this.Manager1 = new List<SelectListItem>();
            this.Manager2 = new List<SelectListItem>();
            this.TargetAssignmentManagerID = new List<SelectListItem>();
            this.RolAta = new List<SelectListItem>();
            
        }
        public const String TargetSTR = "TargetAssignmentManagerID";
        public const String FirstSTR = "FirstManagerID";
        public const String SecondSTR = "SecondManagerID";
        public User NewUser { get; set; }
        public IEnumerable<SelectListItem> Manager1 { get; set; }
        public IEnumerable<SelectListItem> Manager2 { get; set; }
        public IEnumerable<SelectListItem> TargetAssignmentManagerID { get; set; }
        public IEnumerable<SelectListItem> RolAta { get; set; }
        
    }
}