using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var trainerList = new List<Trainer>();

        var lines = Console.ReadLine();

        while (lines!= "Tournament")
        {
            var arr = lines.Split();

            var trainerName = arr[0];
            var pokemonName = arr[1];
            var pokemontElem = arr[2];
            var pokemonHealth = int.Parse(arr[3]);

            var currentPokemon = new Pokemon(pokemonName,pokemontElem,pokemonHealth);

            if (!trainerList.Any(t=>t.Name.Equals(trainerName)))
                trainerList.Add(new Trainer(trainerName));

            var trainer = trainerList.First(t => t.Name.Equals(trainerName));
            trainer.Pokemons.Add(new Pokemon(pokemonName, pokemontElem, pokemonHealth));

            lines = Console.ReadLine();
        }

        lines = Console.ReadLine();

        while (lines!="End")
        {
            var currentCommand = lines;

            foreach (var trainer in trainerList)
            {
                if (trainer.Pokemons.Any(p=>p.Element.Equals(currentCommand)))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                        pokemon.Health -= 10;

                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }

            lines = Console.ReadLine();
        }

        foreach (Trainer trainer in trainerList.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }

    }
}

