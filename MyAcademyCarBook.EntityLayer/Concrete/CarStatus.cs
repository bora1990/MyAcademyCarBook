using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class CarStatus  //Aracın Durumu nedir ? kiralanmış serviste müsait
    {
        public int CarStatusID { get; set; }

        public string CarStatusName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
