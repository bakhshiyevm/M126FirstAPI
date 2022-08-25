using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections;
using System.Collections.Generic;
using Services;

using Services.Abstract;
using DataAccess.Entities;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        [Route("getProducts")]
        public IActionResult Get()
        {

            try
            {
                var Products = _ProductService.Get();

                return Ok(Products);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }


        }



        [HttpGet]
        [Route("getProduct/{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var Product = _ProductService.Get(id);

            return Ok(Product);
        }



        [HttpPost]
        [Route("createProduct")]
        public IActionResult Create([FromBody] Product Product)
        {

            _ProductService.Create(Product);
            return Ok();
        }



        [HttpPut]
        [Route("updateProduct")]
        public IActionResult Update([FromBody] Product Product)
        {

            _ProductService.Update(Product);
            return Ok();
        }



        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            _ProductService.Delete(id);
            return Ok();
        }
    }
}
