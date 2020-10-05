using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EFExampleBasic
{
    public class ADOSample
    {
        public static void AddStudyClass()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();
                string sql = "INSERT[dbo].[StudyClasses]([StartYear], [Name])VALUES(@Year, @Name)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Year", 2017);
                    command.Parameters.AddWithValue("@Name", "TO-81");

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddStudent()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string selectClassSql = "SELECT [ID] FROM [dbo].[StudyClasses] WHERE [Name] = @Name";

                var classId = 0;
                using (SqlCommand command = new SqlCommand(selectClassSql, connection))
                {
                    command.Parameters.AddWithValue("@Name", "TO-81");
                    classId = int.Parse(command.ExecuteScalar().ToString());
                }

                string addStudentSql =
                    "INSERT[dbo].[Students]([FirstName], [LastName], [Address_City]," +
                    "[Address_FirstLine], [Address_SecondLine], [StudyClassId])" +
                    "VALUES(@FirstName, @LastName, @City, @Address1, @Address2, @ClassId)";

                using (SqlCommand command = new SqlCommand(addStudentSql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", "Masha");
                    command.Parameters.AddWithValue("@LastName", "Katja");
                    command.Parameters.AddWithValue("@City", "Kiev");
                    command.Parameters.AddWithValue("@Address1", "Borshagovka");
                    command.Parameters.AddWithValue("@Address2", "Vozle lar'ka");
                    command.Parameters.AddWithValue("@ClassId", classId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ShowAllClassesAndStudents()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string selectClassesSql = "SELECT [ID], [NAME] FROM [dbo].[StudyClasses]";

                string studentsCountSql = "Select count([ID]) FROM [dbo].[Students] where [StudyClassId]=@ClassId";

                string selectStudentsSql = "SELECT [FirstName], [LastName], [Address_City], " +
                    "[Address_FirstLine], [Address_SecondLine], [DateOfBirth] " +
                    "FROM [dbo].[Students] WHERE [StudyClassId]=@ClassId";

                using (SqlCommand command = new SqlCommand(selectClassesSql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var classId = reader.GetInt32(0);
                            var className = reader.GetString(1);
                            var totalStudents = 0;

                            using (SqlCommand countCommand = new SqlCommand(studentsCountSql, connection)) {
                                countCommand.Parameters.AddWithValue("@ClassId", classId);
                                totalStudents = int.Parse(countCommand.ExecuteScalar().ToString());
                            }

                            Console.WriteLine("Class {0} has {1} students", className, totalStudents);

                            using (SqlCommand getStudentCommand = new SqlCommand(selectStudentsSql, connection))
                            {
                                getStudentCommand.Parameters.AddWithValue("@ClassId", classId);

                                using (SqlDataReader studentReader = getStudentCommand.ExecuteReader())
                                {
                                    while (studentReader.Read())
                                    {
                                        Console.WriteLine("Student {0} {1}. From {2}, {3}, {4}. Born {5}",
                                            studentReader.IsDBNull(0) ? String.Empty : studentReader.GetString(0),
                                            studentReader.IsDBNull(1) ? String.Empty : studentReader.GetString(1),
                                            studentReader.IsDBNull(2) ? String.Empty : studentReader.GetString(2),
                                            studentReader.IsDBNull(3) ? String.Empty : studentReader.GetString(3),
                                            studentReader.IsDBNull(4) ? String.Empty : studentReader.GetString(4),
                                            studentReader.IsDBNull(5) ? "somewhen" : studentReader.GetString(5));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
