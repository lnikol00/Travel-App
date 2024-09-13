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
        public ActionResult CreateTravelOrder([FromBody] NewTravelOrderDTO travelOrder)
        {
            if (travelOrder == null)
            {
                return BadRequest($"Incorect format!");

            }
            _travelOrdersLogic.CreateTravelOrder(travelOrder.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public ActionResult<IEnumerable<TravelOrderInfoDTO>> GetTravelOrders()
        {
            var allTravelOrders = _travelOrdersLogic.GetTravelOrders().Select(x => TravelOrderInfoDTO.FromModel(x));
            return Ok(allTravelOrders);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public ActionResult<TravelOrderInfoDTO> GetTravelOrderByID(int id)
        {
            var travelOrder = _travelOrdersLogic.GetTravelOrderByID(id);

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
        public ActionResult DeleteTravelOrders(int id)
        {
            _travelOrdersLogic.DeleteTravelOrder(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public ActionResult UpdateTravelOrders(int id, [FromBody] NewTravelOrderDTO updatedTravelOrder)
        {
            if (updatedTravelOrder == null)
            {
                return BadRequest();
            }

            _travelOrdersLogic.UpdateTravelOrder(id, updatedTravelOrder.ToModel());

            return Ok();
        }
    }
}
