using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Student
    {
        public string FullName { get; set; }
        public int Course { get; set; }
        public double Rating { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    FullName = "Ivanenko Ivan",
                    Course = 2,
                    Rating = 90
                },
                new Student()
                {
                    FullName = "Petrenko Petro",
                    Course = 2,
                    Rating = 60
                },
                new Student()
                {
                    FullName = "Yurchenko Yuriy",
                    Course = 1,
                    Rating = 75
                },
                new Student()
                {
                    FullName = "Taranenko Ivan",
                    Course = 1,
                    Rating = 82
                },
                new Student()
                {
                    FullName = "Popovich Ivan",
                    Course = 2,
                    Rating = 68
                }
            };

            // map data
            var names = students.Select(student => 
                String.Format("{0} - {1}", student.FullName, student.Rating)
                )
            .ToList();

            // filter data
            var course2 = students.Where(student => { /* ..... */ return student.Course == 2; }).ToList();

            // group data
            var studentsPerCourse = students.GroupBy(student => student.Course).ToList();
            // [
            //   { Key: <course value>, <list that relates to this Key>}
            // ]

            foreach (var group in studentsPerCourse)
            {
                Console.WriteLine("{0}:", group.Key);
                Console.WriteLine(String.Join(",", group.Select(s => s.FullName)));
            }

            // sort data
            var sortedList = students
                .OrderBy(student => student.Course)
                .ThenByDescending(student => student.Rating);

            foreach (var student in sortedList)
            {
                Console.WriteLine("{0}. {1} : {2}", student.Course, student.FullName, student.Rating);
            }

            // data aggregation
            var sum = students.Sum(student => student.Rating);
            var avg = students.Average(student => student.Rating);
            var min = students.Min(student => student.Rating);
            var max = students.Max(student => student.Rating);

            //
            var max2 = students
                .Where(student => student.Course == 2)
                .Max(student => student.Rating);

            Console.ReadKey();
        }
    }
}
