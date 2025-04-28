namespace ComputergyAPI.Helpers
{
    public static class PersonValidationHelper
    {



        public static bool ISValidFirstName(string FirstNmae )
        {
            if (string.IsNullOrEmpty(FirstNmae) || string.IsNullOrWhiteSpace(FirstNmae)  || FirstNmae.Length > 50)
                throw new Exception(" First Name is required and should not be more than 50 characters.");

            foreach (char c in FirstNmae )
            {
                if (!char.IsLetter(c) )
                    throw new Exception("First Name should contain only English letters ");
            }

            return true;
        }


        public static bool ISValidLastName(string LastName)
        {
            if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName)  || LastName.Length > 50)
                throw new Exception(" Last Name is required and should not be more than 50 characters.");

            foreach (char c in LastName)
            {
                if (!char.IsLetter(c) )
                    throw new Exception("Last Name should contain only English letters ");
            }

            return true;
        }


        public static bool IsValidEmail(string Email) {

            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception(" Email Is Required");

            int atIndex = Email.IndexOf('@');
            int dotIndex = Email.LastIndexOf('.');

            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex >= Email.Length - 2)
                throw new Exception("Email Is  Required");

            string domain = Email.Substring(atIndex + 1, dotIndex - atIndex - 1);
            string extension = Email.Substring(dotIndex + 1);

            if (domain.Length < 2 || extension.Length < 2)
                throw new Exception("Email Is  Required");

            foreach (char c in Email.Substring(0, atIndex))
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '%' && c != '+' && c != '-')
                    throw new Exception("Email Is  Required");
            }
            return true;
        }



        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) && password.Length <= 8)
                throw new Exception("Password is required");

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                throw new Exception("Password must contain at least one symbol");

            return true;
        }



        public static bool IsValidPhone(string phone)
        {

            if (string.IsNullOrWhiteSpace(phone))
                throw new Exception("Phone number is required.");
              
            if (phone.Length != 10 || !long.TryParse(phone, out _)) 
                throw new Exception("Phone number must be exactly 10 digits and contain only numbers.");

            return true;

        }





    }
}
