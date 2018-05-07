 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            var fields = type
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            while (true)
            {
                var line = Console.ReadLine();

                if (line.Equals("HARVEST"))
                {
                    break;
                }

                switch (line)
                {
                    case "private":
                        Print(fields.Where(f=>f.IsPrivate));
                        break;
                    case "public":
                        Print(fields.Where(f => f.IsPublic));
                        break;
                    case "protected":
                        Print(fields.Where(f => f.IsFamily));
                        break;
                    case "all":
                        Print(fields);
                        break;
                }
            }
        }
        
        private static void Print(IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                var accessMod = field.Attributes.ToString().ToLower();
                if (accessMod.Equals("family"))
                {
                    accessMod = "protected";
                }
                Console.WriteLine($"{accessMod} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
