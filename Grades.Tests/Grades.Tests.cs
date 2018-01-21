using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp1;

namespace Grades.Tests
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "John";
            name = name.ToUpper();
            Assert.AreEqual("JOHN", name);

        }
        [TestMethod]
        public void DateTimeTest()
        {
            DateTime date = new DateTime(2002, 8, 11);
            date = date.AddDays(1);

            Assert.AreEqual(date.Day, 12);
        }
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            increaseNumber(x);

            Assert.AreEqual(46, x);
        }
        private void increaseNumber(int number)
        {

            number += 1;
        }
        [TestMethod]
        public void ReferenceTypesPassByValues()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }
        private void GiveBookAName(ref GradeBook book5)
        {
            book5 = new GradeBook();
            book5.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "John";
            string name2 = "john";
            bool result = String.Equals(name1, name2, System.StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);

        }
        [TestMethod]

        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.addGrade(10);
            book.addGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.highestGrade);
        }
        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.addGrade(10);
            book.addGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.lowestGrade);
        }
        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.addGrade(91);
            book.addGrade(89.5f);
            book.addGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.averageGrade, 0.01);
        }
        [TestMethod]
        public void LetterGradeEquals()
        {
            GradeBook book = new GradeBook();
            book.addGrade(91);
            book.addGrade(85);
            book.addGrade(71);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual("B", stats.LetterGrade);
        }
        [TestMethod]
        public void LetterGradeNotEquals()
        {
            GradeBook book = new GradeBook();
            book.addGrade(91);
            book.addGrade(85);
            book.addGrade(71);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreNotEqual("C", stats.LetterGrade);
        }
    }
}
