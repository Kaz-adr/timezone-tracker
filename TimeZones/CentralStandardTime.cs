using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    class CentralStandardTime : TimeZone
    {
        private TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        public CentralStandardTime(DateTime vServerTime) : base(vServerTime) { } //extend base constructor

        public override void UpdateZoneTime(DateTime serverTime)
        {
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, cstZone);
            ZoneTime = cstTime;
        }

        public override string TitleString
        {
            get { return "CST"; }
        }
    }
}
