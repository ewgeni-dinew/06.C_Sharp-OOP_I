using Models;
using Models.Characters;
using Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;

        public DungeonMaster()
        {
            this.items = new List<Item>();
            this.characters = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            if (faction != Faction.CSharp.ToString() && faction != Faction.Java.ToString())
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            else if (characterType != "Warrior" && characterType != "Cleric")
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
            else
            {
                Character obj;
                if (characterType.Equals("Warrior"))
                {
                    obj = new Warrior(name,Enum.Parse<Faction>(faction));
                }
                else
                {
                    obj = new Cleric(name, Enum.Parse<Faction>(faction));
                }
                characters.Add(obj);

                return $"{name} joined the party!";
            }
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            if (itemName!= "PoisonPotion" && itemName!= "HealthPotion" && itemName!= "ArmorRepairKit")
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
            else
            {
                Item obj;

                if (itemName.Equals("PoisonPotion"))
                {
                    obj = new PoisonPotion();    
                }
                else if (itemName.Equals("HealthPotion"))
                {
                    obj = new HealthPotion();
                }
                else
                {
                    obj = new ArmorRepairKit();
                }
                items.Add(obj);

                return $"{itemName} added to pool.";
            }

        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            if (!characters.Any(e=>e.Name.Equals(characterName)))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            else if (!items.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            else
            {
                var item = items.Last();
                items.Remove(item);
                var character = characters.FirstOrDefault(e => e.Name.Equals(characterName));
                character.ReceiveItem(item);

                return $"{characterName} picked up {item.Name}!";
            }
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = characters.FirstOrDefault(e => e.Name.Equals(characterName));

            if (character==null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            else
            {
                var item = character.Bag.Items.FirstOrDefault(e=>e.Name.Equals(itemName));

                if (!character.Bag.Items.Any())
                {
                    throw new InvalidOperationException("Bag is empty!");
                }
                else if (item==null)
                {
                    throw new ArgumentException($"No item with name {itemName} in bag!");
                }
                character.UseItem(item);

                return $"{characterName} used {itemName}.";
            }
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = characters.FirstOrDefault(e=>e.Name.Equals(giverName));
            var receiver = characters.FirstOrDefault(e=>e.Name.Equals(receiverName));

            if (giver==null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            else if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            else
            {
                var item = giver.Bag.Items.FirstOrDefault(e=>e.Name.Equals(itemName));

                if (item==null)
                {
                    throw new ArgumentException($"No item with name {itemName} in bag!");
                }

                giver.UseItemOn(item,receiver);
                return $"{giverName} used {itemName} on {receiverName}.";
            }

        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = characters.FirstOrDefault(e => e.Name.Equals(giverName));
            var receiver = characters.FirstOrDefault(e => e.Name.Equals(receiverName));

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            else if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            else
            {
                var item = giver.Bag.Items.FirstOrDefault(e => e.Name.Equals(itemName));

                if (item == null)
                {
                    throw new ArgumentException($"No item with name {itemName} in bag!");
                }

                giver.GiveCharacterItem(item, receiver);
                return $"{giverName} gave {receiverName} {itemName}.";
            }
        }

        public string GetStats()
        {
            var result = new List<string>();

            foreach (var ch in characters.OrderByDescending(c=>c.IsAlive)
                                                .ThenByDescending(c=>c.Health))
            {
                var line = $"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, ";
                if (ch.IsAlive)
                {
                    line += "Status: Alive";
                }
                else
                {
                    line += "Status: Dead";
                }

                result.Add(line);
            }

            return string.Join(Environment.NewLine, result);
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = characters.FirstOrDefault(c=>c.Name.Equals(attackerName));
            var receiver = characters.FirstOrDefault(c=>c.Name.Equals(receiverName));

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            else if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            else if (attacker.Type.Equals("Cleric"))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            else
            {
                Warrior war = (Warrior)attacker;
                war.Attack(receiver);

                if (!receiver.IsAlive)
                {
                    return $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!"
                        +Environment.NewLine+ $"{receiverName} is dead!";
                }
                else
                {
                    return $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
                }
            }
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = characters.FirstOrDefault(c => c.Name.Equals(healerName));
            var healReceiver = characters.FirstOrDefault(c => c.Name.Equals(healingReceiverName));

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            else if (healReceiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
            else if (healer.Type.Equals("Warrior"))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            else
            {
                Cleric cleric = (Cleric)healer;
                cleric.Heal(healReceiver);

                return $"{healer.Name} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healReceiver.Health} health now!";
            }
        }

        public string EndTurn()
        {
            var result = new List<string>();

            foreach (var ch in characters.Where(c=>c.IsAlive==true))
            {
                var healthBeforeRest = ch.Health;
                ch.Rest();
                var line = $"{ch.Name} rests ({healthBeforeRest} => {ch.Health})";
                result.Add(line);
            }
            return string.Join(Environment.NewLine, result);
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
