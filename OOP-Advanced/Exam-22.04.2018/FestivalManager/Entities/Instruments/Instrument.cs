using System;

namespace FestivalManager.Entities.Instruments
{
	using Contracts;

	public abstract class Instrument : IInstrument
	{
        private double wear;

        public double Wear
        {
            get { return wear; }
            protected set
            {
                if (value<0)
                {
                    wear = 0;
                }
                else if (value>100)
                {
                    wear = 100;
                }
                else
                {
                    wear = value;
                }
            }
        }

		protected Instrument()
		{
			this.Wear = 100;
		}
        
		protected virtual int RepairAmount { get; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= 0;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
