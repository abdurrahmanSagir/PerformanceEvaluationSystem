namespace PerformanceEvaluationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TargetType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TargetType()
        {
            Targets = new HashSet<Target>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TargetTypeName { get; set; }

        [Required]
        [StringLength(30)]
        public string TargetTypeCode { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public int CreUser { get; set; }

        public int? ModUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Target> Targets { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
