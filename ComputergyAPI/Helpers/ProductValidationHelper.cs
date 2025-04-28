using System.Numerics;

namespace ComputergyAPI.Helpers
{
    public static  class ProductValidationHelper
    {
        public static bool ISValidProductName(string Name)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name) || Name.Length > 50)
                throw new Exception("  Name is required and should not be more than 50 characters.");

            foreach (char c in Name)
            {
                if (!char.IsLetter(c))
                    throw new Exception(" Name should contain only English letters ");
            }

            return true;
        }



        public static bool IsValidPrice(float Price)
        {

            if (Price <= 0)

                throw new Exception("Price should be grater than zero");

            return true;

        }

        public static bool IsValidQuentity(int Quantity)
        {

            if (Quantity <= 0)

                throw new Exception("Quantity should be grater than zero");

            return true;

        }

        public static bool ISValidFullCategory(string Category)
        {
            if (string.IsNullOrWhiteSpace(Category) || Category.Length > 100)
                throw new Exception("Category is required and should not be more than 100 characters.");

            foreach (char c in Category)
            {
                if (!char.IsLetter(c) && c != ' ')
                    throw new Exception("Category should contain only English letters and spaces.");
            }

            return true;
        }


        public static bool ISValidBrand(string Brand)
        {
            if (string.IsNullOrWhiteSpace(Brand) || Brand.Length > 100)
                throw new Exception("Brand is required and should not be more than 100 characters.");

            foreach (char c in Brand)
            {
                if (!char.IsLetter(c) && c != ' ')
                    throw new Exception("Brand should contain only English letters and spaces.");
            }

            return true;
        }

    }
}
