using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> collection;
        private int index = -1;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.HasNext()==true)
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (!this.collection.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.collection[this.index]);
        }

        public bool HasNext()
        {
            if (this.index+1>this.collection.Count-1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.collection));
        }
    }

