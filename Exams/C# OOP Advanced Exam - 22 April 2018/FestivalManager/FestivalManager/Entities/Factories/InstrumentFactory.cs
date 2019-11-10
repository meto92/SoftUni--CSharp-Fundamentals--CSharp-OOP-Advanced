namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type instrumentType = Assembly.GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == type &&
                    typeof(IInstrument).IsAssignableFrom(t));

            if (instrumentType == null)
            {
                throw new ArgumentException();
            }

            IInstrument instrume = (IInstrument) Activator.CreateInstance(instrumentType);

            return instrume;
        }
	}
}