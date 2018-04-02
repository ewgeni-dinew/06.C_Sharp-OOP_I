using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;
        //private int index;

        public Stack()
        {
            this.collection = new List<T>();
        }

        public void Push(List<T> elements)
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                this.collection.Add(elements[i]);
            }
        }

        public void Pop()
        {
            if (this.HasNext())
            {
                this.collection.RemoveAt(0);
            }
            else
            {
                throw new ArgumentException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool HasNext()
        {
            if (!this.collection.Any())
            {
                return false;
            }
            return true;
        }
    }

