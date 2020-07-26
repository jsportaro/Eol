using System.Device.Gpio;

namespace Eol.Runner
{
    public interface IGpio
    {
        void OpenPin(int bit0, PinMode output);
        void Write(int bit0, PinValue high);
    }
}