namespace TestApp1
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            highestGrade = 0;
            lowestGrade = float.MaxValue;
        }
        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Fail mother fucker";
                        break;
                }
                return result;
            }
        }
        public string LetterGrade
        {
            get
            {
                string result;
                if (averageGrade >= 90)
                {
                    result = "A";

                }
                else if (averageGrade >= 80)
                {
                    result = "B";
                }
                else if (averageGrade >= 70)
                {
                    result = "C";
                }
                else if (averageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
        public float averageGrade;
        public float highestGrade;
        public float lowestGrade;
    }
}
