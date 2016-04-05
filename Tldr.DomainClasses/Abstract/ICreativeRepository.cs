using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tldr.DomainClasses.Entities;

namespace Tldr.DomainClasses.Abstract
{
    public interface ICreativeRepository
    {
        IEnumerable<Creative> Creatives { get; }
        
    }
}
