using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.Models
{
    public class CreativePart
    {
        public int CreativeId { set; get; }
        public int PartId { set; get; }
        public string PartName { set; get; }
        public string PartText { set; get; }

        public virtual Creative Creative { get; set; }
    }
}