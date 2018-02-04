using System;
using System.Collections.Generic;
using System.IO;
using TestConsoleApp;

namespace TestApp1
{
    public class GradeBook
    {
        public GradeBook() //Constructor
        {
            _name = "Empty";
            grades = new List<float>();
        }



        public GradeStatistics ComputeStatistics()
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




        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }




        public void addGrade(float grade)
        {
            grades.Add(grade);
        }



        public string Name //Name is a public member
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                _name = value;

            }
        }
        public event NameChangedDelegate NameChanged; //Reference Types
        private string _name;
        public List<float> grades;
    }
}
