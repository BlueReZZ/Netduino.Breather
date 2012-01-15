using System;
using Microsoft.SPOT.Hardware;

namespace Blinky
{
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
}