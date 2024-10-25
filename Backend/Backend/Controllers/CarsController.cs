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
        public async Task<ActionResult> CreateNewCar([FromBody] NewCarDTO cars)
        {
            if (cars == null)
            {
                return BadRequest($"Incorect format!");

            }
            await _carsLogic.CreateNewCar(cars.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public async Task<ActionResult<List<CarInfoDTO>>> GetAllCars()
        {
            var allCars = await _carsLogic.GetAllCars();

            var carInfoDTOs = allCars.Select(x => CarInfoDTO.FromModel(x)).ToList();

            return Ok(allCars);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInfoDTO>> GetCarByID(int id)
        {
            var car = await _carsLogic.GetCarByID(id);

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
        public async Task<ActionResult> DeleteCar(int id)
        {
            await _carsLogic.DeleteCar(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCar(int id, [FromBody] NewCarDTO updatedCar)
        {
            if (updatedCar == null)
            {
                return BadRequest();
            }

            await _carsLogic.UpdateCar(id, updatedCar.ToModel());

            return Ok();
        }
    }
}
