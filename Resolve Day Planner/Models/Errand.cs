using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ResolveDayPlanner.Services;

namespace ResolveDayPlanner.Models
{
    public class Errand
    {
        public string Id { get; set; }
        public string ErrandTitle { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

    }
}