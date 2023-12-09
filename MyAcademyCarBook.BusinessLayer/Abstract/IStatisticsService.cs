using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Abstract
{
    public interface IStatisticsService
    {
        int TCarCount();

        decimal TAverageCarPrice();

        string TLastCarBrandName();

        string TMaxPriceCar();
    }
}
