using System.Collections.Generic;

namespace Blink.Classes
{
    public class BlinkRegionsAdjustedByUweR70
    {
        public string Preferred;
        public List<Region> Regions;

        public class Region
        {
            public string OriginalPropertyName;
            public string Dns;
            public string FriendlyName;
            public bool Registration;
            public int DisplayOrder;
        }
    }
}
