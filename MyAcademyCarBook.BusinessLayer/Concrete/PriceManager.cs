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
    public class PriceManager:IPriceService
    {
        private readonly IPriceDal _priceDal;

        public PriceManager(IPriceDal priceDal)
        {
            _priceDal = priceDal;
        }

        public void TDelete(Price entity)
        {
            _priceDal.Delete(entity);
        }

        public Price TGetByID(int id)
        {
            return _priceDal.GetByID(id);
        }

        public List<Price> TGetListAll()
        {
            return _priceDal.GetListAll();
        }

        public List<Price> TGetPricesWithCars()
        {
           return _priceDal.GetPricesWithCars();
        }

        public void TInsert(Price entity)
        {
          _priceDal.Insert(entity); 
        }

        public void TUpdate(Price entity)
        {
           _priceDal.Update(entity);    
        }
    }
}
