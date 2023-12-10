using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ICarService _carService;

        public CommentController(ICommentService commentService, ICarService carService)
        {
            _commentService = commentService;
            _carService = carService;
        }


        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            Comment value = new Comment()
            {
                NameSurname = comment.NameSurname,
                Description = comment.Description,
                CarID = comment.CarID,
                CreatedDate=DateTime.Now,

            };

            _commentService.TInsert(value);

            var carId= _commentService.TGetListAll().Where(x => x.CarID == comment.CarID).Select(y => y.CarID).FirstOrDefault();

            return RedirectToAction("CarDetail", "Car", new { id = carId });
        }



        public IActionResult Index()
        {
            var values=_commentService.TGetCommentIncludeCar();
            return View(values);
        }




        public IActionResult RemoveComment(int id)
        {
            var value = _commentService.TGetByID(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");

        }

        public IActionResult CreateAComment()
        {
            List<SelectListItem> c=(from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()

                                    select new SelectListItem
                                    {
                                        Text = x.Brand.BrandName +" " +x.Model,
                                        Value = x.CarID.ToString()
                                    }

                                    ).DistinctBy(x=>x.Text).ToList();

            ViewBag.car = c;
            return View();

        }

        [HttpPost]

        public IActionResult CreateAComment(Comment comment)
        {
            _commentService.TInsert(comment);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateComment(int id)
        {
            List<SelectListItem> c = (from x in _carService.TGetAllCarsWithStatusandBrandsandCategory()

                                      select new SelectListItem
                                      {
                                          Text = $"{x.Brand.BrandName} {x.Model}",
                                          Value = x.CarID.ToString()
                                      }

                                      ).DistinctBy(x => x.Text).ToList();

            ViewBag.car = c;

            var value=_commentService.TGetByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentService.TUpdate(comment);

            return RedirectToAction("Index");

        }





    }
}
