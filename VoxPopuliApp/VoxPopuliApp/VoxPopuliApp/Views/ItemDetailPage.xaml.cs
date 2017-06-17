
using System.Collections.Generic;
using VoxPopuliApp.Models;
using System.Linq;
using VoxPopuliApp.ViewModels;

using Xamarin.Forms;
using VoxPopuliApp.Helpers;
using System.Diagnostics;

namespace VoxPopuliApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {        
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {            
            InitializeComponent();            
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Respuestas != null)
            {
                if (viewModel.Respuestas.Count == 0)
                    viewModel.CargaRespuesta.Execute(null); 
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                var item = args.SelectedItem as Respuesta;
                if (item == null)
                    return;

                viewModel.respuestaSeleccionada = item;
                //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

                // Manually deselect item
                //ItemsListView.SelectedItem = null;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessagingCenter.Send(this, ex.Message);
            }
        }

    }
}
