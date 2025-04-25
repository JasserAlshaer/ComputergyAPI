namespace ComputergyAPI.Entites
{
    public class Order : MainEntity
    {
        public int PersonID { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string Address { get; set; }
        
        public int? PaymentMethodID { get; set; }
        public string PaymentType { get; set; }

        public int? DiscountID { get; set; }

        public int CartID { get; set; }
        public string Note { get; set; }
    }
}
