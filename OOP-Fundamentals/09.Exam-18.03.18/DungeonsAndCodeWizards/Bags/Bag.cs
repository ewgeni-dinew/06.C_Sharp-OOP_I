using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public abstract class Bag
    {
        public int Capacity { get; set; }
        public List<Item> Items { get;}
        public int Load => Items.Sum(i => i.Weight);
        
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item.Weight+this.Load>this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                this.Items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!this.Items.Any(i=>i.Name.Equals(name)))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            else
            {
                var element = this.Items.FirstOrDefault(i=>i.Name.Equals(name));
                this.Items.Remove(element);
                return element;
            }
        }
    }
}
