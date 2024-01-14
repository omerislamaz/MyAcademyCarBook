using FluentValidation.AspNetCore;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.EntityFramework;
using MyAcademyCarBook.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarBookContext>();

builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<IBrandService,BrandManager>();

builder.Services.AddScoped<ICarStatusDal,EfCarStatusDal>();
builder.Services.AddScoped<ICarStatusService, CarStatusManager>();

//ICarDal = Generic Yapýlarý tutuyor
//EfCarDal = GenericRepository tutuyor.

// 1- Constructor olarak geçilen Insterface'lerin Program.cs sayfasýnda Registerationlarýnýn yapýlmasý :
// 2- ICarDal, BusinessLayer Concrete CarManager içinde Constructor olarak kullanýldý.
// 3- ICarService, Controller'da Constructor olarak kullanýldý.
// 4- <> iþaretinin içindeki sað taraftaki ifadeler, EfCarDal ile CarManager, Ýnterfaceleri Kalýtým yolu ile alan sýnýflar
// 5- Örnek olarak, EfCarDal  ICarDal'ý kalýtým olarak aldý.  CarManager ICarService'i  kalýtým olarak aldý.
builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddScoped<ICarService, CarManager>();

builder.Services.AddScoped<IPriceDal, EfPriceDal>();
builder.Services.AddScoped<IPriceService, PriceManager>();

builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IHowItWorksStepDal, EfHowItWorksStepDal>();
builder.Services.AddScoped<IHowItWorksStepService, HowItWorksStepManager>();

builder.Services.AddScoped<ICarCategoryDal, EfCarCategoryDal>();
builder.Services.AddScoped<ICarCategoryService, CarCategoryManager>();

builder.Services.AddScoped<ICarDetailDal, EfCarDetailDal>();
builder.Services.AddScoped<ICarDetailService, CarDetailManager>();

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CarBookContext>().AddErrorDescriber<CustomIdentityValidator>();

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
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
