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

//ICarDal = Generic Yap�lar� tutuyor
//EfCarDal = GenericRepository tutuyor.

// 1- Constructor olarak ge�ilen Insterface'lerin Program.cs sayfas�nda Registerationlar�n�n yap�lmas� :
// 2- ICarDal, BusinessLayer Concrete CarManager i�inde Constructor olarak kullan�ld�.
// 3- ICarService, Controller'da Constructor olarak kullan�ld�.
// 4- <> i�aretinin i�indeki sa� taraftaki ifadeler, EfCarDal ile CarManager, �nterfaceleri Kal�t�m yolu ile alan s�n�flar
// 5- �rnek olarak, EfCarDal  ICarDal'� kal�t�m olarak ald�.  CarManager ICarService'i  kal�t�m olarak ald�.
builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddScoped<ICarService, CarManager>();

builder.Services.AddScoped<IPriceDal, EfPriceDal>();
builder.Services.AddScoped<IPriceService, PriceManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CarBookContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
