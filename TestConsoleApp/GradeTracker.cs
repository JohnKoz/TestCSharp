using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TestApp1;

namespace TestConsoleApp
{
    public abstract class GradeTracker: IGradeTracker
    {
        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
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
        public abstract IEnumerator GetEnumerator();
        public event NameChangedDelegate NameChanged; //Reference Types

        protected string _name;

    }
}
