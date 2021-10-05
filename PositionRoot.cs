using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAlza
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PositionsMeta
    {
        public string href { get; set; }
        public List<string> rel { get; set; }
    }

    public class GestorUser
    {
        public PositionsMeta meta { get; set; }
    }

    public class ExecutiveUser
    {
        public PositionsMeta meta { get; set; }
    }

    public class People
    {
        public PositionsMeta meta { get; set; }
    }

    public class PositionItems
    {
        public PositionsMeta meta { get; set; }
    }

    public class RelatedPositions
    {
        public PositionsMeta meta { get; set; }
    }

    public class Hreflang
    {
        public string languageCode { get; set; }
        public string url { get; set; }
    }

    public class PlaceOfEmployment
    {
        public string name { get; set; }
        public object description { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string streetName { get; set; }
        public string postalCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Department
    {
        public string name { get; set; }
        public string seoName { get; set; }
        public string url { get; set; }
        public PositionsMeta meta { get; set; }
    }

    public class PositionRoot
    {
        public string name { get; set; }
        public string seoName { get; set; }
        public string url { get; set; }
        public string workplace { get; set; }
        public object boardEstimation { get; set; }
        public object level { get; set; }
        public bool forStudents { get; set; }
        public GestorUser gestorUser { get; set; }
        public ExecutiveUser executiveUser { get; set; }
        public People people { get; set; }
        public PositionItems positionItems { get; set; }
        public RelatedPositions relatedPositions { get; set; }
        public List<Hreflang> hreflangs { get; set; }
        public PlaceOfEmployment placeOfEmployment { get; set; }
        public Department department { get; set; }
        public PositionsMeta meta { get; set; }
    }


}
