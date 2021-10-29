
using System;
using System.Collections.Generic;

namespace Assignment {
    public class Transaction 
    {
        public Dictionary<string, Data> Requests { get; set; } = new Dictionary<string, Data>();

        public DateTime TransactionCreatedTime { get; set; }

        public string TransactionId { get; set; }

        public void Put(string key, string value)
        {
            Requests[key] = new Data { Value = value, LastModifiedTime = DateTime.UtcNow};
        }

        public string Get(string key)
        {
            if(!Requests.ContainsKey(key))
            {
                Console.WriteLine($"Transaction {TransactionId} doesn't contain a value with key {key}");
                return null;
            }

            return Requests[key].Value;
        }

        public void Delete(string key)
        {
            if(!Requests.ContainsKey(key))
            {
                Console.WriteLine($"Couldn't delete {key} because it isn't in the transaction {TransactionId}");
                return;
            }

            Requests.Remove(key);
        }
    }
}

