using Microsoft.AspNetCore.Identity;

namespace MyAcademyCarBook.PresentationLayer.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiredLower",
                Description = "Lütfen en az 1 küçük harf kullanın"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiredUpper",
                Description = "Lütfen en az 1 büyük harf kullanın"
            };

        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiredDigit",
                Description = "Lütfen en az 1 rakam kullanın"
            };

        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Lütfen en az {length} karakter girişi yapınız"
            };

        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Lütfen en az bir sembol giriniz"
            };

        }
    }
}
