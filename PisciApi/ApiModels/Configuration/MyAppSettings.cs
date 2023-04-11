namespace ApiModels.Configuration
{
    public class MyAppSettings
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// Command timeout in seconds.
        /// </summary>
        public int Timeout { get; set; }

        public string SupportEmail { get; set; }
    }
}
