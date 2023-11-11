using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class Price
    {
        public int PriceID { get; set; }

        public int CarID { get; set; }  //Bu arabanın özelliklerine göre fiyatı

        public Car Car { get; set; }

        public string PriceType  { get; set; }

        public decimal PriceValue { get; set; }


    }
}
