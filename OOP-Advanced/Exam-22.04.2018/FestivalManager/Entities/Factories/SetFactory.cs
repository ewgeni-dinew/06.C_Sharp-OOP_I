namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using Sets;
    using System.Runtime.CompilerServices;


    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var typo = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Single(t => t.Name == type);

            return (ISet)Activator.CreateInstance(typo, name);
		}
	}
}
