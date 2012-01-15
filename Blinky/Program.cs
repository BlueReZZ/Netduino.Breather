using Blinky.Domain.Breathing;
using Blinky.Domain.Dimming;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;


namespace Blinky
{
    public class Program
    {
        public static void Main()
        {
            var led = new Led(new OutputPort(Pins.ONBOARD_LED, false));
            var breather = new LedBreather(5, led, new Breather(new FaderIn(), new FaderOut()));
            breather.Run();
        }       
    }
}
