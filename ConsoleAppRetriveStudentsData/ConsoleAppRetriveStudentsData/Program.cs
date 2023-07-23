using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRetriveStudentsData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\simplilearn\\project\\students.txt";
            List<Student> students = new List<Student>();

            
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    try
                    {
                        Student student = new Student
                        {
                            Name = data[0].Trim(),
                            Age = int.Parse(data[1].Trim()),
                            Grade = data[2].Trim()
                        };
                        students.Add(student);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid data format: {line}. Skipping this line.");
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid data format: {line}. Skipping this line.");
                    Console.WriteLine("\n");
                }
            }
   
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }

            Console.ReadKey();
        }
    }
}
