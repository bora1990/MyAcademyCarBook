using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        public List<Car> GetAllCarsWithStatusandBrandsandCategory()
        {
            var context = new CarBookContext();
            var values=context.Cars.Include(x=>x.Brand).Include(y=>y.CarStatus).Include(c=>c.Category).ToList();
            return values;
        }

        public Car GetByIdWithBrand(int id)
        {
            var context=new CarBookContext();
            var value=context.Cars.Include(x=>x.Brand).Where(z=>z.CarID==id).FirstOrDefault();

            return value;
        }
    }
}
