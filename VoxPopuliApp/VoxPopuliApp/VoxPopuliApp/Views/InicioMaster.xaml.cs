using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoxPopuliApp.Views.Inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public InicioMaster()
        {
            InitializeComponent();
            BindingContext = new InicioMasterViewModel();
        }



        class InicioMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<InicioMenuItem> MenuItems { get; }
            public InicioMasterViewModel()
            {
                InicioMenuItems = new ObservableCollection<InicioMenuItem>(new[]
                {
                    new InicioMenuItem { Id = 0, Title = "Page 1" },
                    new InicioMenuItem { Id = 1, Title = "Page 2" },
                    new InicioMenuItem { Id = 2, Title = "Page 3" },
                    new InicioMenuItem { Id = 3, Title = "Page 4" },
                    new InicioMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
