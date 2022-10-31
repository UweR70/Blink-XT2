using System;

namespace Blink.Classes.Blink
{
    public class BlinkCamera
    {
        public Camera_Status camera_status { get; set; }

        public class Camera_Status
        {
            public int camera_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public int wifi_strength { get; set; }
            public int lfr_strength { get; set; }
            public int battery_voltage { get; set; }
            public int temperature { get; set; }
            public string fw_version { get; set; }
            public string fw_git_hash { get; set; }
            public string mac { get; set; }
            public string ipv { get; set; }
            public string ip_address { get; set; }
            public int error_codes { get; set; }
            public bool battery_alert_status { get; set; }
            public bool temp_alert_status { get; set; }
            public bool ac_power { get; set; }
            public int light_sensor_ch0 { get; set; }
            public int light_sensor_ch1 { get; set; }
            public bool light_sensor_data_valid { get; set; }
            public bool light_sensor_data_new { get; set; }
            public int time_first_video { get; set; }
            public int time_108_boot { get; set; }
            public int time_wlan_connect { get; set; }
            public int time_dhcp_lease { get; set; }
            public int time_dns_resolve { get; set; }
            public int lfr_108_wakeups { get; set; }
            public int total_108_wakeups { get; set; }
            public int lfr_tb_wakeups { get; set; }
            public int total_tb_wakeups { get; set; }
            public int wifi_connect_failure_count { get; set; }
            public int dhcp_failure_count { get; set; }
            public int socket_failure_count { get; set; }
            public int dev_1 { get; set; }
            public int dev_2 { get; set; }
            public int dev_3 { get; set; }
            public int unit_number { get; set; }
            public string serial { get; set; }
            public int lifetime_count { get; set; }
            public int lifetime_duration { get; set; }
            public int pir_rejections { get; set; }
            public int sync_module_id { get; set; }
            public int network_id { get; set; }
            public int account_id { get; set; }
            public int id { get; set; }
            public string thumbnail { get; set; }
        }
    }
}
