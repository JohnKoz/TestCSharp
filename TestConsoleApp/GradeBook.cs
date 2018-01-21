using System;
using System.Collections.Generic;
using TestConsoleApp;

namespace TestApp1
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

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
                if (!String.IsNullOrEmpty(value))

                    if (_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        NameChanged(this, args);
                    }
                _name = value;

            }
        }
        public event NameChangedDelegate NameChanged;
        private string _name;
        List<float> grades;
    }
}
