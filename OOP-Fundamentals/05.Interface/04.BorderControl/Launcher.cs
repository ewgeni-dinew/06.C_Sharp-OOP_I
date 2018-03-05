using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    static void Main()
    {
        var humanoidList = new List<Humanoid>();
        var objList = new List<IBirthdate>();

        var count = int.Parse(Console.ReadLine());

        var buyerList = FillBuyerList(count);
        int food;
        
        while (true)
        {
            var input = Console.ReadLine();
            
            //Task 07.
            food = CalculateFood(buyerList,input);

            if (input.Equals("End"))
            {
                //Task 05.
                CheckEnding(humanoidList);

                //Task 06.
                CheckEndingYear(objList);
                break;
            }

            //Task 05. and 06.-->
            var args = input
                .Split();

            Humanoid humanoid = new Humanoid();
            IBirthdate currentObj;

            if (args[0].Equals("Robot"))
            {
                var model = args[0];
                var id = args[1];
                humanoid = new Robot(model, id);
            }

            else if (args[0].Equals("Citizen"))
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var id = args[3];
                var birth = DateTime.ParseExact(args[4], "dd/MM/yyyy", null);
                currentObj = new Person(name, id, age, birth);
                objList.Add(currentObj);
            }
            else if (args[0].Equals("Pet"))
            {
                var name = args[1];
                var birth = DateTime.ParseExact(args[2], "dd/MM/yyyy", null);
                currentObj = new Pet(birth, name);
                objList.Add(currentObj);
            }
            //<--
        }
        //Task 07.
        Console.WriteLine(food);
    }

    //Task 07->
    private static int CalculateFood(List<IBuyer> buyerList,string input)
    {
        foreach (var b in buyerList)
        {
            if (b.Name == input)
                b.BuyFood();
        }

        return buyerList.Sum(b => b.Food);
    }

    private static List<IBuyer> FillBuyerList(int count)
    {
        var buyerList = new List<IBuyer>();
        for (int i = 0; i < count; i++)
        {
            var args = Console.ReadLine()
                .Split();

            IBuyer buyer;

            if (args.Length == 3)
            {
                var name = args[0];
                var age = int.Parse(args[1]);
                var group = args[2];
                buyer = new Rebel(name, age, group);
                buyerList.Add(buyer);
            }
            else if (args.Length == 4)
            {
                var name = args[0];
                var age = int.Parse(args[1]);
                var id = args[2];
                var birth = DateTime.ParseExact(args[3], "dd/MM/yyyy", null);
                buyer = new Person(name, id, age, birth);
                buyerList.Add(buyer);
            }
        }
        return buyerList;
    }
    //<--

    //Task 06.
    private static void CheckEndingYear(List<IBirthdate> objList)
    {
        var year = int.Parse(Console.ReadLine());

        foreach (var obj in objList)
        {
            if (obj.Birthdate.Year==year)
                Console.WriteLine(obj.Birthdate.ToString("dd/MM/yyyy"));
        }
    }

    //Task 05.
    private static void CheckEnding(List<Humanoid> humanoids)
    {
        var ending = Console.ReadLine();

        foreach (Humanoid h in humanoids)
        {
            if (h.IdEndsInText(ending))
                Console.WriteLine(h.ReturnId());
        }
    }
}

