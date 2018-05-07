using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repo, IUnitFactory unitFactory) 
            : base(data, repo, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
