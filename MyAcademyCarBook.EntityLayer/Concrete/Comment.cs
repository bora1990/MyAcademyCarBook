using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string NameSurname { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CarID { get; set; }  //Yorum hangi araca yapıldı.

        public Car Car { get; set; }
    }
}
