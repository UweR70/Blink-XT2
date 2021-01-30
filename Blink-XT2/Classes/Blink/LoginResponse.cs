namespace Blink.Classes.Blink
{
    public class LoginResponse
    {
        public Account account { get; set; }
        public Auth auth { get; set; }
        public Phone phone { get; set; }
        public Verification verification { get; set; }
        public int lockout_time_remaining { get; set; }
        public bool force_password_reset { get; set; }
        public int allow_pin_resend_seconds { get; set; }
    
        public class Account
        {
            public int account_id { get; set; }
            public int user_id { get; set; }
            public int client_id { get; set; }
            public bool new_account { get; set; }
            public string tier { get; set; }
            public string region { get; set; }
            public bool account_verification_required { get; set; }
            public bool phone_verification_required { get; set; }
            public bool client_verification_required { get; set; }
            public string verification_channel { get; set; }
        }

        public class Auth
        {
            public string token { get; set; }
        }

        public class Phone
        {
            public string number { get; set; }
            public string last_4_digits { get; set; }
            public string country_calling_code { get; set; }
            public bool valid { get; set; }
        }

        public class Verification
        {
            public Email email { get; set; }
            public Phone1 phone { get; set; }
        }

        public class Email
        {
            public bool required { get; set; }
        }

        public class Phone1
        {
            public bool required { get; set; }
            public string channel { get; set; }
        }



        //public Account account { get; set; }
        //public Client client { get; set; }
        //public Authtoken authtoken { get; set; }
        //public Region region { get; set; }
        //public int lockout_time_remaining { get; set; }
        //public bool force_password_reset { get; set; }
        //public int allow_pin_resend_seconds { get; set; }

        //public class Account
        //{
        //    public int id { get; set; }
        //    public bool verification_required { get; set; }
        //}

        //public class Client
        //{
        //    public int id { get; set; }
        //    public bool verification_required { get; set; }
        //}

        //public class Authtoken
        //{
        //    public string authtoken { get; set; }
        //    public string message { get; set; }
        //}

        //public class Region
        //{
        //    public string tier { get; set; }
        //    public string description { get; set; }
        //    public string code { get; set; }
        //}
    }
}
