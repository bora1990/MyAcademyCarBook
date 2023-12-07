using Microsoft.EntityFrameworkCore;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{
    public class EfCarDetailDal:GenericRepository<CarDetail>,ICarDetailDal
    {
        CarBookContext context = new CarBookContext();

        public CarDetail GetCarDetailWithAuthor(int id)
        {
        
            var values = context.CarDetails.Include(x => x.AppUser).Where(y => y.CarID == id).FirstOrDefault();

            return values;
        }

        public CarDetail GetCarDetailWithBrand(int id)
        {
            var values = context.CarDetails.Include(x => x.Car).ThenInclude(c => c.Brand).Where(z=>z.CarID==id).FirstOrDefault();

            return values;
            
        }

        public CarDetail GetDetailByCarID(int id)
        {
            var values = context.CarDetails.Where(x => x.CarID == id).FirstOrDefault();
            return values;
        }


    }
}
