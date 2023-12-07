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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> TGetAllCarsWithStatusandBrandsandCategory()
        {
            return _carDal.GetAllCarsWithStatusandBrandsandCategory();
        }

        public void TDelete(Car entity)
        {
            _carDal.Delete(entity);
        }

       

        public Car TGetByID(int id)
        {
            if (id != null)
            {
                return _carDal.GetByID(id);
            }
            return _carDal.GetByID(0);
        }

        public List<Car> TGetListAll()
        {
            return _carDal.GetListAll();
        }

        public void TInsert(Car entity)  //bir takım filtrelemeler
        {
            if(entity.Year >= 2010)
            {
                _carDal.Insert(entity);
            }
        }

        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }

        public Car TGetByIdWithBrand(int id)
        {
            if (id != null)
            {
                return _carDal.GetByIdWithBrand(id);
            }
            return _carDal.GetByIdWithBrand(0);
        }
    }
}
