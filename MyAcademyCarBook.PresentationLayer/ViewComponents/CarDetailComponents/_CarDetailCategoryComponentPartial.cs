using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
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
            var values = _categoryService.TGetListAll();
            return View(values);
        }
    }
}
