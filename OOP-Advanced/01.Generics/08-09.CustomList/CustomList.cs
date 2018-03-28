using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomList<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public CustomList()
        {
            this.list = new List<T>();
        }
        
        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove(int index)
        {
            var element=this.list.ElementAt(index);

            this.list.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            return this.list.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var firstElement = this.list.ElementAt(index1);
            var secondElement = this.list.ElementAt(index2);

            this.list[index1] = secondElement;
            this.list[index2] = firstElement;
        }

        public int CountGreaterThan(T element)
        {
            return this.list.Count(e => e.CompareTo(element) > 0);
        }

        public T Min()
        {
            return this.list.Min(e=>e);
        }

        public T Max()
        {
            return this.list.Max(e=>e);
        }

        public void Print()
        {
            foreach (var item in this.list)
            {
                Console.WriteLine(item); 
            }
        }

        public void Sort()
        {
            this.list=Sorter.Sort(this.list);
        }
    }
}
