using Microsoft.AspNetCore.Mvc;
using NetCore.Application.DataContract.Request.Product;
using NetCore.Application.Interfaces;

namespace NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] CreateProductRequest productRequest)
        //{
        //    var response = await _productApplication.CreateAsync(productRequest);

        //    if (response.Reports.Any())
        //        return UnprocessableEntity(response.Reports);

        //    //return Created();
        //    return Ok(response);
        //}

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}