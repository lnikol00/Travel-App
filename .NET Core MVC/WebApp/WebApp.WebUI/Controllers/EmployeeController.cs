using Microsoft.AspNetCore.Mvc;
using WebApp.WebUI.DAL.Models;
using WebApp.WebUI.Infrastructure.Interface;

namespace WebApp.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IRepository repository;

        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var data = (await repository.GetAllAsync<Employee>(includeProperties: "", orderBy: x => x.OrderBy(p => p.Id))).ToList();

            return View(data);
        }

        public async Task<IActionResult> EditCreate(int? id)
        {
            if (id.HasValue)
            {
                var employee = await repository.GetByIdAsync<Employee>(id);
                return View(employee);
            }
            else
            {
                return View(new Employee());
            }
        }

        [HttpPost]

        public async Task<IActionResult> EditCreate(Employee employee)
        {
            if (employee.Id > 0)
            {
                var exists = await repository.GetByIdAsync<Employee>(employee.Id);
                exists.Name = employee.Name;
                exists.LastName = employee.LastName;

                repository.Update<Employee>(exists);
                await repository.SaveAsync();
                TempData["success"] = "Employee has been updated successfully";
            }
            else
            {
                repository.Create<Employee>(employee);
                await repository.SaveAsync();
                TempData["success"] = "New employee has been added successfully";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await repository.GetByIdAsync<Employee>(id);
            return PartialView("Delete", employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Employee employee = await repository.GetByIdAsync<Employee>(id);

            TravelOrder travelOrder = await repository.GetOneAsync<TravelOrder>(x => x.EmployeeId == id);

            bool isEmployeeInTravelOrder = false;

            if (travelOrder != null)
            {
                isEmployeeInTravelOrder = true;
            }

            if (isEmployeeInTravelOrder)
            {
                TempData["error"] = "Cannot delete this employee! Active travel order exists";
            }
            else
            {
                repository.Delete(employee);
                await repository.SaveAsync();
                TempData["success"] = "Employee deleted successfuly";
            }

            return RedirectToAction("Index");
        }
    }
}
