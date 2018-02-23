using System;
using System.Collections.Generic;
using System.Linq;


public class Family
{
    private List<Person> Members { get; set; }

    public Family()
    {
        this.Members = new List<Person>();
    }
    public void AddMember(Person member)
    {
        this.Members.Add(member);
    }
    public void GetOldestMember()
    {
        var result = Members.OrderByDescending(m => m.Age).FirstOrDefault();
        Console.WriteLine($"{result.Name} {result.Age}");
    }
    public void GetPeopleOlderThan_30()
    {
        foreach (var member in Members.Where(m=>m.Age>30).OrderBy(m=>m.Name))
        {
            Console.WriteLine($"{member.Name} - {member.Age}");
        }
    }
}
  
