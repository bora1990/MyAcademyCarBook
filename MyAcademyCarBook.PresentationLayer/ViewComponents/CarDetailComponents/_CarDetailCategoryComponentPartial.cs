using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;
using System.Security.AccessControl;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailCategoryComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CarDetailCategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {


            var context = new CarBookContext();
            var values = _categoryService.TGetListAll();

            var categories = (from category in values
                              select new CategoryViewModel
                              {
                                  CategoryName = category.CategoryName,
                                  CategoryCount= context.Cars.Count(car=>car.CategoryID==category.CategoryID),
                              }).ToList();

            return View(categories);
        }
    }
}
