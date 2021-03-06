﻿namespace Algorithms.Pivot
{
    public class Grade
    {
        public Grade(string student, double value)
        {
            Student = student;
            Value = value;
        }

        public string Student { get; set; }

        public double Value { get; set; }

        public override string ToString()
        {
            return $"Grade[Student={Student}, Value={Value}]";
        }
    }
}
