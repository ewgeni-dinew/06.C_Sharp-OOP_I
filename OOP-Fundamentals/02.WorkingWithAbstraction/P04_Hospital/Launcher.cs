using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher{
    public static void Main()
    {
        var doctorList = new Dictionary<string, List<string>>();
        var departmentList = new Dictionary<string, List<List<string>>>();
        
        string command = Console.ReadLine();

        while (command != "Output")
        {
            var line = command.Split();

            var departament = line[0];
            var doctorName = line[1]+" "+ line[2];
            var patient = line[3];

            if (!doctorList.ContainsKey(doctorName))
            {
                doctorList[doctorName] = new List<string>();
            }
            if (!departmentList.ContainsKey(departament))
            {
                departmentList[departament] = new List<List<string>>();
                for (int stai = 0; stai < 20; stai++)
                {
                    departmentList[departament].Add(new List<string>());
                }
            }

            bool validRoom = departmentList[departament].SelectMany(x => x).Count() < 60;
            if (validRoom)
            {
                int room = 0;
                doctorList[doctorName].Add(patient);
                for (int i = 0; i < departmentList[departament].Count; i++)
                {
                    if (departmentList[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departmentList[departament][room].Add(patient);
            }

            command = Console.ReadLine();
        }

        command = Console.ReadLine();

        while (command != "End")
        {
            var line = command.Split();
            var depName = line[0];

            if (line.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departmentList[depName].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (line.Length == 2 && int.TryParse(line[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departmentList[depName][room - 1].OrderBy(x => x)));
            }
            else
            {
                var doctorName = line[0] + " " + line[1];
                Console.WriteLine(string.Join("\n", doctorList[doctorName].OrderBy(x => x)));
            }
            command = Console.ReadLine();
        }
    }
}

