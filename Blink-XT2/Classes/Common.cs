using Blink.Classes.Blink;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Timers;

namespace Blink.Classes
{
    public class Common
    {
        public string ReplaceParts(string completeInfo, string toBeReplaced, string replacement)
        {
            var lastIndexOf = completeInfo.LastIndexOf(toBeReplaced);
            if (lastIndexOf == -1)
            {
                return completeInfo;
            }
            var result = completeInfo.Remove(lastIndexOf, toBeReplaced.Length).Insert(lastIndexOf, replacement);
            return result;
        }

        public string CombineNameAndId(string name, int id)
        {
            return $"{name}_{id}";
        }

        public string GetTimestampFormatter()
        {
            return CultureInfo.CurrentCulture.Name.ToUpperInvariant().Equals("DE-DE") ? "yyyy.MM.dd__hh_mm_ss" : "yyyy.MM.dd__HH_mm_ss_tt";
        }

        public Timer SetInterval(Action action, int intervalInMilliseconds)
        {
            var timer = new Timer
            {
                AutoReset = true,
                Interval = intervalInMilliseconds
            };
            timer.Elapsed += (sender, args) => action();
            return timer;
        }
    }
}
