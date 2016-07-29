namespace WorkMan.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeID { get; set; }

        public int TitleID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Title Title { get; set; }

        public virtual Supervisor Supervisor { get; set; }
    }
}
