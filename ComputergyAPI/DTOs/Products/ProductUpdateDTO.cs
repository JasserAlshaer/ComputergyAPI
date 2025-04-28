namespace ComputergyAPI.DTOs.Products
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
