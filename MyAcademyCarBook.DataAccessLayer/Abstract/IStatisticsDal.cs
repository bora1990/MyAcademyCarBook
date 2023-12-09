using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.Abstract
{
    public interface IStatisticsDal
    {
        int CarCount();

        decimal AverageCarPrice();

        string LastCarBrandName();

        string MaxPriceCar();
    }
}
