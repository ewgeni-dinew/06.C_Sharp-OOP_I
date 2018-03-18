using Models.Bags;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public override string Type => "Cleric";

        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                if (!this.Faction.Equals(character.Faction))
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }
                else
                {
                    character.Health +=this.AbilityPoints;
                }
            }
        }
    }
}
