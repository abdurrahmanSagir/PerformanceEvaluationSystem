using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerformanceEvaluationSystem.App_Classes
{
    public class UsersDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string RegistryNumber { get; set; }

        public int? LoginID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        public int? UserTypeID { get; set; }

        public int? TargetAssignmentManagerID { get; set; }

        public int? FirstManagerID { get; set; }

        public int? SecondManagerID { get; set; }

        public int? PersonalEvaluationMark { get; set; }

        public int? FirstManagerMark { get; set; }

        public int? CurrentMark { get; set; }

        public int? CurrentCategoryID { get; set; }

        [StringLength(50)]
        public string UserStatus { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public string TargetAssignmentManagerName { get; set; }

        public string FirstManagerName { get; set; }

        public string SecondManagerName { get; set; }

    }
}