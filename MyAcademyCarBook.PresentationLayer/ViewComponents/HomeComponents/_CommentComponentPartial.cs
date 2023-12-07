using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.HomeComponents
{
    public class _CommentComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentManager;

        public _CommentComponentPartial(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _commentManager.TGetListAll().Take(3).ToList();


            return View(values);
        }
    }
}
