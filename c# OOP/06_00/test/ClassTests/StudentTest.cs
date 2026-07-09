using System;

namespace test
{
    public class StudentTest
    {
        [TestClass]
        [TestCategory("Models")]
        public class StudentTests
        {
            [TestMethod]
            public void Student_EmptyConstructor_CreatesInstanceWithEmptyValues()
            {
                Student student = new Student();
                Assert.IsNotNull(student);
                Assert.AreEqual(string.Empty, student.Naam);
                Assert.AreEqual(0, student.Punten);
                Assert.AreEqual("Niet geslaagd!", student.Resultaat);
            }

            [TestMethod]
            public void Student_Constructor_CreatesInstanceWithCorrectValues()
            {
                Student student = new Student("Matthias", 75);
                Assert.IsNotNull(student);
                Assert.AreEqual("Matthias", student.Naam);
                Assert.AreEqual(75, student.Punten);
                Assert.AreEqual("Geslaagd!", student.Resultaat);
            }

            [TestMethod]
            public void Student_ToString_ReturnsCorrectString()
            {
                Student student = new Student("Joren", 80);
                string output = student.ToString().ToLower();
                StringAssert.Contains(output, "joren");
                StringAssert.Contains(output, "80");
                StringAssert.Contains(output, "geslaagd!");
            }
        }
    }
}