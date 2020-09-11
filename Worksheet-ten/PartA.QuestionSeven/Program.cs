using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA.QuestionSeven
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Func<int, double> someFunc = x => x + 0.5;

            var somelist = new List<int>() { 1, 2, 3, 4, 5 };
            var newList = somelist.Map(someFunc);
            newList.ToList().ForEach(x => Console.Write($"{x} "));

            Console.WriteLine();

            var someOption = Some(14);
            var newOption = someOption.Map(someFunc);
            Console.WriteLine(newOption);
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ls, Func<T, R> func)
            => ls.Bind(x => List(func(x)));

        public static Option<R> Map<T, R>(this Option<T> option, Func<T, R> func)
            => option.Bind(x => Some(func(x)));
    }
}
