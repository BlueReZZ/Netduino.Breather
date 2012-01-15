using Microsoft.SPOT.Hardware;

namespace Blinky
{
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
}