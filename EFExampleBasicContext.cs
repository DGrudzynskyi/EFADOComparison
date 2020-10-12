using EFExampleBasic.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Text;

namespace EFExampleBasic
{
    public class EFExampleBasicContext : DbContext
    {
        public EFExampleBasicContext() : base()
        {
            Database.Connection.ConnectionString = Program.ConnectionString;
            Database.Log = (string logMe) => Debug.WriteLine(logMe);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudyClass> Classes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
        }
    }

    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(x => x.FirstName).HasMaxLength(256).IsRequired();
            Property(x => x.LastName).HasMaxLength(256).IsRequired();
            Property(x => x.DateOfBirth).HasColumnType("datetime2");
            HasIndex(s => new { s.FirstName, s.LastName, s.DateOfBirth });
        }
    }
}
