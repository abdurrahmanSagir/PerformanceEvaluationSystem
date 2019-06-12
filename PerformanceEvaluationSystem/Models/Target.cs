namespace PerformanceEvaluationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Target
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Target()
        {
            EvaluationDetails = new HashSet<EvaluationDetail>();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        public int TargetTypeID { get; set; }

        public int TargetCategoryID { get; set; }

        public int TargetWeight { get; set; }

        [Required]
        [StringLength(200)]
        public string TargetDescription { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public int CreUser { get; set; }

        public int? ModUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluationDetail> EvaluationDetails { get; set; }

        public virtual TargetCategory TargetCategory { get; set; }

        public virtual TargetType TargetType { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }
    }
}
