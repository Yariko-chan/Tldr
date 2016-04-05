using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tldr.DomainClasses.Abstract;
using Tldr.DomainClasses.Entities;

namespace Tldr.DomainClasses.Concrete
{
    public class CreativesRepository : ICreativeRepository
    {
        private CreativesDbContext context = new CreativesDbContext();

        public IEnumerable<Creative> Creatives
        {
            get { return context.Creatives; }
        }
    }
}
