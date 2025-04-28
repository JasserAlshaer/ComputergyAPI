namespace ComputergyAPI.DTOs.Rating.Response
{
    public class GetRateDTO
    {
        public int PersonId { get; set; }
        public string? Message { get; set; }
        public int RateAmount { get; set; }
        public int OrderId { get; set; }
    }
}
