namespace Blinky.Domain.Adapters
{
    public interface ILed
    {
        void Write(bool isOn);
    }
}