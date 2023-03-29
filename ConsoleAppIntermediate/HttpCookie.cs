using System;
using System.Collections.Generic;

namespace ConsoleAppIntermediate
{
    public class HttpCookie
    {
        private Dictionary<string, string> _cookies = new Dictionary<string, string>();
        public DateTime Expiry { get; set; }

        public string this[string key]
        {
            get { return _cookies[key]; }
            set { _cookies[key] = value; }
        }
    }
}