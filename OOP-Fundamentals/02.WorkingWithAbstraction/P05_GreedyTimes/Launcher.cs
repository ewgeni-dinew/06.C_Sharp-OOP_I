using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    static void Main(string[] args)
    {
        var bagCapacity = long.Parse(Console.ReadLine());
        var data = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var productBag = new Dictionary<string, Dictionary<string, long>>();

        for (int i = 0; i < data.Length; i += 2)
        {
            var productName = data[i];
            var amount = long.Parse(data[i + 1]);

            var itemType = CheckItemType(productName);

            if (itemType == null)
                continue;
            
            else if (bagCapacity < productBag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                continue;

            bool productIsFalidForBag = true;
            var keyword = string.Empty;

            switch (itemType)
            {
                case "Gem":
                    keyword = "Gold";
                    productIsFalidForBag = ValidateProduct(productBag,itemType,keyword,amount);
                    if (!productIsFalidForBag)
                        continue;
                    break;

                case "Cash":
                    keyword = "Gem";
                    productIsFalidForBag = ValidateProduct(productBag,itemType,keyword,amount);
                    if (!productIsFalidForBag)
                        continue;
                    break;
            }

            if (!productBag.ContainsKey(itemType))
                productBag[itemType] = new Dictionary<string, long>();
            
            if (!productBag[itemType].ContainsKey(productName))
                productBag[itemType][productName] = 0;

            productBag[itemType][productName] += amount;
        }

        PrintToConsole(productBag);
    }

    private static void PrintToConsole(Dictionary<string, Dictionary<string, long>> productBag)
    {
        foreach (var product in productBag)
        {
            Console.WriteLine($"<{product.Key}> ${product.Value.Values.Sum()}");
            foreach (var kvp in product.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
        }
    }

    private static bool ValidateProduct(Dictionary<string, Dictionary<string, long>> productBag,
        string itemType, string keyword,long amount)
    {
        bool result = true;

        if (!productBag.ContainsKey(itemType))
        {
            if (productBag.ContainsKey(keyword))
            {
                if (amount > productBag[keyword].Values.Sum())
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
        }
        else if (productBag[itemType].Values.Sum() + amount > productBag[keyword].Values.Sum())
        {
            result = false;
        }

        return result;
    }

    private static string CheckItemType(string productName)
    {
        var result = string.Empty;

        if (productName.Length == 3)
        {
            result = "Cash";
        }
        else if (productName.ToLower().EndsWith("gem") && productName.Length >= 4) 
        {
            result = "Gem";
        }
        else if (productName.ToLower() == "gold")
        {
            result = "Gold";
        }
        else
        {
            result = null;
        }

        return result;
    }
}
