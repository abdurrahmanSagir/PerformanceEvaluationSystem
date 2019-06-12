namespace PerformanceEvaluationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EvaluationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvaluationType()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string EvaluationTypeName { get; set; }

        [Required]
        [StringLength(30)]
        public string EvaluationTypeCode { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public int CreUser { get; set; }

        public int? ModUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
