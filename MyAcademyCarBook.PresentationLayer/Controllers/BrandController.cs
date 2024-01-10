using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var values = _brandService.TGetListAll();
            return View(values);
        }


        //Ekleme İşlemi -1 
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }


        //Ekleme İşlemi -2
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            _brandService.TInsert(brand);
            return RedirectToAction("Index");
        }


        //Silme İşlemi
        // Önce İd ile silinecek olan veriyi value değişkenine ata. Sonrasında Silme işlemini uygula
        public IActionResult DeleteBrand(int id)
        {
            var value=_brandService.TGetByID(id);
            _brandService.TDelete(value);
            return RedirectToAction("Index");
        }

        //Güncelleme İşlemi -1
        // Öncelikle güncellenecek veriyi İd yi value değişkenine ata veriyi ekrana getirttir.
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _brandService.TGetByID(id);
            return View(value);
        }


        //Güncelleme İşlemi -2
        // Value değişkenine atanan verinin güncellenmesini sağlar.
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            _brandService.TUpdate(brand);
            return RedirectToAction("Index");
        }
    }
}
