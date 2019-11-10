using System.Linq;

namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private ISetController setController;
		private IFestivalController festivalController;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ISetController setController, 
            IFestivalController festivalController)
        {
            this.reader = reader;
            this.writer = writer;
            this.setController = setController;
            this.festivalController = festivalController;
        }

        public void Run()
		{
			while (true)
			{
				string input = this.reader.ReadLine();

				if (input == "END")
                {
                    break;
                }

                string result = this.ProcessCommand(input);

                this.writer.WriteLine(result);
			}

			string report = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

		public string ProcessCommand(string input)
		{
			string[] tokens = input.Split();

			string commandName = tokens[0];
			string[] parameters = tokens.Skip(1).ToArray();

            string result = null;

			if (commandName == "LetsRock")
			{
                result = this.setController.PerformSets();

				return result;
			}

			MethodInfo festivalControllerMethd = this.festivalController.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commandName);

            try
            {
                result = (string) festivalControllerMethd.Invoke(this.festivalController, new object[] { parameters });
            }
            catch (TargetInvocationException up)
            {
                result = $"ERROR: {up.InnerException.Message}";
            }


            ////try
            ////{
            //result = (string) festivalControllerMethd.Invoke(this.festivalController, new object[] { parameters });
            ////}
            ////catch (TargetInvocationException up)
            ////{
            ////             result = $"ERROR: {up.InnerException.Message}";
            ////         }


            return result;
		}
    }
}