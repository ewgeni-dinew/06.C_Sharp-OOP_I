using System;

namespace _08.FibunacciRecurs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNum = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibunacci(inputNum));

        }

        public static long GetFibunacci(int n)
        {
            if (n<=2)
            {
                return 1;
            }
            else
            {
                return GetFibunacci(n - 1) + GetFibunacci(n - 2);
            }
        }
    }
}
