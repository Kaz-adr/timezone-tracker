using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalTest
{
    class CurrentVsServer : ObservableObject
    {
        private DateTime rawServerTime;
        private DateTime localTime;
        private TimeSpan timeDifference;
        private string resultString;
        public CurrentVsServer(DateTime vServer)
        {
            updateTime(vServer);
        }

        //update every field, though not all are used
        public void updateTime(DateTime vServer)
        {
            LocalServerTime = TimeZoneInfo.ConvertTimeFromUtc(vServer, TimeZoneInfo.Local); //find what the server thinks the current time should be
            LocalTime = DateTime.Now; 
            TimeDifference = LocalServerTime - LocalTime;
            ResultString = "Server Time: " + LocalServerTime + " - Local Time: " + LocalTime +
                "\nTime Difference: Minutes " + TimeDifference.Minutes + " Seconds " + TimeDifference.Seconds + " Milliseconds " + TimeDifference.Milliseconds;
        }

        public DateTime LocalServerTime
        {
            get { return rawServerTime; }
            set
            {
                rawServerTime = value;
                OnPropertyChanged("LocalServerTime");
            }
        }

        public DateTime LocalTime
        {
            get { return localTime; }
            set
            {
                localTime = value;
                OnPropertyChanged("LocalTime");
            }
        }

        public TimeSpan TimeDifference
        {
            get { return timeDifference; }
            set
            {
                timeDifference = value;
                OnPropertyChanged("TimeDifference");
            }
        }

        public string ResultString
        {
            get { return resultString; }
            set
            {
                resultString = value;
                OnPropertyChanged("ResultString");
            }
        }
    }
}
