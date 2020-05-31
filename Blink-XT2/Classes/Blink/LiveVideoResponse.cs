using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blink.Classes.Blink
{
    public class LiveVideoResponse
    {
        public int id { get; set; }
        public string server { get; set; }
        public int duration { get; set; }
        public string device_name { get; set; }
        public string camera_name { get; set; }
        public int network_id { get; set; }
        public int continue_interval { get; set; }
        public int continue_warning { get; set; }
        public bool submit_logs { get; set; }
        public bool lv_save { get; set; }
    }
}
