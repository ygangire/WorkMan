namespace WorkMan.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelWorkMan : DbContext
    {
        public ModelWorkMan()
            : base("name=ModelWorkMan")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<VacationStatu> VacationStatus { get; set; }
        public virtual DbSet<VacationType> VacationTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Supervisor)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Supervisor>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Supervisor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.TitleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vacation>()
                .Property(e => e.EmployeeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VacationStatu>()
                .Property(e => e.VacationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<VacationStatu>()
                .HasMany(e => e.Vacations)
                .WithRequired(e => e.VacationStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VacationType>()
                .Property(e => e.VacationType1)
                .IsUnicode(false);

            modelBuilder.Entity<VacationType>()
                .HasMany(e => e.Vacations)
                .WithRequired(e => e.VacationType)
                .WillCascadeOnDelete(false);
        }
    }
}
