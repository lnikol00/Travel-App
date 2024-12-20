using Microsoft.AspNetCore.Mvc;
using WebApp.WebUI.DAL.Models;
using WebApp.WebUI.Infrastructure.Interface;

namespace WebApp.WebUI.Controllers
{
    public class CarsController : Controller
    {
        private IRepository repository;

        public CarsController(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var data = (await repository.GetAllAsync<Cars>(includeProperties: "", orderBy: x => x.OrderBy(p => p.Id))).ToList();

            return View(data);
        }


        public async Task<IActionResult> EditCreate(int? id)
        {
            if (id.HasValue)
            {
                var car = await repository.GetByIdAsync<Cars>(id);
                return View(car);
            }
            else
            {
                return View(new Cars());
            }
        }

        [HttpPost]

        public async Task<IActionResult> EditCreate(Cars car)
        {
            if (car.Id > 0)
            {
                var exists = await repository.GetByIdAsync<Cars>(car.Id);
                exists.Name = car.Name;
                exists.Registration = car.Registration;

                repository.Update<Cars>(exists);
                await repository.SaveAsync();
                TempData["success"] = "Car has been updated successfully";
            }
            else
            {
                repository.Create<Cars>(car);
                await repository.SaveAsync();
                TempData["success"] = "New car has been created successfully";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Cars car = await repository.GetByIdAsync<Cars>(id);
            return PartialView("Delete", car);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Cars car = await repository.GetByIdAsync<Cars>(id);

            TravelOrder travelOrder = await repository.GetOneAsync<TravelOrder>(x => x.CarsId == id);

            bool isCarInTravelOrder = false;

            if (travelOrder != null)
            {
                isCarInTravelOrder = true;
            }

            if (isCarInTravelOrder)
            {
                TempData["error"] = "Cannot delete this car! Active travel order exists";
            }
            else
            {
                repository.Delete(car);
                await repository.SaveAsync();
                TempData["success"] = "Car deleted successfuly";
            }


            return RedirectToAction("Index");
        }
    }
}
