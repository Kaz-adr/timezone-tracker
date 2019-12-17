using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CSharpTechnicalTest
{
    class TimeViewModel
    {
        //timezones
        public PacificStandardTime PST { get; private set; }
        public MountainStandardTime MST { get; private set; }
        public CentralStandardTime CST { get; private set; }
        public EasternStandardTime EST { get; private set; }

        //Server vs Local Difference class
        public CurrentVsServer CurrVSServ { get; private set; }

        //Object to access NIST servers
        private NetworkServerTime nServerTime = new NetworkServerTime();

        //UST time
        private DateTime ustDateTime;

        public TimeViewModel()
        {
            ustDateTime = nServerTime.GetCurrentServerTime();
            PST = new PacificStandardTime(ustDateTime);
            MST = new MountainStandardTime(ustDateTime);
            CST = new CentralStandardTime(ustDateTime);
            EST = new EasternStandardTime(ustDateTime);
            CurrVSServ = new CurrentVsServer(ustDateTime);

            //dispatch timer will ping the NIST servers every 5 seconds
            //Servers limit pings to once every 4 seconds
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        public void UpdateTime()
        {
            ustDateTime = nServerTime.GetCurrentServerTime();
            PST.UpdateZoneTime(ustDateTime);
            MST.UpdateZoneTime(ustDateTime);
            CST.UpdateZoneTime(ustDateTime);
            EST.UpdateZoneTime(ustDateTime);
            CurrVSServ.updateTime(ustDateTime);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
