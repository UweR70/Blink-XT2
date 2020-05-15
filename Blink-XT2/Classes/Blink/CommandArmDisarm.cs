using System;

namespace Blink.Classes.Blink
{
    public class CommandArmDisarm
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime execute_time { get; set; }
        public string command { get; set; }
        public string state_stage { get; set; }
        public DateTime stage_rest { get; set; }
        public object stage_cs_db { get; set; }
        public object stage_cs_sent { get; set; }
        public object stage_sm { get; set; }
        public object stage_dev { get; set; }
        public object stage_is { get; set; }
        public object stage_lv { get; set; }
        public object stage_vs { get; set; }
        public string state_condition { get; set; }
        public object sm_ack { get; set; }
        public object lfr_ack { get; set; }
        public object sequence { get; set; }
        public int attempts { get; set; }
        public string transaction { get; set; }
        public string player_transaction { get; set; }
        public object server { get; set; }
        public object duration { get; set; }
        public string by_whom { get; set; }
        public bool diagnostic { get; set; }
        public string debug { get; set; }
        public object target { get; set; }
        public object target_id { get; set; }
        public object parent_command_id { get; set; }
        public object camera_id { get; set; }
        public object siren_id { get; set; }
        public object firmware_id { get; set; }
        public int network_id { get; set; }
        public int account_id { get; set; }
        public int sync_module_id { get; set; }
    }
}
