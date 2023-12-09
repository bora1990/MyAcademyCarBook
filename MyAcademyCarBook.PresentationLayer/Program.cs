using FluentValidation.AspNetCore;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.EntityFramework;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarBookContext>();

builder.Services.AddScoped<IBrandDal,EfBrandDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();

builder.Services.AddScoped<ICarDetailDal, EfCarDetailDal>();
builder.Services.AddScoped<ICarDetailService, CarDetailManager>();

builder.Services.AddScoped<ICarStatusDal,EfCarStatusDal>();
builder.Services.AddScoped<ICarStatusService,CarStatusManager>();

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IPriceDal,EfPriceDal>();  //constructor olarak geçilen sýnýflarýn üretimi
builder.Services.AddScoped<IPriceService,PriceManager>();

builder.Services.AddScoped<ICarDal, EfCarDal>();  
builder.Services.AddScoped<ICarService, CarManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IHowItWorksStepDal, EfHowItWorksStepDal>();
builder.Services.AddScoped<IHowItWorksStepService, HowItWorksStepManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutManager>();   

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IStatisticsDal,EfStatisticsDal>();
builder.Services.AddScoped<IStatisticsService, StatisticsManager>();


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CarBookContext>().AddErrorDescriber<CustomIdentityValidator>();




// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  //projede bir login iþlemi kullanýcaðý programa bildirildi.Sýrasý önemli -Kimlik Doðrulama

app.UseAuthorization();  //yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
