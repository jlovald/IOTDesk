using System.Linq;
using System.Threading;
using DeskApi.Configuration;
using Meadow.Hardware;

namespace DeskApi
{
    public class Desk
    {
        public IDigitalOutputPort UpPort { get; set; }
        public IDigitalOutputPort DownPort { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public Desk(DeskPins pins)
        {
            UpPort = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.First(p => p.Name.Equals(pins.UpPin)));
            DownPort = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.First(p => p.Name.Equals(pins.DownPin)));
        }

        
    }
}