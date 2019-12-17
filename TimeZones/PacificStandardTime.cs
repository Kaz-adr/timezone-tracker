using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    class PacificStandardTime : TimeZone
    {
        private TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        public PacificStandardTime(DateTime vServerTime) : base(vServerTime) { } //extend base constructor

        public override void UpdateZoneTime(DateTime serverTime)
        {
            DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, pstZone);
            ZoneTime = pstTime;
        }

        public override string TitleString
        {
            get { return "PST"; }
        }
    }
}
