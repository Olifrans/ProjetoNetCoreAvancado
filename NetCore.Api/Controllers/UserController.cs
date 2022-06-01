﻿using Microsoft.AspNetCore.Mvc;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Request.Users;
using NetCore.Application.Interfaces;

namespace NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;
        public UserController(IUsersApplication usersApplication)
        {
            _usersApplication = usersApplication;
        }



        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUsersRequest usersRequest)
        {
            var response = await _usersApplication.CreateAsync(usersRequest);

            if(response.Reports.Any())
                return UnprocessableEntity(response.Reports);

            //return Created();
            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
