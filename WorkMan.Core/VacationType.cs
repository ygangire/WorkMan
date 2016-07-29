namespace WorkMan.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VacationType")]
    public partial class VacationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VacationType()
        {
            Vacations = new HashSet<Vacation>();
        }

        public int VacationTypeID { get; set; }

        [Column("VacationType")]
        [Required]
        [StringLength(50)]
        public string VacationType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
