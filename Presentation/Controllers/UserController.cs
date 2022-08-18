using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<User> Get() 
        {
            List<User> users = new List<User>();

            users.Add(new User {Id=1,Name="Test" });
            users.Add(new User {Id=2,Name="Test2" });

            return users;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public User Get([FromRoute] int id)
        {
            var user = new User { Id = 1, Name = "Test" };

            return user;
        }

        [HttpPost]
        [Route("createUser")]
        public void Create([FromBody] User user)
        {

        }

        [HttpPut]
        [Route("updateUser")]
        public void Update([FromBody] User user)
        {

        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public void Delete([FromRoute] int id)
        {

        }
    }
}
