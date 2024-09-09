﻿using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product>  products =await _context.Products.ToListAsync();
            return products;
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct( int id )
        {
            Product product = await _context.Products.FindAsync(id);
            return product;
        }
    }
}
