using System;
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

    public class LedBreather
    {
        private readonly int _maxCycles;
        private readonly OutputPort _led;
        private readonly IBreather _breather;

        public LedBreather(int maxCycles, OutputPort led, IBreather breather)
        {
            _maxCycles = maxCycles;
            _led = led;
            _breather = breather;
        }

        public void Run()
        {
            var cycles = 0;
            while (cycles++ < _maxCycles)
                _breather.Breathe(_led);
        }
    }

    public interface IBreather
    {
        void Breathe(OutputPort led);
    }

    public class Breather : IBreather
    {
        private readonly IDimmer _dimmer;

        public Breather(IDimmer dimmer)
        {
            _dimmer = dimmer;
        }

        public  void Breathe(OutputPort led)
        {
            _dimmer.FadeIn(led);
            _dimmer.FadeOut(led);
        }
    }

    public class LoopDimmer : Dimmer
    {
        public override void FadeOut(OutputPort ledPort)
        {
            for (var j = MAX_BRIGHTNESS; j > MIN_BRIGHTNESS; j--)
            {
                ledPort.Write(true);
                DelayFor(j);

                ledPort.Write(false);
                DelayFor(MAX_BRIGHTNESS - j);
            }
        }

        public override void FadeIn(OutputPort ledPort)
        {
            for (var i = MIN_BRIGHTNESS; i < MAX_BRIGHTNESS; i++)
            {
                ledPort.Write(true);
                DelayFor(i);

                ledPort.Write(false);
                DelayFor(MAX_BRIGHTNESS - i);
            }
        }
    }

    public abstract class Dimmer : IDimmer
    {
        public const int MAX_BRIGHTNESS = 0xff;
        public const int MIN_BRIGHTNESS = 1;

        public static void DelayFor(long ticks)
        {
            var now = DateTime.Now;
            var due = now.AddTicks(ticks * 0x100);
            while (DateTime.Now < due) ;

            return;
        }

        public abstract void FadeIn(OutputPort ledPort);
        public abstract void FadeOut(OutputPort ledPort);
    }

    public interface IDimmer
    {
        void FadeIn(OutputPort ledPort);
        void FadeOut(OutputPort ledPort);
    }
}
