namespace ComputergyAPI.Helpers
{
    public class RateValidationHelper
    {
        public static bool IsValidRateAmount(int Rate)
        {

            if (Rate <= 0)

                throw new Exception("Rate should be grater than zero");

            return true;

        }


    }
}
