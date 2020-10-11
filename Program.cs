using System;
using System.Configuration;

namespace EFExampleBasic
{
    public class Program
    {
        public static string ConnectionString = "Server=localhost\\sqlexpress;Database=EFExampleBasicDeveloper1;Integrated Security=true;MultipleActiveResultSets=True;";

        static void Main(string[] args)
        {
            EFSamples.ShowAllClassesAndStudents();
        }
    }
}
