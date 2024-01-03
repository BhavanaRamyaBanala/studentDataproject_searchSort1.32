using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace project1._32
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\dotNet\\project1.32\\student_data.txt";

            List<Student> students = LoadStudentData(filePath);
            Console.WriteLine("Choose an option given below:\n1.Sort & Display all students\n2.Search a student\n");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    DisplayStudentData(students);
                    break;

                case 2:
                    Console.Write("\nEnter the name to search:\n");
                    string searchName = Console.ReadLine();
                    SearchAndDisplayStudent(students, searchName);
                    break;
                default:
                    Console.WriteLine("\nInvalid option!!\n");
                    Main(args);
                    break;
            }
        }

        // Load student data from the file
        static List<Student> LoadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string className = parts[1].Trim();

                    students.Add(new Student(name, className));
                }
            }

            return students.OrderBy(s => s.Name).ToList();
        }

        static void DisplayStudentData(List<Student> students)
        {
            Console.WriteLine("\nStudent Data:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.ClassName}");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            var foundStudent = students.Where(s => s.Name.ToLower().Contains(searchName.ToLower())).ToList();

            if (foundStudent.Any())
            {
                Console.WriteLine("\nStudent Found");
                DisplayStudentData(foundStudent);
            }
            else
            {
                Console.WriteLine($"\nStudent not found with the name:\n {searchName}");
            }
            Console.WriteLine();
        }
    }
}
