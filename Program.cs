using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDb = new Database();

            myDb.Put("example", "foo");
            Console.WriteLine(myDb.Get("example"));
            myDb.Delete("example");
            Console.WriteLine(myDb.Get("example"));
            myDb.Delete("example");

            myDb.CreateTransaction("abc");
            myDb.Put("a", "foo", "abc");
            Console.WriteLine(myDb.Get("a", "abc")); // returns "foo"
            Console.WriteLine(myDb.Get("a")); // returns null

            myDb.CreateTransaction("xyz");
            myDb.Put("a", "bar", "xyz");
            Console.WriteLine(myDb.Get("a", "xyz")); // returns "bar"
            myDb.CommitTransaction("xyz");
            Console.WriteLine(myDb.Get("a")); // returns "bar"
            myDb.CommitTransaction("abc"); // failure
            Console.WriteLine(myDb.Get("a")); // returns "bar"
            myDb.CreateTransaction("abc");
            myDb.Put("a", "foo", "abc");
            Console.WriteLine(myDb.Get("a")); // returns "bar"
            myDb.RollbackTransaction("abc");
            myDb.Put("a", "foo", "abc"); // failure
            Console.WriteLine(myDb.Get("a")); // returns "bar"
            myDb.CreateTransaction("def");
            myDb.Put("b", "foo", "def");
            Console.WriteLine(myDb.Get("a", "def")); // returns "bar"
            Console.WriteLine(myDb.Get("b", "def")); // returns "foo"
            myDb.RollbackTransaction("def");
            Console.WriteLine(myDb.Get("b")); // returns null

        }
    }
}
