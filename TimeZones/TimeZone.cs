using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    //base class for TimeZone objects
    abstract class TimeZone : ObservableObject
    {
        protected DateTime zoneTime;
        public TimeZone(DateTime vServerTime)
        {
            UpdateZoneTime(vServerTime);
        }

        public abstract void UpdateZoneTime(DateTime serverTime); //update the zonetype based on whatever timezone this is
        public abstract string TitleString { get; } //for ui to display what timezone this is

        public virtual DateTime ZoneTime
        {
            get { return zoneTime; }
            set
            {
                zoneTime = value;
                OnPropertyChanged("ZoneTime");
            }
        }
    }
}
