using System;
using System.Collections.Generic;
using System.Linq;

namespace PartA.QuestionSix
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Func<int, double> someFunc = x => x + 1.5;

            var someSet = new HashSet<int>() { 1, 2, 3, 4, 5 };
            var newSet = someSet.Map(someFunc);
            newSet.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------------------");

            var someDict = new Dictionary<string, int>();
            someDict.Add("key1", 1);
            someDict.Add("key2", 2);
            someDict.Add("key3", 3);
            var newDict = someDict.Map(someFunc);
            newDict.Values.ToList().ForEach(x => Console.WriteLine(x));
        }

        public static ISet<TResult> Map<TSource, TResult>(this ISet<TSource> set, Func<TSource, TResult> func)
        {
            var newSet = new HashSet<TResult>();

            foreach (var item in set)
            {
                newSet.Add(func(item));
            }

            return newSet;
        }

        public static IDictionary<TKey, TResult> Map<TKey, TValue, TResult>
            (this IDictionary<TKey, TValue> dict, Func<TValue, TResult> func)
        {
            var newDict = new Dictionary<TKey, TResult>();

            foreach (var (key, value) in dict)
            {
                newDict[key] = func(value);
            }

            return newDict;
        }
    }
}
