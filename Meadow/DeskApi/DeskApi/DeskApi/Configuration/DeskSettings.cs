using System.Collections.Generic;


namespace DeskApi.Configuration
{
    public class DeskSettings
    {
        public IEnumerable<DeskPins> DeskPins { get; set; } = new List<DeskPins>()
        {
            new DeskPins
            {
                DownPin = "D05",
                UpPin = "D06"
            },
            new DeskPins
            {
                DownPin = "D07",
                UpPin = "D08"
            },
            new DeskPins
            {
                DownPin = "D09",
                UpPin = "D10"
            },
            new DeskPins
            {
                DownPin = "D11",
                UpPin = "D12"
            }
        };
    }

    public class DeskPins
    {
        public string UpPin { get; set; }
        public string DownPin { get; set; }
    }
}