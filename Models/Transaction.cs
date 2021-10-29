
using System.Collections.Generic;

namespace Assignment {
    public class Transaction 
    {
        public Dictionary<string, string> Requests { get; set; } = new Dictionary<string, string>();

        public string Id { get; set; }
    }
}

