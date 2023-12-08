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
    public class EfPriceDal : GenericRepository<Price>, IPriceDal
    {
        public List<Price> GetPricesWithCars()
        {
            var context = new CarBookContext();
            var values=context.Prices.Include(x=>x.Car).ThenInclude(y=>y.Brand).ToList(); //price-car car--brand ilişkili
            return values;
        }

        


    }
}
