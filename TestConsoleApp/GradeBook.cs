using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TestConsoleApp;

namespace TestApp1
{
    public class GradeBook : GradeTracker
    {
        public GradeBook() //Constructor
        {
            _name = "Empty";
            grades = new List<float>();
        }



        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            Console.WriteLine("GradeBook::ComputeStatistics");
            float sum = 0;
            foreach (float grade in grades)
            {
                stats.highestGrade = Math.Max(grade, stats.highestGrade);
                stats.lowestGrade = Math.Min(grade, stats.lowestGrade);
                sum += grade;
            }

            stats.averageGrade = sum / grades.Count;
            return stats;
        }


        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }


        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
        protected List<float> grades;
    }
}
