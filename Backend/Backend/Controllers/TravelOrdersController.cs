using Backend.Controllers.DTO;
using Backend.Filters;
using Backend.Logic.TravelOrdersLogic;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [LogFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class TravelOrdersController : ControllerBase
    {
        private readonly ITravelOrdersLogic _travelOrdersLogic;

        public TravelOrdersController(ITravelOrdersLogic travelOrdersLogic)
        {
            _travelOrdersLogic = travelOrdersLogic;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult> CreateTravelOrder([FromBody] NewTravelOrderDTO travelOrder)
        {
            if (travelOrder == null)
            {
                return BadRequest($"Incorect format!");

            }
            await _travelOrdersLogic.CreateTravelOrder(travelOrder.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public async Task<ActionResult<List<TravelOrderInfoDTO>>> GetTravelOrders()
        {
            var allTravelOrders = await _travelOrdersLogic.GetTravelOrders();

            var travelOrderDTOs = allTravelOrders.Select(x => TravelOrderInfoDTO.FromModel(x));

            return Ok(allTravelOrders);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelOrderInfoDTO>> GetTravelOrderByID(int id)
        {
            var travelOrder = await _travelOrdersLogic.GetTravelOrderByID(id);

            if (travelOrder is null)
            {
                return NotFound($"Travel order with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(TravelOrderInfoDTO.FromModel(travelOrder));
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTravelOrders(int id)
        {
            await _travelOrdersLogic.DeleteTravelOrder(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTravelOrders(int id, [FromBody] NewTravelOrderDTO updatedTravelOrder)
        {
            if (updatedTravelOrder == null)
            {
                return BadRequest();
            }

            await _travelOrdersLogic.UpdateTravelOrder(id, updatedTravelOrder.ToModel());

            return Ok();
        }
    }
}
