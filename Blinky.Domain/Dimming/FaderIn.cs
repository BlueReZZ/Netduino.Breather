using Blinky.Domain.Adapters;

namespace Blinky.Domain.Dimming
{
    public class FaderIn : Dimmer
    {
        public override void Fade(ILed ledPort)
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
}