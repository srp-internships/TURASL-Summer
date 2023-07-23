﻿using Microsoft.AspNetCore.Mvc;

namespace FrestyEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        { };
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            return Ok(Products);
        }
    }
}
