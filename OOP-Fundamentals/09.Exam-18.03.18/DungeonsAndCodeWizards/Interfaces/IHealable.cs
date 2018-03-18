using Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
