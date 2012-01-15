using Blinky.Domain.Adapters;
using Blinky.Domain.Dimming;

namespace Blinky.Domain.Breathing
{
    public class Breather : IBreather
    {
        private readonly IDimmer _fadeIn;
        private readonly IDimmer _fadeOut;

        public Breather(IDimmer fadeIn, IDimmer fadeOut)
        {
            _fadeIn = fadeIn;
            _fadeOut = fadeOut;
        }

        public void Breathe(ILed led)
        {
            _fadeOut.Fade(led);
            _fadeIn.Fade(led);

        }
    }
}