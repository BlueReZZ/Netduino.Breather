using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

/* NOTE: make sure you change the deployment target from the Emulator to your Netduino before running this
 * Netduino sample app.  To do this, select "Project menu > Blinky Properties > .NET Micro Framework" and 
 * then change the Transport type to USB.  Finally, close the Blinky properties tab to save these settings. */

namespace Blinky
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            var ledPort = new OutputPort(Pins.ONBOARD_LED, false);

            int iMax = 0xff, iMin = 1;
            int i = iMin;

            while (true)
            {
                for (; i < iMax; i++)
                {

                    ledPort.Write(true);
                    funDelay(i);

                    ledPort.Write(false);
                    funDelay(iMax - i);

                }

                for (; i > iMin; i--)
                {

                    ledPort.Write(true);
                    funDelay(i);

                    ledPort.Write(false);
                    funDelay(iMax - i);

                }
            }
        }

        static private void funDelay(long lTicks)
        {
            DateTime tNow = DateTime.Now;
            DateTime tDue = tNow.AddTicks(lTicks * 0x100);
            while (DateTime.Now < tDue) ;

            return;
        }
    }
}
