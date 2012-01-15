using Blinky.Domain.Adapters;
using Microsoft.SPOT.Hardware;

namespace Blinky
{
    public class Led : ILed
    {
        private readonly OutputPort _port;

        public Led(OutputPort port)
        {
            _port = port;
        }

        public void Write(bool isOn)
        {
            _port.Write(isOn);
        }
    }
}