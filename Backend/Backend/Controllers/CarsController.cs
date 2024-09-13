using Backend.Controllers.DTO;
using Backend.Filters;
using Backend.Logic.CarsLogic;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [LogFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsLogic _carsLogic;

        public CarsController(ICarsLogic carsLogic)
        {
            _carsLogic = carsLogic;
        }

        // CREATE
        [HttpPost]
        public ActionResult CreateNewCar([FromBody] NewCarDTO cars)
        {
            if (cars == null)
            {
                return BadRequest($"Incorect format!");

            }
            _carsLogic.CreateNewCar(cars.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public ActionResult<IEnumerable<CarInfoDTO>> GetAllCars()
        {
            var allCars = _carsLogic.GetAllCars().Select(x => CarInfoDTO.FromModel(x));
            return Ok(allCars);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public ActionResult<CarInfoDTO> GetCarByID(int id)
        {
            var car = _carsLogic.GetCarByID(id);

            if (car is null)
            {
                return NotFound($"Car with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(CarInfoDTO.FromModel(car));
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            _carsLogic.DeleteCar(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, [FromBody] NewCarDTO updatedCar)
        {
            if (updatedCar == null)
            {
                return BadRequest();
            }

            _carsLogic.UpdateCar(id, updatedCar.ToModel());

            return Ok();
        }
    }
}
