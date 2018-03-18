using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new DungeonMaster();

            string line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                var array = line.Split(' ');

                if (array[0]== "IsGameOver")
                {
                    break;
                }
                try
                {
                    switch (array[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(engine.JoinParty(array.Skip(1).ToArray()));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(engine.AddItemToPool(array.Skip(1).ToArray()));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(engine.PickUpItem(array.Skip(1).ToArray()));
                            break;
                        case "UseItem":
                            Console.WriteLine(engine.UseItem(array.Skip(1).ToArray()));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(engine.UseItemOn(array.Skip(1).ToArray()));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(engine.GiveCharacterItem(array.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(engine.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(engine.Attack(array.Skip(1).ToArray()));
                            break;
                        case "Heal":
                            Console.WriteLine(engine.Heal(array.Skip(1).ToArray()));
                            break;
                        case "EndTurn":
                            Console.WriteLine(engine.EndTurn());
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: "+ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: "+ex.Message);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(engine.GetStats());
        }
    }
}
