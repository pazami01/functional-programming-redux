using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA.QuestionEight
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var employees = new Dictionary<string, Employee>();
            employees.Add("1", new Employee(new WorkPermit()));
            employees.Add("2", new Employee(new WorkPermit() { HasExpired = true }));

            Console.WriteLine(GetWorkPermit(employees, "1"));
            Console.WriteLine(GetWorkPermit(employees, "2"));
            Console.WriteLine(GetWorkPermit(employees, "3"));
        }

        public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
            => people.Lookup(employeeId)
            .Bind(x => x.Permit.HasExpired ? None : Some(x.Permit));

        public static Option<V> Lookup<K, V>(this Dictionary<K, V> dict, K key)
            => dict.TryGetValue(key, out V value) ? Some(value) : None;
    }

    public class Employee
    {
        public WorkPermit Permit { get; set; }

        public Employee(WorkPermit permit)
        {
            Permit = permit;
        }
    }

    public class WorkPermit
    {
        public DateTime ExpiryDate { get; set; }
        public bool HasExpired { get; set; }
    }
}
