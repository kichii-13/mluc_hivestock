namespace LogIn_HiveStock
{
    public static class UserSession
    {
        public static string IdNumber { get; private set; } = "";
        public static string Username { get; private set; } = "";
        public static string FirstName { get; private set; } = "";
        public static string LastName { get; private set; } = "";
        public static string Email { get; private set; } = "";
        public static string Phone { get; private set; } = "";

        public static bool IsLoggedIn
        {
            get { return IdNumber.Length > 0 || Username.Length > 0; }
        }

        public static string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }

        ///Key that ties orders to a user (ID number, falling back to username).
        public static string OrderKey
        {
            get { return IdNumber.Length > 0 ? IdNumber : Username; }
        }

        public static void SignIn(string idNumber, string firstName, string lastName,
                                  string username, string email, string phone)
        {
            IdNumber = (idNumber ?? "").Trim();
            FirstName = (firstName ?? "").Trim();
            LastName = (lastName ?? "").Trim();
            Username = (username ?? "").Trim();
            Email = (email ?? "").Trim();
            Phone = (phone ?? "").Trim();
        }

        // Called after the user edits their details in Profile (username is not editable there).
        public static void UpdateDetails(string idNumber, string firstName, string lastName,
                                         string email, string phone)
        {
            IdNumber = (idNumber ?? "").Trim();
            FirstName = (firstName ?? "").Trim();
            LastName = (lastName ?? "").Trim();
            Email = (email ?? "").Trim();
            Phone = (phone ?? "").Trim();
        }

        public static void SignOut()
        {
            SignIn("", "", "", "", "", "");
        }
    }
}