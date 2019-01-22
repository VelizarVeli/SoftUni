namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            BlackBoxInteger blackBox = (BlackBoxInteger)Activator.CreateInstance(typeof(BlackBoxInteger), true);

            var input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                var args = input.Split('_');
                var methodName = args[0];
                var value = int.Parse(args[1]);

                ProcessCommand(blackBox, methodName, value);

                input = Console.ReadLine();
            }
        }

        private static void ProcessCommand(BlackBoxInteger blackBox, string methodName, int value)
        {
            MethodInfo method = typeof(BlackBoxInteger).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(blackBox, new object[] { value });

            FieldInfo field = typeof(BlackBoxInteger).GetField("innerValue", BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            int result = (int)field.GetValue(blackBox);

            Console.WriteLine(result);
        }
    }
}