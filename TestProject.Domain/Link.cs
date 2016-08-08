using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestProject.Domain
{
  
    public class Link
    {
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortLink { get; set; }
        public DateTime DateCreated { get; set; }
        public int CountTransition { get; set; }
        [JsonIgnore]
        public UserProfile Owner { get; set; }
    }
}
