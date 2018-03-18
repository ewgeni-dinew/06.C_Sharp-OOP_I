using Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Items
{
    public class ArmorRepairKit : Item
    {
        public override string Name => "ArmorRepairKit";

        public ArmorRepairKit() 
            : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
