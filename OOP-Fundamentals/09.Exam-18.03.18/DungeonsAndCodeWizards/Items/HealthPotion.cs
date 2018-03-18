using Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Items
{
    public class HealthPotion : Item
    {
        public override string Name => "HealthPotion";

        public HealthPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
            if (character.Health>character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
            
        }
    }
}
