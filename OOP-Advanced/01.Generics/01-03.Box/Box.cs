using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class Box<T>
    {
        public T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            return $"{this.element.GetType().FullName}: {this.element}";
        }
    }
}
