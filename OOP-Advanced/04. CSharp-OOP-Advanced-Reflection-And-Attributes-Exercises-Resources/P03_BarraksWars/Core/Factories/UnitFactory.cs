namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;
    using Contracts;
    using P03_BarraksWars.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(m=>m.Name==unitType);

            if (model is null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }
            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is Not a Unit Type!");
            }

            var unit = (IUnit)Activator.CreateInstance(model);
            return unit;
        }
    }
}
