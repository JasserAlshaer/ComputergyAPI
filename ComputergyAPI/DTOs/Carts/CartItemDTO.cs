namespace ComputergyAPI.DTOs.Carts
{
    public class CartItemDTO
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public int? CartItemID { get; set; }
    }
}
