using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.DomainClasses.Entities
{
    public class Category:StateInfo
    {
        private ICollection<Creative> _creatives;

        public  Category()
        {
            _creatives = new List<Creative>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Creative> Creatives
        {
            get { return _creatives; }
            set { _creatives = value; }
        }
    }
}