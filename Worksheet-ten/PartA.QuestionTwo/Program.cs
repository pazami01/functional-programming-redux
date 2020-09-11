using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA.QuestionTwo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Enum.Parse<DayOfWeek>("Friday"));
            Console.WriteLine(Enum.Parse<DayOfWeek>("Freeday"));
        }
    }

    public static class Enum
    {
        public static Option<T> Parse<T>(string str) where T : struct 
            => System.Enum.TryParse<T>(str, out T result) ? Some(result) : None;
    }
}
