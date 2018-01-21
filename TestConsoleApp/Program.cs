using System;

namespace TestApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            GradeBook book = new GradeBook();

            book.addGrade(91);
            book.addGrade(89.5f);
            book.addGrade(75);


            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.averageGrade);
            WriteResult("Lowest", (int)stats.lowestGrade);
            Console.WriteLine(stats.averageGrade);
            Console.WriteLine(stats.lowestGrade);
            Console.WriteLine(stats.highestGrade);
            WriteResult("Grade", stats.LetterGrade);
        }

        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }
        static void WriteResult(string description, string result)
        {
            //Console.WriteLine(description + ": " + result);
            Console.WriteLine($"{description}: {result}", description, result);
        }
    }
}
