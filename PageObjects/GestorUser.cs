using System.Collections.Generic;

namespace ProjectAlza
{
    public class GestorUserMeta
    {
        public string href { get; set; }
        public List<string> rel { get; set; }
    }

    public class GestorUserRoot
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string linkedInUrl { get; set; }
        public GestorUserMeta meta { get; set; }
    }
}
