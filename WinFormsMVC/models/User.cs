namespace WinFormsMVC.models
{
    public class UserLoginParameters : ActionParameter
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class UserInfoParameters : ActionParameter
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }

    public class User
    {

        private static User instance;

       
        private User()
        {  
        }

        public static User GetInstance()
        {
            if (instance == null)
            {
                instance = new User();
            }
            return instance;
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool Logged { get; set; }
    }
}
