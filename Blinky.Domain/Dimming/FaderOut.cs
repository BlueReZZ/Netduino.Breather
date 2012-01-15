using Blinky.Domain.Adapters;

namespace Blinky.Domain.Dimming
{
    public class FaderOut : Dimmer
    {
        public override void Fade(ILed ledPort)
        {
            for (var j = MAX_BRIGHTNESS; j > MIN_BRIGHTNESS; j--)
            {
                ledPort.Write(true);
                DelayFor(j);

                ledPort.Write(false);
                DelayFor(MAX_BRIGHTNESS - j);
            }
        }
    }
}