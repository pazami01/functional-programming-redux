using System;
using System.Collections.Specialized;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA.QuestionFive
{
    public class AppConfig
    {
        NameValueCollection source;

        public AppConfig() : this(ConfigurationManager.AppSettings) { }

        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }

        public Option<T> Get<T>(string name)
            => source[name] == null ? None
            : Some((T) Convert.ChangeType(source[name], typeof(T)));

        public T Get<T>(string name, T defaultValue)
            => Get<T>(name).Match(
                None: defaultValue,
                Some: value => value
                );
    }

    public static class ConfigurationManager
    {
        public static NameValueCollection AppSettings
        {
            get
            {
                var nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("FirstName", "Jeff");
                nameValueCollection.Add("LastName", "Smith");
                nameValueCollection.Add("Nationality", "British");
                nameValueCollection.Add("Religion", "Atheist");

                return nameValueCollection;
            }
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var appConfig = new AppConfig();

            Console.WriteLine(appConfig.Get<string>("FirstName"));
            Console.WriteLine(appConfig.Get("FirstName", "John"));

            Console.WriteLine(appConfig.Get<int>("DOB"));
            Console.WriteLine(appConfig.Get("DOB", 1990));

            Console.WriteLine(appConfig.Get<DateTime>("Time"));
            Console.WriteLine(appConfig.Get("Time", DateTime.Now));
        }
    }
}
