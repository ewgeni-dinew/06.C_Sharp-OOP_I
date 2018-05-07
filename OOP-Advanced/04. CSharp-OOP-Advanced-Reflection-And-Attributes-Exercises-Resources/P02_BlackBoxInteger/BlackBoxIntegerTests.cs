namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);

            var member = Activator.CreateInstance(classType,true);

            var methods = classType
                .GetMethods(BindingFlags.Static|BindingFlags.Instance
                            |BindingFlags.Public|BindingFlags.NonPublic);

            while (true)
            {
                var line = Console.ReadLine().Split('_').ToArray();

                if (line[0].Equals("END"))
                {
                    break;
                }

                var methodName = line[0];
                var param = int.Parse(line[1]);

                var currentMethod = methods.FirstOrDefault(m => m.Name.Equals(methodName));
                currentMethod.Invoke(member, new object[] { param });

                var boxInnerValue = classType.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).First();

                Console.WriteLine(boxInnerValue.GetValue(member));
            }
        }
    }
}
