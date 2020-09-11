using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA.QuestionNine
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
        {
            var employeesLeft = employees.Where(x => x.LeftOn.IsSome);

            double total = 0;

            employeesLeft.ToList().ForEach(employee => employee.LeftOn.Match(
                Some: leftOn => total += leftOn.Year - employee.JoinedOn.Year,
                None: () => 0
                ));

            return Math.Round(total / employeesLeft.Count(), 2);
        }
    }

    public struct WorkPermit
    {
        public string Number { get; set; }
        public DateTime Expire { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }

        public DateTime JoinedOn { get; }
        public Option<DateTime> LeftOn { get; }
    }
}
