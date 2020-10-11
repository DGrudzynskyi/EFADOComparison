using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFExampleBasic.Schema
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }
        public int StudyClassId { get; set; }

        public StudyClass StudyClass { get; set; }

        public bool IsLiveInDormitory { get; set; }
    }
}
