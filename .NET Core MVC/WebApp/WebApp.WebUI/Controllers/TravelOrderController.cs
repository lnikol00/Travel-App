using Microsoft.AspNetCore.Mvc;
using WebApp.WebUI.DAL.Models;
using WebApp.WebUI.Infrastructure.Interface;
using WebApp.WebUI.Models;

namespace WebApp.WebUI.Controllers
{
    public class TravelOrderController : Controller
    {
        private IRepository repository;

        public TravelOrderController(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var data = (await repository.GetAllAsync<TravelOrder>(includeProperties: "Employee,Cars", orderBy: x => x.OrderBy(p => p.Id))).ToList();

            return View(data);
        }


        public async Task<IActionResult> EditCreate(int? id)
        {
            if (id.HasValue)
            {
                var travelOrder = await repository.GetByIdAsync<TravelOrder>(id);
                return View(travelOrder);
            }
            else
            {
                return View(new TravelOrder());
            }
        }

        [HttpPost]

        public async Task<IActionResult> EditCreate(TravelOrder travelOrder)
        {
            if (travelOrder.Id > 0)
            {
                var exists = await repository.GetByIdAsync<TravelOrder>(travelOrder.Id);
                exists.CarsId = travelOrder.CarsId;
                exists.EmployeeId = travelOrder.EmployeeId;
                exists.Route = travelOrder.Route;
                exists.Mileage = travelOrder.Mileage;
                exists.Date = travelOrder.Date;

                repository.Update<TravelOrder>(exists);
                await repository.SaveAsync();
                TempData["success"] = "Travel order has been updated successfully";
            }
            else
            {
                repository.Create<TravelOrder>(travelOrder);
                await repository.SaveAsync();
                TempData["success"] = "New travel order has been added successfully";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TravelOrder travelOrder = await repository.GetByIdAsync<TravelOrder>(id);
            return PartialView("Delete", travelOrder);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            TravelOrder travelOrder = await repository.GetByIdAsync<TravelOrder>(id);

            repository.Delete(travelOrder);
            await repository.SaveAsync();
            TempData["success"] = "Travel Order deleted successfuly";

            return RedirectToAction("Index");
        }

        #region Get dropdowns
        public async Task<JsonResult> GetDropdownCars(int id)
        {
            var cars = await repository.GetAllAsync<Cars>();

            List<ListViewModel> items = new List<ListViewModel>();
            foreach (var car in cars)
            {
                items.Add(new ListViewModel
                {
                    text = string.Format("{0} - {1} {2}", car.Id, car.Name, car.Registration),
                    id = car.Id,
                    selected = (id == car.Id)
                });
            }
            return Json(items);
        }

        public async Task<JsonResult> GetDropdownEmployee(int id)
        {
            var employee = await repository.GetAllAsync<Employee>();

            List<ListViewModel> items = new List<ListViewModel>();
            foreach (var emp in employee)
            {
                items.Add(new ListViewModel
                {
                    text = string.Format("{0} - {1} {2}", emp.Id, emp.Name, emp.LastName),
                    id = emp.Id,
                    selected = (id == emp.Id)
                });
            }
            return Json(items);
        }
        #endregion

    }
}
