using Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Items
{
    public class PoisonPotion : Item
    {
        public override string Name => "PoisonPotion";

        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
            if (character.Health<=0)
            {
               character.Health = 0;
               character.IsAlive = false;
            }
        }
    }
}
