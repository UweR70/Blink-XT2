namespace Blink.Classes.Blink
{
    public class BlinkLoginResponse
    {
        public Account account { get; set; }
        public Client client { get; set; }
        public Authtoken authtoken { get; set; }
        public Region region { get; set; }
        public int lockout_time_remaining { get; set; }
        public bool force_password_reset { get; set; }
        public int allow_pin_resend_seconds { get; set; }

        public class Account
        {
            public int id { get; set; }
            public bool verification_required { get; set; }
        }

        public class Client
        {
            public int id { get; set; }
            public bool verification_required { get; set; }
        }

        public class Authtoken
        {
            public string authtoken { get; set; }
            public string message { get; set; }
        }

        public class Region
        {
            public string tier { get; set; }
            public string description { get; set; }
            public string code { get; set; }
        }
    }
}
