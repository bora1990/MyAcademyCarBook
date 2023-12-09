using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatisticsDal _statisticsDal;

        public StatisticsManager(IStatisticsDal statisticsDal)
        {
            _statisticsDal = statisticsDal;
        }

        public decimal TAverageCarPrice()
        {
            return _statisticsDal.AverageCarPrice();
        }

        public int TCarCount()
        {
            return _statisticsDal.CarCount();
        }

        public string TLastCarBrandName()
        {
            return _statisticsDal.LastCarBrandName();
        }

        public string TMaxPriceCar()
        {
            return _statisticsDal.MaxPriceCar();
        }
    }
}
