using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var value=_contactService.TGetByID(1);


         return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact2 contact) 
        {
            using(CarBookContext c=new CarBookContext())
            {
                c.Contacts2.Add(contact);
                c.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult Info(int id) 
        {
            var value= _contactService.TGetByID(id);

            return PartialView(value);
        }
    }
}
