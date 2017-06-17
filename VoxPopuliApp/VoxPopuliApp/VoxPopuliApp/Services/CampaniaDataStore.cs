using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VoxPopuliApp.Helpers;
using VoxPopuliApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(VoxPopuliApp.Services.CampaniaDataStore))]
namespace VoxPopuliApp.Services
{
    public class CampaniaDataStore : IDataStore<Rootobject>
    {
        HttpClient client;
        IMobileServiceTable<Rootobject> _CampaniaTable;
        List<Rootobject> campanias;
        AzureConnection AzureClient = new AzureConnection();
        bool isInitialized;

        public CampaniaDataStore()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2560000;
        }

        public Task<bool> AddItemAsync(Rootobject item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(Rootobject item)
        {
            throw new NotImplementedException();
        }

        public Task<Rootobject> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rootobject>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                //await InitializeAsync();
                campanias = new List<Rootobject>();

                string RestUrl = @"http://eysvirtual.centralus.cloudapp.azure.com/voxpopuli/api/Campanias";

                var uri = new Uri(string.Format(RestUrl, string.Empty));

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Rootobject> data = JsonConvert.DeserializeObject<List<Rootobject>>(content);                                  
                    campanias = JsonConvert.DeserializeObject<List<Rootobject>>(content);
                }

                isInitialized = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error = "+ ex);
                MessagingCenter.Send<CampaniaDataStore, string>(this, "ErrInsert", "Error al insertar respuesta.");
            }

            return campanias;
        }

        public async Task InitializeAsync()
        {
            //if (isInitialized)
            //    return;

            //            campanias = new List<Campania>();
            var _items = new List<Rootobject>
            {
                new Rootobject { CampaniaId = 1, Nombre = "PRUEBA 1", Descripcion="TODOITEM"},
                new Rootobject { CampaniaId = 2, Nombre = "PRUEBA 2", Descripcion="TODOITEM"},
            };

            foreach (Rootobject item in _items)
            {
                campanias.Add(item);
            }

            isInitialized = true;
        }

        public Task<bool> PullLatestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Rootobject item)
        {
            throw new NotImplementedException();
        }
    }
}
