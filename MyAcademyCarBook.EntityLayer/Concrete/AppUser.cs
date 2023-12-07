using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>  //id si string mi int mi
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? City { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public List<CarDetail> CarDetails { get; set; }  //bir kullanıcı birden fazla cardetail yazabilir.
    }
}
