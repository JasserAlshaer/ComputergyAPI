namespace ComputergyAPI.Helpers
{
    public class CartitemValidationHelper
    {
        //Validate PersonId, CartId and ItemId to be greater than 0
        public static bool IsValidId(int id) 
        {
            if (id <= 0)
                throw new Exception("Id should be grater than zero");

            return true;
        }
        public static bool IsValidQuentity(int Quantity)
        {

            if (Quantity <= 0)
                throw new Exception("Quantity should be grater than zero");

            return true;

        }
        public static bool IsValidTotalPrice(float totalPrice)
        {
            if (totalPrice <= 0)
                throw new Exception("Total Price should be grater than zero");

            return true;
        }
    }
}
