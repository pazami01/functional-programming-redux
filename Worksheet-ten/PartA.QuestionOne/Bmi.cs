using System;

namespace PartA.QuestionOne
{
    public static class Bmi
    {
        public static void Main(string[] args)
        {
            Run(Read, Write);
        }

        // Impure function
        public static void Run(Func<string, double> read, Action<BmiCategory> write)
        {
            double height = read("Enter your height in metres:");
            double weight = read("Enter your weight in kg:");

            BmiCategory bmiCategory = CalculateBmi(height, weight).ConvertToBmiCategory();
            
            write(bmiCategory);
        }

        // Impure function
        public static double Read(string message)
        {
            Console.WriteLine(message);
            return double.Parse(Console.ReadLine());
        }

        // Impure function
        public static void Write(BmiCategory bmi) => Console.WriteLine($"Your BMI category is: {bmi}");

        // Pure function
        public static double CalculateBmi(double height, double weight)
            => Math.Round(weight / (Math.Pow(height, 2)), 2);

        // Pure function
        public static BmiCategory ConvertToBmiCategory(this double bmi)
            => (bmi < 18.5) ? BmiCategory.underweight
            : (bmi >= 25) ? BmiCategory.overweight
            : BmiCategory.healthy;
    }
}
