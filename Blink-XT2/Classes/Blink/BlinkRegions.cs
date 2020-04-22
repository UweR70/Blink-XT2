namespace Blink.Classes.Blink
{
    public class BlinkRegions
    {
        public string preferred { get; set; }
        public Regions regions { get; set; }

        public class Regions
        {
            public E002 e002 { get; set; }
            public Usu017 usu017 { get; set; }
            public Usu013 usu013 { get; set; }
            public Sg sg { get; set; }
            public Usu012 usu012 { get; set; }
        }

        public class E002
        {
            public string dns { get; set; }             // Notice: The value of this dns property is "e002" while the class name is "E002"
            public string friendly_name { get; set; }
            public bool registration { get; set; }
            public int display_order { get; set; }
        }

        public class Usu017
        {
            public string dns { get; set; }             // Notice: The value of this dns property is "u017" while the class name is "Usu017"
            public string friendly_name { get; set; }
            public bool registration { get; set; }
            public int display_order { get; set; }
        }

        public class Usu013                     
        {
            public string dns { get; set; }             // Notice: The value of this dns property is "u013" while the class name is "Usu013"
            public string friendly_name { get; set; }
            public bool registration { get; set; }
            public int display_order { get; set; }
        }

        public class Sg
        {
            public string dns { get; set; }             // Notice: The value of this dns property is "prsg" while the class name is "Sg"
            public string friendly_name { get; set; }
            public bool registration { get; set; }
            public int display_order { get; set; }
        }

        public class Usu012
        {
            public string dns { get; set; }             // Notice: The value of this dns property is "u012" while the class name is "Usu012"
            public string friendly_name { get; set; }
            public bool registration { get; set; }
            public int display_order { get; set; }
        }
    }
}
