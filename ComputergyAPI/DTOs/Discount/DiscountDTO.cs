namespace ComputergyAPI.DTOs.Discount
{
    public class DiscountDTO
    {
        public string Title { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Code { get; set; }
    }
}
