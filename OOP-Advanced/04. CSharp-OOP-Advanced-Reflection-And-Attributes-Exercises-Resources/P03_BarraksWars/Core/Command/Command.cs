using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Command
{
    public abstract class Command : IExecutable
    {
        protected string[] Data { get; private set; }
        protected IRepository Repository { get; private set; }
        protected IUnitFactory UnitFactory { get; private set; }

        protected Command(string[] data,IRepository repo,IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repo;
            this.UnitFactory = unitFactory;
        }

        public abstract string Execute();
    }
}
