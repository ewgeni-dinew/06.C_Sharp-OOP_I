using Models.Bags;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Characters
{
    public class Warrior : Character,IAttackable
    {
        public override string Type => "Warrior";
        public Warrior(string name, Faction faction) 
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                if (this.Equals(character))
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                else if (this.Faction.Equals(character.Faction))
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction.ToString()} faction!");
                }
                else
                {
                    character.TakeDamage(this.AbilityPoints);
                }
            }
        }
    }
}
