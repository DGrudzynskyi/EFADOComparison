using EFExampleBasic.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EFExampleBasic
{
    public static class EFSamples
    {
        public static void AddStudyClass() {
            using (var context = new EFExampleBasicContext()) {
                var newClass = new StudyClass()
                {
                    Name = "TA-81",
                    StartYear = 2017,
                };

                context.Classes.Add(newClass);
                context.SaveChanges();
            }
        }

        public static void AddStudent() {
            using (var context = new EFExampleBasicContext())
            {
                var someClassId = context.Classes
                    .Where(studyClass => studyClass.Name == "TA-81")
                    .Select(studyClass => studyClass.Id)
                    .FirstOrDefault();
                
                var newStudent = new Student()
                {
                    FirstName= "Korch",
                    LastName= "Anufriy",
                    Address = new Address() { 
                        City="Kiev",
                        FirstLine="Troeshina",
                        SecondLine="Amin'"
                    },
                    StudyClassId=someClassId
                };

                context.Students.Add(newStudent);
                context.SaveChanges();
            }
        }

        public static void ShowAllClassesAndStudents() {
            using (var context = new EFExampleBasicContext())
            {
                var classes = context.Classes.ToList();

                foreach (var studyClass in classes) {
                    var studentsCount = studyClass.Students.Count;
                    Console.WriteLine("Class {0} has {1} students", studyClass.Name, studentsCount);

                    foreach (var student in studyClass.Students)
                    {
                        Console.WriteLine("Student {0} {1}. From {2}, {3}, {4}. Born {5}",
                            student.FirstName,
                            student.LastName,
                            student.Address.City,
                            student.Address.FirstLine,
                            student.Address.SecondLine,
                            student.DateOfBirth);
                    }
                }
            }
        }

        public static void ModifyStudent() {
            using (var context = new EFExampleBasicContext())
            {
                var firstStudent = context.Students.FirstOrDefault();

                firstStudent.FirstName = "modifiedName";

                var entry = context.Entry(firstStudent);

                context.SaveChanges();
            }
        }
    }
}
