namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            var assembly = Assembly.GetCallingAssembly();

            var commandType = assembly
                .GetTypes()
                .FirstOrDefault(e=>e.Name.ToLower()==commandName+"command");

            if (commandType==null)
            {
                throw new ArgumentException("No such units in repository.");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} Is Not A Command!");
            }

            var method = typeof(IExecutable).GetMethods().First();

            var commandArgs = new object[] {data,this.repository,this.unitFactory };
            var instance = Activator.CreateInstance(commandType,commandArgs);

            try
            {
                result = (string)method.Invoke(instance, null);
                return result;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
