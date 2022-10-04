using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;
using System;
using System.Threading.Tasks;
using DeskApi.Configuration;
using DeskApi.Controllers;
using Meadow.Foundation.Web.Maple.Server;
using Meadow.Gateway.WiFi;


namespace DeskApi
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    public class MeadowApp : App<F7FeatherV2, MeadowApp>
    {
        RgbPwmLed onboardLed;
        //public static IServiceProvider ServiceProvider { get; set; }
        MapleServer mapleServer;

        public MeadowApp()
        {
            Initialize().Wait();
            mapleServer.Start();
            //try
            //{
            //    ServiceProvider.GetRequiredService<MapleServer>()
            //        .Start();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        async Task Initialize()
        {
            onboardLed = new RgbPwmLed(device: Device,
                redPwmPin: Device.Pins.OnboardLedRed,
                greenPwmPin: Device.Pins.OnboardLedGreen,
                bluePwmPin: Device.Pins.OnboardLedBlue,
                Meadow.Peripherals.Leds.IRgbLed.CommonType.CommonAnode);
            Console.WriteLine("Initialize hardware...");
            ShowColor(Color.Red);
            try
            {
                //var builder = new ConfigurationBuilder()
                //    .SetBasePath(MeadowOS.FileSystem.UserFileSystemRoot)
                //    .AddJsonFile("appsettings.json", optional:false);
                //var config = builder.Build();

                //var services = new ServiceCollection()
                //    .ConfigureServices(config);
                //ServiceProvider = services.BuildServiceProvider();

                //var secrets = ServiceProvider.GetRequiredService<IOptions<Secrets>>().Value;
                var secrets = new Secrets();
                DeskController.Current.Initialize(new DeskSettings());

                var connectionResult = await Device.WiFiAdapter.Connect(
                    secrets.WIFI_NAME, secrets.WIFI_PASSWORD, ReconnectionType.Automatic);
                if (connectionResult.ConnectionStatus != ConnectionStatus.Success)
                {
                    throw new Exception($"Cannot connect to network: {connectionResult.ConnectionStatus}");
                }

                mapleServer = new MapleServer(
                    Device.WiFiAdapter.IpAddress, secrets.PORT, false
                );
                Console.WriteLine($"Hosting on: {Device.WiFiAdapter.IpAddress}");
                //services.AddSingleton(mapleServer);
                //ServiceProvider = services.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            ShowColor(Color.Green);
        }

        void ShowColor(Color color)
        {
            onboardLed.StartBlink(color, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(0.1));
            
        }
    }
}
