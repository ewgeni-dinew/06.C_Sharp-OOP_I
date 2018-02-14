using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class StartUp
    {
        static void Main()
        {
            var line = Console.ReadLine();

            var doctorPatients = new Dictionary<string, List<string>>();
            var departmentPatients = new Dictionary<string, List<string>>();

            while (line!="Output")
            {
                var args = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var department = args[0];
                var doctor = args[1]+" "+args[2];
                var patient = args[3];

                if (!doctorPatients.ContainsKey(doctor))
                {
                    doctorPatients[doctor] = new List<string>();
                    doctorPatients[doctor].Add(patient);
                }
                else
                {
                    if (doctorPatients[doctor].Count<60)
                        doctorPatients[doctor].Add(patient);
                }

                if (!departmentPatients.ContainsKey(department))
                {
                    departmentPatients[department] = new List<string>();
                    departmentPatients[department].Add(patient);
                }
                    
                else
                {
                    if (departmentPatients[department].Count < 60)
                        departmentPatients[department].Add(patient);
                }
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line!="End")
            {
                var args = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                if (args.Length == 1 && departmentPatients.ContainsKey(line))
                {
                    foreach (var value in departmentPatients[line])
                        Console.WriteLine(value);
                }

                else if (args.Length == 2 && doctorPatients.ContainsKey(args[0]+" "+args[1]))
                {
                    foreach (var kvp in doctorPatients[args[0] + " " + args[1]].OrderBy(e=>e))
                        Console.WriteLine(kvp);
                }

                else if (args.Length==2)
                {
                    var department = args[0];
                    var roomNum = int.Parse(args[1])-1;
                    var temp = new List<string>();

                    for (int i =0; i <=departmentPatients[department].Count; i++)
                    {
                        if (temp.Count==3)
                            break;
                        if (i/3==roomNum)
                            temp.Add(departmentPatients[department].ElementAt(i));
                    }
                    Console.WriteLine(string.Join(Environment.NewLine,temp.OrderBy(e=>e)));
                }
                line = Console.ReadLine();
            }
        }
    }
}
