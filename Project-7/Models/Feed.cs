using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_5.Models
{
    public class Feed
    {

        public string @version { get; set; }
        public string @Xmlns { get; set; }
        public string title { get; set; }
        public string tagline { get; set; }
        public string fullcount { get; set; }
        public Link link { get; set; }
        public DateTime modified { get; set; }
        public List<Entry> entry { get; set; }
    }
}