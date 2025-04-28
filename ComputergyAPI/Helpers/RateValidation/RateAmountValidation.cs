using ComputergyAPI.Entites;

namespace ComputergyAPI.Helpers.RateValidation
{
    public static class RateAmountValidation
    {
        public static bool CheckRateAmount(int rate)
        {
         
            if (rate < 0 && rate > 5)
            {
                throw new Exception("Rate Must Be Grater Than 0 and Less Than 5");
            }
            return true;
            
        }
    }
}
