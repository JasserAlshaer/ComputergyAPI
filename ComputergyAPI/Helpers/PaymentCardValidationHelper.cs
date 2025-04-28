namespace ComputergyAPI.Helpers
{
    public class PaymentCardValidationHelper
    {
        public static bool IsValidCardNamber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                throw new Exception("Card number is required."); 


            if (cardNumber.Length < 13 || cardNumber.Length>19   )

                throw new Exception(" CardNumber should beetween 13 and 19");

            if (!cardNumber.All(char.IsDigit))
                throw new Exception("Card number must contain only digits.");

            return true;

        }


        public static bool ISValidCardHolder(string cardHolder)
        {
            if (string.IsNullOrEmpty(cardHolder) || string.IsNullOrWhiteSpace(cardHolder) || cardHolder.Length > 100)
                throw new Exception(" CardHolder is required and should not be more than 100 characters.");

            foreach (char c in cardHolder)
            {
                if (!char.IsLetter(c))
                    throw new Exception("CardHolder should contain only English letters ");
            }

            return true;
        }


        public static bool  IsValidExpirationDate (string expirationDate)
        {
            if (string.IsNullOrWhiteSpace(expirationDate))
                throw new Exception("Expiration date is required.");

            // condition of the year and month 
            return true;
        }



        public static bool IsValidCVC(string cvc)
        {
            if (string.IsNullOrWhiteSpace(cvc))
                throw new Exception("CVC is required.");

            if (cvc.Length != 3 && cvc.Length != 4)
                throw new Exception("CVC must be 3 or 4 digits long.");

            if (!cvc.All(char.IsDigit))
                throw new Exception("CVC must contain only digits.");

            return true;
        }


    }
}
