namespace WorkMan.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vacation")]
    public partial class Vacation
    {
        public int VacationID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeNumber { get; set; }

        public int VacationTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int VacationStatusID { get; set; }

        public virtual VacationType VacationType { get; set; }

        public virtual VacationStatu VacationStatu { get; set; }
    }
}
