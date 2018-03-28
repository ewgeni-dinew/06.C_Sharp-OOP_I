using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class Sorter
    {
        public static List<T> Sort<T>(List<T> list)
        {
            return list.OrderBy(e => e).ToList();
        }
    }
}
