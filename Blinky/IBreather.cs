using Microsoft.SPOT.Hardware;

namespace Blinky
{
    public interface IBreather
    {
        void Breathe(OutputPort led);
    }
}