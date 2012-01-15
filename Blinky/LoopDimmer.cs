using Microsoft.SPOT.Hardware;

namespace Blinky
{
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
}