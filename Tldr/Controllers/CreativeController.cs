using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tldr.DomainClasses.Abstract;
using Tldr.DomainClasses.Entities;
using Tldr.DomainClasses.Concrete;
using Tldr.Models;

namespace Tldr.Controllers
{
    public class CreativeController : Controller
    {
        private ICreativeRepository repository = new CreativesRepository();
        private int PageSize = 3;

        public ViewResult List(int categoryId = 3, int page = 1)
        {
            CreativesListViewModel model = new CreativesListViewModel
            {
                Creatives = repository.Creatives
                .Where(c => c.Category.CategoryId == categoryId)
                .OrderBy(c => c.CreateDate)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Creatives.Where(c => c.Category.CategoryId == categoryId).Count()
                },
                CurrentCategoryId = categoryId
            };
            return View(model);
        }
    }
}