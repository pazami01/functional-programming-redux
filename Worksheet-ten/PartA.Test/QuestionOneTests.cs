using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartA.QuestionOne;

namespace PartA.Test
{
    [TestClass]
    public class QuestionOneTests
    {
        /* Testing Pure Functions */
        
        [TestMethod]
        public void calculateBmi_onePointSix_height_and_seventy_weight()
            => Assert.AreEqual(27.34, Bmi.CalculateBmi(1.6, 70), 0.01);

        [TestMethod]
        public void calculateBmi_onePointEightEight_height_and_eighty_weight()
            => Assert.AreEqual(22.63, Bmi.CalculateBmi(1.88, 80), 0.01);

        [TestMethod]
        public void convertToBmiCategory_eighteenPointFour()
            => Assert.AreEqual(BmiCategory.underweight, Bmi.ConvertToBmiCategory(18.4));

        [TestMethod]
        public void convertToBmiCategory_eighteenPointFive()
            => Assert.AreEqual(BmiCategory.healthy, Bmi.ConvertToBmiCategory(18.5));

        [TestMethod]
        public void convertToBmiCategory_twentyFourPointNine()
            => Assert.AreEqual(BmiCategory.healthy, Bmi.ConvertToBmiCategory(24.9));

        [TestMethod]
        public void convertToBmiCategory_twentyFive()
            => Assert.AreEqual(BmiCategory.overweight, Bmi.ConvertToBmiCategory(25));

        /* Testing Impure Functions */

        [TestMethod]
        public void run()
        {
            var height = 1.57;
            var weight = 75.5;
            BmiCategory actualBmiResult = default;

            double Read(string message) => message.Equals("Enter your height in metres:") ? height : weight;
            void Write(BmiCategory bmiCategory) => actualBmiResult = bmiCategory;

            Bmi.Run(Read, Write);

            Assert.AreEqual(BmiCategory.overweight, actualBmiResult);
        }
    }
}
