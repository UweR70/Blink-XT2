using System;

namespace Blink.Classes.Blink
{
    public class ChangedMedia
    {
        public int limit { get; set; }
        public long purge_id { get; set; }
        public int refresh_count { get; set; }
        public Medium[] media { get; set; }

        public class Medium
        {
            public long id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public bool deleted { get; set; }
            public string device { get; set; }
            public int device_id { get; set; }
            public string device_name { get; set; }
            public int network_id { get; set; }
            public string network_name { get; set; }
            public string type { get; set; }
            public string source { get; set; }
            public bool partial { get; set; }
            public bool watched { get; set; }
            public string thumbnail { get; set; }
            public string media { get; set; }
            public object metadata { get; set; }
            public object[] additional_devices { get; set; }
            public string time_zone { get; set; }
        }
    }
}
