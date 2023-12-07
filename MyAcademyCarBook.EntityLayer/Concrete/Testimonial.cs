using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Imageurl { get; set; }

        public string DescriptionComment { get; set; }

    }
}
