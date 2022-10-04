using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DeskApi.Configuration;


namespace DeskApi.Controllers
{
    public class DeskController
    {
        public List<Desk> Desks { get; private set; }
        public static DeskController Current { get; private set; }
        private DeskController()
        {

        }

        static DeskController()
        {
            Current = new DeskController();
        }

        public void Initialize(DeskSettings deskSettings)
        {
            Desks = deskSettings.DeskPins.Select(pins => new Desk(pins)).ToList();
        }

        public void Stop(Desk d)
        {
           d.CancellationTokenSource?.Cancel();
           d.DownPort.State = false;
           d.UpPort.State = false;
        }

        public void Stop()
        {
            foreach (var d in Desks)
            {
                Stop(d);
            }
        }

        public async Task Raise(Desk d, double delay)
        {
            Stop(d);
            d.UpPort.State = true;
            await Task.Delay(TimeSpan.FromSeconds(delay));
            d.UpPort.State = false;
        }
        public async Task Lower(Desk d, double delay)
        {
            Stop(d);
            d.DownPort.State = true;
            await Task.Delay(TimeSpan.FromSeconds(delay));
            d.DownPort.State = false;
            
        }
       
    }
}