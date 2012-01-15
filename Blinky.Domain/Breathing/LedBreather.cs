using Blinky.Domain.Adapters;

namespace Blinky.Domain.Breathing
{
    public class LedBreather
    {
        private readonly int _maxCycles;
        private readonly ILed _led;
        private readonly IBreather _breather;

        public LedBreather(int maxCycles, ILed led, IBreather breather)
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
}