namespace ComputergyAPI.DTOs.Rating.Request
{
    public class CreateRateDTO
    {
        public int PersonId { get; set; }
        public int OrderId { get; set; }
        public string Massege { get; set; }
        public int RateAmount { get; set; }
    }
}
