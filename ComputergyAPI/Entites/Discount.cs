namespace ComputergyAPI.Entites
{
    public class Discount:MainEntity
    {

   
        public string Code { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl{ get; set; }

        public int LimitUser { get; set; }

        public float LimitAmount { get; set; }
    }
}
