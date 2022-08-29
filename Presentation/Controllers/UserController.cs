using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using Services.Abstract;
using DataAccess.Entities;
using DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getUsers")]
        public IActionResult Get()
        {

            try
            {
                var users = _userService.Get();

                return Ok(users);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }


        }



        [HttpGet]
        [Route("getUser/{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var user = _userService.Get(id);
            if (user == null) 
            {
                return NotFound();
            }

            return Ok(user);
        }



        [HttpPost]
        [Route("createUser")]
        public IActionResult Create([FromBody] UserDTO user)
        {

            _userService.Create(user);
            return Ok();
        }



        [HttpPut]
        [Route("updateUser")]
        public IActionResult Update([FromBody] UserDTO user)
        {

            _userService.Update(user);
            return Ok();
        }



        [HttpDelete]
        [Route("deleteUser/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            _userService.Delete(id);
            return Ok();
        }
    }
}
