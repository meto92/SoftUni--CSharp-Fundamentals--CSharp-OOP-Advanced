namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
	using Entities.Contracts;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == type &&
                    typeof(ISet).IsAssignableFrom(t));

            if (setType == null)
            {
                throw new ArgumentException();
            }

            ISet set = (ISet) Activator.CreateInstance(setType, new object[] { name });

            return set;
		}
	}
}