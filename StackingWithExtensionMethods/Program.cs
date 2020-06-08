using System;
using System.Collections.Generic;
using System.Reflection;

namespace StackingWithExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //
            CustomConfiguration configuration = new CustomConfiguration("SomeValue").AddToQueue("this one", "that one").AddToQueue("hey hey", "ho ho");
            configuration.ShowAllConfigurationObjects();
        }
    }

    public class CustomConfiguration
    {
        public string Init { get; set; }
        private string This { get; set; }
        public Dictionary<string, string> Dictionary { get; }

        public CustomConfiguration(string init)
        {
            This = init;
            Dictionary = new Dictionary<string, string>();
        }

        public void ShowAllConfigurationObjects()
        {
            foreach (var item in Dictionary)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }

    }

    public static class CustomConfigurationExtensions
    {
        public static CustomConfiguration AddToQueue(this CustomConfiguration configurationClass, string first, string second)
        {
            try
            {
                configurationClass.Dictionary.Add(first, second);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            return configurationClass;
        }
    }
}