namespace ComputergyAPI.DTOs.Order
{
    public class CreateUpdateOrderInputDTO
    {
        public int? OrderID { get; set; }
        public int PersonID { get; set; }
        public int CartID { get; set; }
        public string Note { get; set; }
        public string DiscountCode { get; set; }
    }
}
