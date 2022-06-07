using Microsoft.AspNetCore.Mvc;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.Interfaces;

namespace NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;

        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }


        /// <summary>
        /// Get all client
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get([FromBody] string clientid, [FromBody] string name)
        {
            var response = await _clientApplication.GetListByFilterAsync(clientid, name);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }


        /// <summary>
        /// Get Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var response = await _clientApplication.GetByIdAsync(id);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }

        // POST api/<ClientController>
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateClientRequest clientRequest)
        {
            var response = await _clientApplication.CreateAsync(clientRequest);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }


        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateClientRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateClientRequest updateClientRequest)
        {
            var response = await _clientApplication.UpdateAsync(updateClientRequest);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _clientApplication.DeleteAsync(id);

            if (response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            return Ok(response);
        }
    }
}