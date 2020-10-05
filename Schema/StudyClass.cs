using System;
using System.Collections.Generic;
using System.Text;

namespace EFExampleBasic.Schema
{
    public class StudyClass
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
