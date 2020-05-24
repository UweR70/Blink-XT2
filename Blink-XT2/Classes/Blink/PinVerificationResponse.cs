namespace Blink.Classes.Blink
{
    public class PinVerificationResponse
    {
        public bool valid { get; set; }
        public bool require_new_pin { get; set; }
        public string message { get; set; }
        public int code { get; set; }
    }
}
