﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.Models
{
    public class Tag
    {
        private ICollection<Creative> _creatives;

        public Tag()
        {
            _creatives = new List<Creative>();
        }

        public int TagId { get; set; }
        public string tagName { get; set; }

        public virtual ICollection<Creative> Creatives
        {
            get { return _creatives; }
            set { _creatives = value; }
        }
    }
}