using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{

    public class EfStatisticsDal : IStatisticsDal
    {

        CarBookContext _context = new CarBookContext();

        public decimal AverageCarPrice()
        {
            decimal value = _context.Prices.Average(x => x.PriceValue);

            return value;
        }

        public int CarCount()
        {
            int value = _context.Cars.Count();
            return value;
        }

        public string LastCarBrandName()
        {
            var value = _context.Cars.OrderByDescending(x => x.CarID).Select(y => y.Model).FirstOrDefault();
            return value;
        }

        public string MaxPriceCar()
        {
            decimal price = _context.Prices.Max(x => x.PriceValue);

            int ids = _context.Prices.Where(x => x.PriceValue == price).Select(y => y.CarID).FirstOrDefault();

            string model=_context.Cars.Where(x=>x.CarID == ids).Select(y=> y.Model).FirstOrDefault();   

            var id1=_context.Cars.Where(x=>x.Model==model).Select(y=>y.BrandID).FirstOrDefault();

            string brand = _context.Brands.Where(x => x.BrandID == id1).Select(y => y.BrandName).FirstOrDefault();

            string value = brand + " " + model;

            return value;
        }
    }
}
