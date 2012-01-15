using Blinky.Domain.Adapters;

namespace Blinky.Domain.Breathing
{
    public interface IBreather
    {
        void Breathe(ILed led);
    }
}