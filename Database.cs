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
            Values[key] = new Data { Value = value, LastModifiedTime = DateTime.UtcNow};
        }

        public void Put(string key, string value, string transactionId)
        {
            if(!Transactions.ContainsKey(transactionId))
            {
                Console.WriteLine($"Transaction {transactionId} is not found");
                return;
            }

            var transaction = Transactions[transactionId];

            transaction.Put(key, value);

        }

        public string Get(string key)
        {
            if(!Values.ContainsKey(key))
            {
                Console.WriteLine($"Database doesn't contain a value for key {key}");
                return null;
            }

            return Values[key].Value;
        }

        public string Get(string key, string transactionId)
        {
            if(!Transactions.ContainsKey(transactionId))
            {
                Console.WriteLine($"Transaction {transactionId} is not found");
                return null;
            }

            var transaction = Transactions[transactionId];

            return transaction.Get(key);
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

        public void Delete(string key, string transactionId)
        {
            if(!Transactions.ContainsKey(transactionId))
            {
                Console.WriteLine($"Transaction {transactionId} is not found");
            }

            var transaction = Transactions[transactionId];

            transaction.Delete(key);
        }

        public void CreateTransaction(string transactionId)
        {
            if(Transactions.ContainsKey(transactionId))
            {
                Console.WriteLine($"A transaction with id {transactionId} is already active");
                return;
            }

            var newTransaction = new Transaction
            {
                TransactionId = transactionId,
                TransactionCreatedTime = DateTime.UtcNow
            };

            Transactions.Add(transactionId, newTransaction);
        }

        public void RollbackTransaction(string transactionId)
        {
            if(!Transactions.ContainsKey(transactionId))
            {
                Console.WriteLine($"Transaction {transactionId} is not found");
                return;
            }

            Transactions.Remove(transactionId);
        }
    }
}