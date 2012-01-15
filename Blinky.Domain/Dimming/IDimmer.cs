using Blinky.Domain.Adapters;

namespace Blinky.Domain.Dimming
{
    public interface IDimmer
    {
        void Fade(ILed ledPort);
    }
}