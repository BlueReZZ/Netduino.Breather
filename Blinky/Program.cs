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
            var led = new OutputPort(Pins.ONBOARD_LED, false);

            var cycles = 0;
            const int maxCycles = 10;
            while (cycles <= maxCycles)
            {
                FlashFor(led, 125);
                FlashFor(led, 250);
                FlashFor(led, 500);
                cycles++;
            }
        }

        private static void FlashFor(OutputPort led, int millisecondsTimeout)
        {
            led.Write(true);
            Thread.Sleep(millisecondsTimeout);
            led.Write(false);
            Thread.Sleep(millisecondsTimeout);
        }
    }
}
