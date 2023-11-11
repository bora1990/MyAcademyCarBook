using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class HowItWorksStepManager : IHowItWorksStepService
    {
        private readonly IHowItWorksStepDal _stepdal;

        public HowItWorksStepManager(IHowItWorksStepDal stepdal)
        {
            _stepdal = stepdal;
        }

        public void TDelete(HowItWorksStep entity)
        {
            _stepdal.Delete(entity);
        }

        public HowItWorksStep TGetByID(int id)
        {
            return _stepdal.GetByID(id);
        }

        public List<HowItWorksStep> TGetListAll()
        {
            return _stepdal.GetListAll();
        }

        public void TInsert(HowItWorksStep entity)
        {
            _stepdal.Insert(entity);
        }

        public void TUpdate(HowItWorksStep entity)
        {
            _stepdal.Update(entity);
        }
    }
}
