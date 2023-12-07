using FluentValidation;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.ValidationRules.ServiceValidation
{
    public class CreateServiceValidator : AbstractValidator<Service>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş geçemezsiniz !");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanını boş geçemezsiniz !");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen en az 3 karekter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz ");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Lütfen en az 10 karekter girişi yapınız");
            RuleFor(x => x.Description).MaximumLength(300).WithMessage("Lütfen en fazla 300 karakter giriniz ");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikon alanı boş geçilemez");
        }  //constructor varsa program.cs

    }
}
