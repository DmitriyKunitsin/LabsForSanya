﻿using CQRS.Commands;
using CQRS.Handlers;
using CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
            return CreatedAtAction("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }
    }
}
