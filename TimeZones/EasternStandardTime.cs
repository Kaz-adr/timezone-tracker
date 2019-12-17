using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    class EasternStandardTime : TimeZone
    {
        private TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        public EasternStandardTime(DateTime vServerTime) : base(vServerTime) { } //extend base constructor

        public override void UpdateZoneTime(DateTime serverTime)
        {
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, estZone);
            ZoneTime = estTime;
        }

        public override string TitleString
        {
            get { return "EST"; }
        }
    }
}
