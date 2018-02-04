using System;
using System.IO;
using TestConsoleApp;

namespace TestApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            GradeBook book = new ThrowAwayGradeGradeBook();

            //book.NameChanged += onNameChanged; --Delegate Example
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }


        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputfile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputfile);
            }
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.averageGrade);
            WriteResult("Highest", (int)stats.highestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void AddGrades(GradeBook book)
        {
            book.addGrade(91);
            book.addGrade(89.5f);
            book.addGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                //Console.WriteLine("Enter a name");
               // book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something went wrong!!", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        static void onNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

    }
}
