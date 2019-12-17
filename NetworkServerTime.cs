using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Windows.Threading;

namespace CSharpTechnicalTest
{
    class NetworkServerTime
    {
        private const string server = "time.nist.gov"; //URL to connect to the server
        private const Int32 port = 13; //port to get date time
        private DateTime currentTime = new DateTime();

        public NetworkServerTime()
        {
            //assign current date time
            currentTime = AccessCurrentServerTime();
        }


        public DateTime GetCurrentServerTime()
        {
            currentTime = AccessCurrentServerTime();
            return CurrentTime;
        }

        //references used : http://csharphelper.com/blog/2014/11/get-the-current-time-from-the-nist-server-in-c/
        //changes to code and comments done for self study
        private DateTime AccessCurrentServerTime()
        {
            bool bGoodConnection = false;
            string sNISTDateTimeFull = "";
            DateTime result = new DateTime();

            TcpClient tcpClientConnection = new TcpClient();

            try
            {
                tcpClientConnection.Connect(server, port);
                bGoodConnection = true;
            }
            catch
            {
                Console.WriteLine("TCP CONNECT ERROR: BAD CONNECTION");
            }

            //give up if bad connection
            if (bGoodConnection)
            {
                //Attempt to get data
                try
                {
                    NetworkStream netStream = tcpClientConnection.GetStream();

                    //check the steam flag for readability
                    if (netStream.CanRead)
                    {
                        //get buffer size
                        byte[] bytes = new byte[tcpClientConnection.ReceiveBufferSize];

                        //read stream to buffer length

                        netStream.Read(bytes, 0 , tcpClientConnection.ReceiveBufferSize);

                        //read bytes as ASCII values
                        sNISTDateTimeFull = Encoding.ASCII.GetString(bytes).Substring(0, 50);

                        //convert to DateTime value
                        result = ConvertStringToDateTime(sNISTDateTimeFull);
                    }
                    else
                    {
                        Console.WriteLine("ERROR READING NETSTREAM");
                        tcpClientConnection.Close();
                        netStream.Close();
                    }
                    tcpClientConnection.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.ToString());
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.ToString());
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return result;
        }

        //routine taken from AccessServerTime to shorten method
        private DateTime ConvertStringToDateTime(string timeString)
        {
            string timeStringShort = "";
            try
            {
                timeStringShort = timeString.Substring(7, 17);
                return DateTime.Parse("20" + timeStringShort);
            }
            catch
            {
                Console.WriteLine("String Conversion Failed");
                return CurrentTime;
            }
        }

        public DateTime CurrentTime
        {
            get { return currentTime; }
        }
    }
}
