using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tldr.DomainClasses.Entities;

namespace Tldr.Models
{
    public class CreativesListViewModel
    {
        public IEnumerable<Creative> Creatives { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategoryId { get; set; }
    }
}