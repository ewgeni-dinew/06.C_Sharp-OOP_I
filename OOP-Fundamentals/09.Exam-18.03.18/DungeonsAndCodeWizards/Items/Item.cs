using Models.Characters;
using System;

namespace Models
{
    public abstract class Item
    {
        public virtual string Name { get;}
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive==false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
