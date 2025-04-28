namespace ComputergyAPI.Helpers
{
    public class DiscountValidationHelper
    {
        public static bool IsValidCode (string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new Exception("Card number is required.");


            if (code.Length < 4 || code.Length > 8)

                throw new Exception(" Code should beetween 13 and 19");


            return true;

        }


        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate == default || endDate == default)
                throw new Exception("Start date and end date are required.");

            if (startDate > endDate)
                throw new Exception("Start date must be before end date.");

            if (startDate < DateTime.Today)
                throw new Exception("Start date cannot be in the past.");

            return true;
        }


        public static bool IsValidLimitAmount(float amount)
        {
            if (amount <= 0)

                throw new Exception("Amount should be grater than zero");

            return true;
        }
    }
}
