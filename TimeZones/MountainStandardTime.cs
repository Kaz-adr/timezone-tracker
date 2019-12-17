using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    class MountainStandardTime : TimeZone
    {
        private TimeZoneInfo mstZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
        public MountainStandardTime(DateTime vServerTime) : base(vServerTime) { } //extend base constructor

        public override void UpdateZoneTime(DateTime serverTime)
        {
            DateTime mstTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, mstZone);
            ZoneTime = mstTime;
        }

        public override string TitleString
        {
            get { return "MST"; }
        }
    }
}
