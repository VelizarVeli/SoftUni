using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Forum.Data
{
   public class DataMapper
   {
       private const string DATA_PATH = "../data/";
       private const string CONFIG_PATH = "config.ini";

       private const string DEFAULT_CONFIG =
           "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

       private static readonly Dictionary<string, string> config;

       static DataMapper()
       {
           Directory.CreateDirectory(DATA_PATH);
           config = LoadConfig(DATA_PATH + CONFIG_PATH);
       }

       public static void EnsureConfigFile(string configPath)
       {
           if (!File.Exists(configPath))
           {
               File.WriteAllText(configPath, DEFAULT_CONFIG);
           }
       }

       public static void EnsureFile(string path)
       {
           if (!File.Exists(path))
           {
               File.Create(path).Close();
           }
       }

       private static Dictionary<string, string> LoadConfig(string configPath)
       {
           EnsureConfigFile(configPath);

           var contents = ReadLines(configPath);

           var config = contents.Select(l => l.Split('=')).ToDictionary(t => t[0], t => DATA_PATH + t[1]);

           return config;
       }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

       private static void WriteLines(string path, string[] lines)
       {
           File.WriteAllLines(path,lines);
       }
    }
}
