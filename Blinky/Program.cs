using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;


namespace Blinky
{
    public class Program
    {
        public static void Main()
        {
            var led = new OutputPort(Pins.ONBOARD_LED, false);
            var breather = new LedBreather(5, led, new Breather(new LoopDimmer()));
            breather.Run();
        }       
    }

    public interface IDimmer
    {
        void FadeIn(OutputPort ledPort);
        void FadeOut(OutputPort ledPort);
    }
}
