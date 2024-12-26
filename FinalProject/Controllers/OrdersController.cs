using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Interfaces;
using FinalProject.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddAsync(order);
                return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("total")]
        public async Task<ActionResult<decimal>> GetTotalOrderAmount()
        {
            var totalAmount = await _orderService.GetTotalOrderAmountAsync();
            return Ok(totalAmount);
        }
        [HttpGet("afterdate")]
        public async Task<ActionResult<List<Order>>> GetOrdersAfterDate([FromQuery] DateTime date)
        {
            var orders = await _orderService.GetOrdersAfterDateAsync(date);
            return Ok(orders);
        }

    }
}
