namespace Blink.Classes.Blink
{
    public class GetRegions
    {
        public string preferred { get; set; }
        public Regions regions { get; set; }

        public class Regions
        {
            public E002 e002 { get; set; }
            public Usu008 usu008 { get; set; }
            public Usu016 usu016 { get; set; }
            public Sg sg { get; set; }
            public Usu015 usu015 { get; set; }
        }

        public class E002
        {
            public int display_order { get; set; }
            public string dns { get; set; }
            public string friendly_name { get; set; }
            public bool registration { get; set; }
        }

        public class Usu008
        {
            public int display_order { get; set; }
            public string dns { get; set; }
            public string friendly_name { get; set; }
            public bool registration { get; set; }
        }

        public class Usu016
        {
            public int display_order { get; set; }
            public string dns { get; set; }
            public string friendly_name { get; set; }
            public bool registration { get; set; }
        }

        public class Sg
        {
            public int display_order { get; set; }
            public string dns { get; set; }
            public string friendly_name { get; set; }
            public bool registration { get; set; }
        }

        public class Usu015
        {
            public int display_order { get; set; }
            public string dns { get; set; }
            public string friendly_name { get; set; }
            public bool registration { get; set; }
        }
    }
}
