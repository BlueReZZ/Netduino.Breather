using Microsoft.SPOT.Hardware;

namespace Blinky
{
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
}