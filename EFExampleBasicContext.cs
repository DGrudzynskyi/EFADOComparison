using EFExampleBasic.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
