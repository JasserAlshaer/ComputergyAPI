﻿using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Interfaces;
using ComputergyAPI.Mappings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace ComputergyAPI.Services
{
    public class ProductsService : IProducts
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public ProductsService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }
        public async Task<ProductDTO> CreateProduct(ProductCreateDTO dto)
        {
            // take input from user
            // convert the ProductCreateDTO to Product
            // add the entity to the dbset
            // save changes

            var added = dto.ToProduct();
            await _computergyDbContext.Products.AddAsync(added);
            await _computergyDbContext.SaveChangesAsync();

            return added.ToProductDTO();
        }
        public async Task<bool> RemoveProduct(int id)
        {
            throw new Exception("Product not found.");
        }
        public async Task<ProductDTO> UpdateProduct(ProductUpdateDTO dto)
        {
            var product = _computergyDbContext.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
           
            product.ProductName= dto.ProductName;
            product.ProductDescription= dto.ProductDescription;
            product.Price=dto.Price;
            product.ImageUrl= dto.ImageUrl;
            product.Quantity=dto.Quantity;
            product.Category=dto.Category;
            product.Brand=dto.Brand;
            
            await _computergyDbContext.SaveChangesAsync();
            return product.ToProductDTO();
        }
        public async Task<List<ProductDTO>> GetAllProducts()
        { 
          return await _computergyDbContext.Products.Select(x=> x.ToProductDTO()).ToListAsync();

        }
        public async Task<ProductDTO?> GetOneProduct(int id)
        {
            var existing = await _computergyDbContext.Products.FindAsync(id);
            if (existing is null)
                return null;
            return new ProductDTO()
            {
                Id = existing.Id,
                ProductName = existing.ProductName,
                Price = existing.Price,
                ImageUrl = existing.ImageUrl,
                Category = existing.Category,
                Brand = existing.Brand
            };
        }
        public async Task<ProductDTO> SearchProduct(SearchInputProductsDTO input)
        {
            throw new Exception("Product not found.");
        }
    }
}
