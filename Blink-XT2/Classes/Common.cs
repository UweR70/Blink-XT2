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

        public BlinkRegionsAdjustedByUweR70 ConvertBlinkRegions(BlinkRegions blinkRegions)
        {
            if (blinkRegions == null)
            {
                return null;
            }

            var ret = new BlinkRegionsAdjustedByUweR70 {
                Preferred = blinkRegions.preferred,
                Regions = new List<BlinkRegionsAdjustedByUweR70.Region>
                {
                    new BlinkRegionsAdjustedByUweR70.Region {
                        OriginalPropertyName = nameof(blinkRegions.regions.e002),
                        DisplayOrder = blinkRegions.regions.e002.display_order,
                        Dns = blinkRegions.regions.e002.dns,
                        FriendlyName = blinkRegions.regions.e002.friendly_name,
                        Registration = blinkRegions.regions.e002.registration
                    },
                    new BlinkRegionsAdjustedByUweR70.Region {
                        OriginalPropertyName = nameof(blinkRegions.regions.sg),
                        DisplayOrder = blinkRegions.regions.sg.display_order,
                        Dns = blinkRegions.regions.sg.dns,
                        FriendlyName = blinkRegions.regions.sg.friendly_name,
                        Registration = blinkRegions.regions.sg.registration
                    },
                    new BlinkRegionsAdjustedByUweR70.Region {
                        OriginalPropertyName = nameof(blinkRegions.regions.usu012),
                        DisplayOrder = blinkRegions.regions.usu012.display_order,
                        Dns = blinkRegions.regions.usu012.dns,
                        FriendlyName = blinkRegions.regions.usu012.friendly_name,
                        Registration = blinkRegions.regions.usu012.registration
                    },
                    new BlinkRegionsAdjustedByUweR70.Region {
                        OriginalPropertyName = nameof(blinkRegions.regions.usu013),
                        DisplayOrder = blinkRegions.regions.usu013.display_order,
                        Dns = blinkRegions.regions.usu013.dns,
                        FriendlyName = blinkRegions.regions.usu013.friendly_name,
                        Registration = blinkRegions.regions.usu013.registration
                    },
                    new BlinkRegionsAdjustedByUweR70.Region {
                        OriginalPropertyName = nameof(blinkRegions.regions.usu017),
                        DisplayOrder = blinkRegions.regions.usu017.display_order,
                        Dns = blinkRegions.regions.usu017.dns,
                        FriendlyName = blinkRegions.regions.usu017.friendly_name,
                        Registration = blinkRegions.regions.usu017.registration
                    },
                }
            };
            return ret;
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
