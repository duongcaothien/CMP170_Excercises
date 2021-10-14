using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace Exercise6
{
    class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public string Class { get; set; }
            public List<Result> Exam { get; set; }
        }

        public class Result
        {
            public string Subject { get; set; }
            public decimal Point { get; set; }
        }




        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("Student_data_Handon.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);

            var listallstu = from Student in students
                             orderby Student.FirstName ascending
                             select Student;
            Console.WriteLine("cau 1");
            foreach (var Student in listallstu) Console.WriteLine($"{Student.FirstName }  {Student.LastName} - {Student.Id}");
            Console.WriteLine("cau 2");

            var satatis1 = from Student in students
                           group Student by Student.Gender;

            foreach (var group in satatis1)
            {
                Console.WriteLine($"{group.Key}-{group.Count()} students");

            }
            var satatis2 = from Student in students
                           group Student by Student.Class;
            foreach (var group in satatis2)
            {
                Console.WriteLine($"{group.Key} - {group.Count()} students");

            }
            Console.WriteLine("cau 3");


            foreach (var ko in students)
            {
                Console.WriteLine($"{ko.FirstName} - GPA:{ko.Exam.Average(a => a.Point)}");

            }

            
            Console.WriteLine("cau 5");
            Console.WriteLine("List of students must repeat subject: has a subject less than 5");
            var repeat = students.Where(s => s.Exam.Any(x => x.Point < 5)).ToList();
            foreach (var rotmon in repeat)
            {
                Console.WriteLine($"Name: {rotmon.FirstName}");
                var tenmonrot = rotmon.Exam.Where(rot => rot.Point < 5).ToList();
                foreach (var tenmon in tenmonrot)
                {
                    Console.WriteLine($"- {tenmon.Subject}:{tenmon.Point} Point(s)");
                }
            }
            
            Console.WriteLine("cau 8");
            var fuse = from Student in students
                       where Student.Exam.Average(a => a.Point) > 7 && Student.Exam.Any(x => x.Point >= 5)
                       select Student;
            Console.WriteLine("good students which GPA > 7 and no subject less than 5");
            foreach (var Student in fuse)
            {
                Console.WriteLine($"{Student.FirstName }  {Student.LastName} ");
                Console.WriteLine($"GPA:{Student.Exam.Average(a => a.Point)} ");
                var tenmon = Student.Exam.Where(rot => rot.Point >= 5);
                foreach (var tenp in tenmon)
                {
                    Console.WriteLine($"- {tenp.Subject}:{tenp.Point} Point(s)");
                }
            }
        }
    }
}

