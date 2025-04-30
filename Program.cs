using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using JsonUserApp.Models;

namespace JsonUserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== User Deserialization ===");

            string path = "Data/user.json";
            string json = File.ReadAllText(path);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}, Age: {user.Age}, City: {user.City}");
            }

            Console.WriteLine("\n=== User Types Deserialization ===");

            string typeJson = File.ReadAllText("Data/userTypes.json");

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            List<User> userTypes = JsonConvert.DeserializeObject<List<User>>(typeJson, settings);

            foreach (var user in userTypes)
            {
                Console.WriteLine($"{user.Name} ({user.GetType().Name}) from {user.City}");
            }
        }
    }
}
