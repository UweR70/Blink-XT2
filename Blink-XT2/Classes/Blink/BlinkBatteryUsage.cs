namespace Blink.Classes.Blink
{
    public class BlinkBatteryUsage
    {
        public int range_days { get; set; }
        public Reference reference { get; set; }
        public Network[] networks { get; set; }

        public class Reference
        {
            public int usage { get; set; }
        }

        public class Network
        {
            public int network_id { get; set; }
            public string name { get; set; }
            public Camera[] cameras { get; set; }
        }

        public class Camera
        {
            public int id { get; set; }
            public string name { get; set; }
            public int usage { get; set; }
            public int lv_seconds { get; set; }
            public int clip_seconds { get; set; }
        }
    }
}
