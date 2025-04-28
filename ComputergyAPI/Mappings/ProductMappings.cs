using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Entites;

namespace ComputergyAPI.Mappings
{
    public static class ProductMappings
    {
        public static ProductDTO ToProductDTO(this Product entity)
        {
            return new ProductDTO()
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Category = entity.Category,
                Brand = entity.Brand
            };
        }

        public static Product ToProduct(this ProductCreateDTO entity)
        {
            return new Product ()
            {
                ProductName = entity.ProductName,
                ProductDescription = entity.ProductDescription,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Quantity = entity.Quantity,
                Category = entity.Category,
                Brand = entity.Brand
            };
        }
    }
}