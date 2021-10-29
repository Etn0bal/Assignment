using System;
using System.Collections.Generic;

namespace Assignment 
{
    public class Database 
    {
        private Dictionary<string, Transaction> Transactions { get; } = new Dictionary<string, Transaction>();

        private Dictionary<string, Data> Values { get; } = new Dictionary<string, Data>();

        public void Put(string key, string value)
        {
            Values[key] = new Data { Value = value, LastModifiedTime = DateTime.Now};
        }

        public string Get(string key)
        {
            if(!Values.ContainsKey(key))
            {
                Console.WriteLine($"Database doesn't contain key {key}");
                return null;
            }

            return Values[key].Value;
        }

        public void Delete(string key)
        {
            if(!Values.ContainsKey(key))
            {
                Console.WriteLine($"Couldn't delete {key} because it isn't in the database");
                return;
            }

            Values.Remove(key);
        }
    }
}