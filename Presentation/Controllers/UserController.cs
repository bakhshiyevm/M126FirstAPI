using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using Services.Abstract;
using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getUsers")]
        [Authorize(Roles = "Test")]
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
        [Authorize(Roles = "Admin")]
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
        [Route("signIn")]
        [AllowAnonymous]
        public IActionResult SignIn([FromBody] UserDTO user)
        {
			try
			{
                var res = _userService.Login(user);
                if (res == null)
                {
                    return NotFound();
                }

                Authenticate(res);

                return Ok(user);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }

        }


        [HttpPost]
        [Route("SignOut")]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("createUser")]
        public IActionResult Create([FromBody] UserDTO user)
        {
			try
			{
                _userService.Create(user);
                return Ok();
            }
			catch (Exception e)
			{

                return Problem(e.Message);
			}

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


        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Music", "techno"),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin"),

            };


            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
