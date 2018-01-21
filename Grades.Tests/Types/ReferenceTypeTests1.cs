using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp1;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests1
    {

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook(); //Points to a completely new object.
            g1.Name = "Johns grade book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
