using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repo, IUnitFactory unitFactory)
            : base(data, repo, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                var result = $"{unitType} retired!";
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No such units in repository.",ex);
            }
        }
    }
}
