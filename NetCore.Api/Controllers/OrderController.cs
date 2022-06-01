using Microsoft.AspNetCore.Mvc;
using NetCore.Application.DataContract.Request.Orders;
using NetCore.Application.Interfaces;

namespace NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersApplication _ordersApplication;
        public OrderController(IOrdersApplication ordersApplication)
        {
            _ordersApplication = ordersApplication;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrdersRequest ordersRequest)
        {
            var response = await _ordersApplication.CreateAsync(ordersRequest);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            //return Created();
            return Ok(response);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}