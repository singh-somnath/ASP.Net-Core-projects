using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppIntermediate.API
{
    public class UserResult
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string odata_context { get; set; }
        public List<User> value { get; set; }
    }
}
