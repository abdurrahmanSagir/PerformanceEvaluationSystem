namespace PerformanceEvaluationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EvaluationDetail
    {
        public int ID { get; set; }

        public int EvaluationID { get; set; }

        public int TargetID { get; set; }

        public int Mark { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public int CreUser { get; set; }

        public int? ModUser { get; set; }

        public virtual Evaluation Evaluation { get; set; }

        public virtual Target Target { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
