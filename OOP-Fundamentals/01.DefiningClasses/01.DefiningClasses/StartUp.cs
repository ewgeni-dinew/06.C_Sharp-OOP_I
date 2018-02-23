using System;


class StartUp
{
    static void Main(string[] args)
    {
        var num = int.Parse(Console.ReadLine());

        var family = new Family();

        for (int i = 0; i < num; i++)
        {
            var line = Console.ReadLine()
                .Split();

            var name = line[0];
            var age = int.Parse(line[1]);

            var currentPerson = new Person(name,age);

            family.AddMember(currentPerson);
        }
        family.GetPeopleOlderThan_30();
    }
}

