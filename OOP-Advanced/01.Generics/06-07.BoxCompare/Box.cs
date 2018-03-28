using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class Box<T>
    {
        public T Element { get; }

        public Box(T element)
        {
            this.Element = element;
        }
        
        public bool Compare(T element)
        {
            var result = this.Element.ToString().CompareTo(element);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
