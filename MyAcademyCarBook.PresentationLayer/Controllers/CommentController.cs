using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            Comment value = new Comment()
            {
                NameSurname = comment.NameSurname,
                Description = comment.Description,
                CarID = comment.CarID

            };

            _commentService.TInsert(value);

            var carId= _commentService.TGetListAll().Where(x => x.CarID == comment.CarID).Select(y => y.CarID).FirstOrDefault();

            return RedirectToAction("CarDetail", "Car", new { id = carId });
        }

    }
}
