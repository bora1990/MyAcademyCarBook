using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.ServiceComponents
{
    public class _HowItWorksStepCompenentPartial : ViewComponent
    {
        private readonly IHowItWorksStepService _howItStep;

        public _HowItWorksStepCompenentPartial(IHowItWorksStepService howItStep)
        {
            _howItStep = howItStep;
        }

        public IViewComponentResult Invoke()
        {
            var values = _howItStep.TGetListAll();
            return View(values);
        }
    }
}
