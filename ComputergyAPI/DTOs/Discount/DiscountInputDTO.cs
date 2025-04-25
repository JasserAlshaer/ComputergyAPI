namespace ComputergyAPI.DTOs.Discount
{
    public class DiscountInputDTO
    {



        public string Name { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ProductId { get; set; }

    }

}
