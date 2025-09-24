namespace Zamazon.WebUI.Settings
{
	public class ClientSettings
	{
        public Client ZamazonVisitorClient { get; set; }
		public Client ZamazonManagerClient { get; set; }
		public Client ZamazonAdminClient { get; set; }
    }
	public class Client
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}
}
