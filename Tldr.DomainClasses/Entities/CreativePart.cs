using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.DomainClasses.Entities
{
    public class CreativePart:StateInfo
    {
        public int CreativeId { set; get; }
        public int CreativePartId { set; get; }
        public string PartName { set; get; }
        public string PartText { set; get; }

        public virtual Creative Creative { get; set; }
    }
}