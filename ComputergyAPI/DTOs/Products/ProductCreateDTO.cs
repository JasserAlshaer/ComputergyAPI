﻿namespace ComputergyAPI.DTOs.Products
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductAmount { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
