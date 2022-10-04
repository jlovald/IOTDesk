namespace DeskApi.Configuration
{
    public class Secrets
    {
        /// <summary>
        /// Name of the WiFi network to use.
        /// </summary>
        public string WIFI_NAME { get; set; } = "juandeag";

        /// <summary>
        /// Password for the WiFi network names in WIFI_NAME.
        /// </summary>
        public string WIFI_PASSWORD { get; set; } = "41739111";

        public int PORT { get; set; } = 1337;
    }
}