using System;

namespace StudentStatsApp
{
    /// <summary>
    /// Represents a student with test marks and the ability to compute average.
    /// </summary>
    public class Student
    {
        // Private fields
        private string _name;
        private double _test1;
        private double _test2;

        public string Name => _name;
        public double Test1 => _test1;
        public double Test2 => _test2;

        public Student(string name, double test1, double test2)
        {
            if (test1 < 0 || test1 > 100)
                throw new ArgumentOutOfRangeException(nameof(test1), "Test 1 must be between 0 and 100.");
            if (test2 < 0 || test2 > 100)
                throw new ArgumentOutOfRangeException(nameof(test2), "Test 2 must be between 0 and 100.");

            _name = name;
            _test1 = test1;
            _test2 = test2;
        }

        public double ComputeAverage()
        {
            try
            {
                return (_test1 + _test2) / 2.0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error computing average for {Name}: {ex.Message}", ex);
            }
        }

        public override string ToString()
        {
            double average = 0.0;
            try
            {
                average = ComputeAverage();
            }
            catch
            {
                // Leave average as 0.0
            }

            return $"Name: {Name,-15} | Test1: {Test1,6:F2} | Test2: {Test2,6:F2} | Average: {average,6:F2}";
        }
    }
}
