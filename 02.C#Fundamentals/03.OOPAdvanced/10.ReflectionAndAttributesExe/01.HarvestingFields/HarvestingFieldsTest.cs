namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            while (!command.Equals("HARVEST"))
            {
                FieldInfo[] fields;

                switch (command)
                {
                    case "private":
                        fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            if (!field.IsFamily)
                            {
                                PrintOutputLine(command, field);
                            }
                        }
                        break;
                    case "protected":
                        fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            if (field.IsFamily)
                            {
                                PrintOutputLine(command, field);
                            }
                        }
                        break;
                    case "public":
                        fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public);
                        foreach (var field in fields)
                        {
                            PrintOutputLine(command, field);
                        }
                        break;
                    case "all":
                        fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var field in fields)
                        {
                            var accessModifier = field.Attributes.ToString().ToLower();
                            if (accessModifier.Equals("family"))
                            {
                                accessModifier = "protected";
                            }
                            PrintOutputLine(accessModifier, field);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintOutputLine(string accessModifier, FieldInfo field)
        {
            var fieldType = field.FieldType.ToString().Split('.').Last();
            Console.WriteLine($"{accessModifier} {fieldType} {field.Name}");
        }
    }
}