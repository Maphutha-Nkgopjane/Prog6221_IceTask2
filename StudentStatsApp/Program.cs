using System;
using System.Collections;

namespace StudentStatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList students = new ArrayList();

            Console.WriteLine("--- Adding Student Records ---");

            try
            {
                students.Add(new Student("Alice Smith", 85.5, 90.0));
                students.Add(new Student("Bob Johnson", 72.0, 78.5));
                students.Add(new Student("Charlie Brown", 95.0, 98.0));
                students.Add(new Student("Diana Prince", 60.0, 65.5));
                students.Add(new Student("Ethan Hunt", 88.0, 82.0));

                // Uncomment to test validation
                // students.Add(new Student("Invalid", 110.0, -5.0));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine("\n--- Student Details ---");

            foreach (object obj in students)
            {
                if (obj is Student student)
                {
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("Invalid object in collection.");
                }
            }

            Console.WriteLine("\n--- Statistics ---");
            DetermineStats(students);

            Console.WriteLine("\nPress Enter to exit.");
            Console.ReadLine();
        }

        public static void DetermineStats(ArrayList students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available for statistics.");
                return;
            }

            double highestAvg = -1;
            string topStudent = "N/A";

            double lowestAvg = 101;
            string lowStudent = "N/A";

            double sum = 0;
            int count = 0;

            foreach (object obj in students)
            {
                if (obj is Student student)
                {
                    try
                    {
                        double avg = student.ComputeAverage();
                        sum += avg;
                        count++;

                        if (avg > highestAvg)
                        {
                            highestAvg = avg;
                            topStudent = student.Name;
                        }

                        if (avg < lowestAvg)
                        {
                            lowestAvg = avg;
                            lowStudent = student.Name;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error computing average for {student.Name}: {ex.Message}");
                    }
                }
            }

            if (count > 0)
            {
                double overallAvg = sum / count;

                Console.WriteLine($"Highest Average: {highestAvg:F2} (Student: {topStudent})");
                Console.WriteLine($"Lowest Average:  {lowestAvg:F2} (Student: {lowStudent})");
                Console.WriteLine($"Overall Average: {overallAvg:F2}");
            }
            else
            {
                Console.WriteLine("No valid averages to calculate statistics.");
            }
        }
    }
}
