using System;

namespace Blink.Classes.Blink
{
    public class HomescreenV3
    {
        public Account account { get; set; }
        public Network[] networks { get; set; }
        public Sync_Modules[] sync_modules { get; set; }
        public Camera[] cameras { get; set; }
        public object[] sirens { get; set; }
        public object[] chimes { get; set; }
        public Video_Stats video_stats { get; set; }
        public object[] doorbell_buttons { get; set; }
        public object[] owls { get; set; }
        public App_Updates app_updates { get; set; }
        public Device_Limits device_limits { get; set; }
        public Whats_New whats_new { get; set; }

        public class Account
        {
            public int id { get; set; }
            public bool email_verified { get; set; }
            public bool email_verification_required { get; set; }
        }

        public class Video_Stats
        {
            public int storage { get; set; }
            public int auto_delete_days { get; set; }
        }

        public class App_Updates
        {
            public string message { get; set; }
            public int code { get; set; }
            public bool update_available { get; set; }
            public bool update_required { get; set; }
        }

        public class Device_Limits
        {
            public int total_devices { get; set; }
            public int owl { get; set; }
            public int camera { get; set; }
            public int siren { get; set; }
            public int doorbell_button { get; set; }
            public int chime { get; set; }
        }

        public class Whats_New
        {
            public int updated_at { get; set; }
            public string url { get; set; }
        }

        public class Network
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string time_zone { get; set; }
            public bool dst { get; set; }
            public bool armed { get; set; }
            public bool lv_save { get; set; }
        }

        public class Sync_Modules
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public bool onboarded { get; set; }
            public string status { get; set; }
            public string name { get; set; }
            public string serial { get; set; }
            public string fw_version { get; set; }
            public DateTime last_hb { get; set; }
            public int wifi_strength { get; set; }
            public int network_id { get; set; }
            public bool enable_temp_alerts { get; set; }
        }

        public class Camera
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string serial { get; set; }
            public string fw_version { get; set; }
            public string type { get; set; }
            public bool enabled { get; set; }
            public string thumbnail { get; set; }
            public string status { get; set; }
            public string battery { get; set; }
            public bool usage_rate { get; set; }
            public int network_id { get; set; }
            public object[] issues { get; set; }
            public Signals signals { get; set; }
        }

        public class Signals
        {
            public int lfr { get; set; }
            public int wifi { get; set; }
            public int temp { get; set; }
            public int battery { get; set; }
        }

    }
}
