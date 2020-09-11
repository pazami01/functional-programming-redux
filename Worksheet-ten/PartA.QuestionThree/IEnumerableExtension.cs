using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;
using System.Linq;

namespace PartA.QuestionThree
{
    public static class IEnumerableExtension
    {
        public static void Main(string[] args)
        {
            bool isOdd(int i) => i % 2 == 1;

            Console.WriteLine(new List<int>().Lookup(isOdd));
            Console.WriteLine(new List<int> { 1 }.Lookup(isOdd));
        }

        public static Option<T> Lookup<T>(this IEnumerable<T> ls, Func<T, bool> pred) => ls.Find(pred);

        // First version:

        //public static Option<T> Lookup<T>(this IEnumerable<T> list, Func<T, bool> pred)
        //{
        //    foreach (var item in list)
        //    {
        //        if (pred(item))
        //        {
        //            return Some(item);
        //        }
        //    }

        //    return None;
        //}
    }
}
