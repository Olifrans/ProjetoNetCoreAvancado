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

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="clientId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get([FromBody] string orderId, [FromBody] string clientId, [FromBody] string userId)
        {
            var response = await _ordersApplication.GetListByFilterAsync(orderId, clientId, userId);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ordersRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrdersRequest ordersRequest)
        {
            var response = await _ordersApplication.CreateAsync(ordersRequest);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            //return Created();
            return Ok(response);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}