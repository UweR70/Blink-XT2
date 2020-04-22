using System;

namespace Blink.Classes.Blink
{
    public class BlinkSyncModules
    {
        public Syncmodule syncmodule { get; set; }
       
        public class Syncmodule
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string last_activity { get; set; }
            public string name { get; set; }
            public string fw_version { get; set; }
            public object mac_address { get; set; }
            public string ip_address { get; set; }
            public object lfr_frequency { get; set; }
            public string serial { get; set; }
            public string status { get; set; }
            public bool onboarded { get; set; }
            public string server { get; set; }
            public DateTime last_hb { get; set; }
            public string os_version { get; set; }
            public object last_wifi_alert { get; set; }
            public int wifi_alert_count { get; set; }
            public DateTime last_offline_alert { get; set; }
            public int offline_alert_count { get; set; }
            public int table_update_sequence { get; set; }
            public object feature_plan_id { get; set; }
            public int account_id { get; set; }
            public int network_id { get; set; }
            public int wifi_strength { get; set; }
        }

    }
}
