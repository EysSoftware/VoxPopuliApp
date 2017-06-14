using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;

namespace VoxPopuliApp.Helpers
{
    public class AzureConnection
    {        
        MobileServiceClient client;
        HttpClient httpClient;

        public AzureConnection()
        {
            client = new MobileServiceClient(@"http://eysvirtual.centralus.cloudapp.azure.com/voxpopuli/api");
            httpClient = new HttpClient();
        }

        public MobileServiceClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }
    }
}
