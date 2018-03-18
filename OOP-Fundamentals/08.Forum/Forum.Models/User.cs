﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<int> PostIds { get; set; }

        public User(int id, string username, string pass)
        {
            this.Id = id;
            this.Username = username;
            this.Password = pass;
            this.PostIds = new List<int>();
        }

        public User(int id,string username,string pass,IEnumerable<int> posts)
        {
            this.Id = id;
            this.Username = username;
            this.Password = pass;
            this.PostIds = new List<int>(posts);
        }
    }
}
