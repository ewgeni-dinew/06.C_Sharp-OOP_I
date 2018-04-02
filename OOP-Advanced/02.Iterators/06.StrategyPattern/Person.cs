﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get;private set; }

        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}