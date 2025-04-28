namespace ComputergyAPI.Helpers
{
    public class OrderValidationHelper
    {
        public static bool IsValidOrdaerDate(DateTime date)
        {
            if (date == default)
                throw new Exception("Order date is required.");

            
            if (date > DateTime.Today)
                throw new Exception("Order date cannot be in the future."); 

            return true;
        }

        public static bool IsValidTotalPrice( float totalPrice)
        {
            if (totalPrice <= 0)

                throw new Exception("Total Price should be grater than zero");

            return true;
        }




    }
}
