using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Interfaces;
using ComputergyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _productsService;

        public ProductController(IProducts productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters pagination)
        {
            try
            {
                return Ok(await _productsService.GetAllProducts(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var existing = await _productsService.GetOneProduct(id);
                return existing is null ? NotFound() : Ok(existing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchInputProductsDTO dto)
        {
            try
            {
                return Ok(await _productsService.SearchProduct(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ProductController(ProductsService _productsService)
        {
            this._productsService = _productsService;
        }


        [HttpPost]
        [Route("Create new Product")]
        public async Task<IActionResult> CreateNewProduct(ProductCreateDTO dto)
        {
            try
            {
                return Ok( _productsService.CreateProduct(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        [Route("Update Product")]

        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO dto)
        {
            try
            {
                return Ok(_productsService.UpdateProduct(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete Product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(_productsService.RemoveProduct(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}