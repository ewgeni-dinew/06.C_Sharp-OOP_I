namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities;
    using IO.Contracts;
    
	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        Stage stage = new Stage();
        private IFestivalController festivalController;
        private ISetController setController; 

        public Engine(IReader reader, IWriter writer,IFestivalController festivalController, ISetController setController)
        {
            this.festivalController= festivalController;
            this.setController = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
		{
            string input;

            while (true)
            {
                input = reader.ReadLine();
                
                if (input == "END")
                    break;

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    var result = ex.InnerException.Message;

                    this.writer.WriteLine("ERROR: " + result);
                }
            }

            var end = this.festivalController.ProduceReport();
            
            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

		public string ProcessCommand(string input)
		{

            var tokens = input.Split(' ');

            var commandName = tokens[0];
            var parameters = tokens.Skip(1).ToArray();

            if (commandName == "LetsRock")
            {
                var finalResult = this.setController.PerformSets();
                return finalResult;
            }

            var festivalcontrolfunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            string a;

            a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parameters });

            return a;
        }
	}
}