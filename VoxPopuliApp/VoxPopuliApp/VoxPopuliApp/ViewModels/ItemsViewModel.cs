using System;
using System.Diagnostics;
using System.Threading.Tasks;

using VoxPopuliApp.Helpers;
using VoxPopuliApp.Models;

using Xamarin.Forms;

namespace VoxPopuliApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public ObservableRangeCollection<Rootobject> Campanias { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command CargaCampaniasCommand { get; set; }

        public ItemsViewModel()
        {            
            Title = "VoxPopuli";
            Campanias = new ObservableRangeCollection<Rootobject>();
            CargaCampaniasCommand = new Command(async () => await ExecuteLoadCampaniasCommand());
        }

        async Task ExecuteLoadCampaniasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Campanias.Clear();
                var campanias = await CampaniaStore.GetItemsAsync(true);
                Campanias.ReplaceRange(campanias);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Imposible cargar campañas.",
                    Cancel = "Aceptar"
                }, "Aviso");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}