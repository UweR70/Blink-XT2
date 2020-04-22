using System;

namespace Blink.Classes.Blink
{
    public class BlinkEvents
    {
        public Event[] _event { get; set; }

        public class Event
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string type { get; set; }
            public bool notified { get; set; }
            public object duration { get; set; }
            public string status { get; set; }
            public object target { get; set; }
            public object target_id { get; set; }
            public object data { get; set; }
            public int? command_id { get; set; }
            public int? camera_id { get; set; }
            public object siren_id { get; set; }
            public int? sync_module_id { get; set; }
            public int? network_id { get; set; }
            public int account_id { get; set; }
            public int? syncmodule { get; set; }
            public int? camera { get; set; }
            public object siren { get; set; }
            public int account { get; set; }
            public string camera_name { get; set; }
        }
    }
}
