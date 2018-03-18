using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Characters
{
    public abstract class Character
    {
        public virtual string Type { get; }
        private string name;
        public double BaseHealth { get; protected set; }
        private double health;
        public double BaseArmor { get; protected set; }
        private double armor;
        public double AbilityPoints { get; protected set; }
        public Bag Bag { get; set; }
        public bool IsAlive { get;  set; }
        public Faction Faction{get;}
        public virtual double RestHealMultiplier { get; protected set; }

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
            this.Faction = faction;
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    armor = this.BaseArmor;
                }
                else if (value <= 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }



        public double Health
        {
            get { return health; }
            set
            {
                if (value>this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                else if (value<=0)
                {
                    health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    health = value;
                }
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        //Methods
        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive==true)
            {
                var result = this.Armor - hitPoints;

                if (result<0)
                {
                    this.Armor = 0;
                    this.Health -= Math.Abs(result);
                    if (this.Health<=0)
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                }
                else
                {
                    this.Armor = result;
                }
            }
        }
        
        public void Rest()
        {
            if (this.IsAlive == true)
            {
                this.Health+=(this.BaseHealth*this.RestHealMultiplier);
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive==true)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                this.Bag.Items.Remove(item);
                character.Bag.AddItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
        }
    }
}
