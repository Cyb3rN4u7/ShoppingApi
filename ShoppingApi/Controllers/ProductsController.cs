﻿using ShoppingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Green Matter Keyboard", Category = "Electronics", Price = 60},
            new Product {Id = 2, Name = "Red Monster Cereal", Category = "Food", Price = 9.99M},
            new Product {Id = 3, Name = "Plastic Box", Category = "House", Price = 12.99M},
            new Product {Id = 4, Name = "Weird Mouse", Category = "Electronics", Price = 12.99M},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("searchCategory/{category}")]
        public ActionResult<IEnumerable<Product>> GetByCategory(string category)
        {
            var productsFound = products.Where((p) => p.Category.ToLower() == category.ToLower());
            if (productsFound == null) return NotFound();
            return  Ok(productsFound);
        }
    }
}