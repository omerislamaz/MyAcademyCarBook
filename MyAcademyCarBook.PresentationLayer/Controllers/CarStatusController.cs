using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarStatusController : Controller
    {
        private readonly ICarStatusService _carStatusService;

        public CarStatusController(ICarStatusService carStatusService)
        {
            _carStatusService = carStatusService;
        }

        public IActionResult Index()
        {
            var values = _carStatusService.TGetListAll();
            return View(values);
        }

        //CarStatus Oluşturma -1
        [HttpGet]
        public IActionResult CreateCarStatus()
        {
            return View();
        }

        //CarStatus Oluşturma -2
        [HttpPost]
        public IActionResult CreateCarStatus(CarStatus carStatus)
        {
            _carStatusService.TInsert(carStatus);
            return RedirectToAction("Index");
        }

        //CarStatus Silme
        public IActionResult RemoveCarStatus(int id)
        {
            var value = _carStatusService.TGetByID(id);
            _carStatusService.TDelete(value);
            return RedirectToAction("Index");
        }

        //CarStatus Güncelleme -1
        [HttpGet]
        public IActionResult UpdateCarStatus(int id)
        {
            var values = _carStatusService.TGetByID(id);
            return View(values);
        }

        //CarStatus Güncelleme -2
        [HttpPost]
        public IActionResult UpdateCarStatus(CarStatus carStatus)
        {
            _carStatusService.TUpdate(carStatus);
            return RedirectToAction("Index");
        }
    }
}
