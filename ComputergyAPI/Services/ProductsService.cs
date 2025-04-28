using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Interfaces;
using ComputergyAPI.Mappings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using ComputergyAPI.DTOs;

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
            var existing = await _computergyDbContext.Products.FindAsync(id);
            if (existing is null)
                return false;

            _computergyDbContext.Products.Remove(existing);
            await _computergyDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ProductDTO?> UpdateProduct(ProductUpdateDTO dto)
        {
            var product = _computergyDbContext.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (product == null)
            {
                return null;
            }
            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Quantity = dto.Quantity;
            product.Category = dto.Category;
            product.Brand = dto.Brand;

            await _computergyDbContext.SaveChangesAsync();
            return product.ToProductDTO();
        }
        public async Task<List<ProductDTO>> GetAllProducts(PaginationParameters pagination)
        {
            return await _computergyDbContext
              .Products
              .AsQueryable()
              .Skip((pagination.PageNumber - 1) * pagination.PageSize)
              .Take(pagination.PageSize)
              .Select(p => p.ToProductDTO())
              .ToListAsync();
        }
        public async Task<ProductDTO?> GetOneProduct(int id)
        {
            var existing = await _computergyDbContext.Products.FindAsync(id);
            if (existing is null)
                return null;
            return existing.ToProductDTO();
        }
        public async Task<List<ProductDTO>> SearchProduct(SearchInputProductsDTO input)
        {
            return await _computergyDbContext
                .Products
                .AsQueryable()
                .Where(p => p.ProductName.Contains(input.Name, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.ToProductDTO())
                .ToListAsync();
        }
    }
}
