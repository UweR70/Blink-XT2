using System;

namespace Blink.Classes.Blink
{
    public class SignalStrength
    {
        public int lfr { get; set; }
        public int wifi { get; set; }
        public DateTime updated_at { get; set; }
        public int temp { get; set; }
        public int battery { get; set; }
    }
}
