using System;

namespace Blink.Classes.Blink
{
    public class BlinkHomescreen
    {
        public Account account { get; set; }
        public Network network { get; set; }
        public Device[] devices { get; set; }

        public class Account
        {
            public int notifications { get; set; }
        }

        public class Network
        {
            public string name { get; set; }
            public int wifi_strength { get; set; }
            public string status { get; set; }
            public bool armed { get; set; }
            public int notifications { get; set; }
            public int warning { get; set; }
            public bool enable_temp_alerts { get; set; }
            public string error_msg { get; set; }
        }

        public class Device
        {
            public string device_type { get; set; }
            public int device_id { get; set; }
            public string type { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string thumbnail { get; set; }
            public string active { get; set; }
            public int notifications { get; set; }
            public int warning { get; set; }
            public string error_msg { get; set; }
            public string status { get; set; }
            public bool enabled { get; set; }
            public bool armed { get; set; }
            public int errors { get; set; }
            public int wifi_strength { get; set; }
            public int lfr_strength { get; set; }
            public int temp { get; set; }
            public int battery { get; set; }
            public string battery_state { get; set; }
            public bool usage_rate { get; set; }
            public DateTime last_hb { get; set; }
        }
    }
}
