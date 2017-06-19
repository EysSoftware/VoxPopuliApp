using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VoxPopuliApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoxPopuliApp.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public MainMenuMaster()
        {
            InitializeComponent();
            BindingContext = new MainMenuMasterViewModel();
        }

        class MainMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuMenuItem> MenuItems { get; }
            public MainMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuMenuItem>(new[]
                {
                    new MainMenuMenuItem { Id = 0, Title = "Campañas Activas", TargetType = typeof(ItemsPage), Source = "questions.png"},
                    new MainMenuMenuItem { Id = 1, Title = "Mis Recompensas", TargetType = typeof(MisRecompensas), Source = "badge.png"},
                    new MainMenuMenuItem { Id = 2, Title = "About", TargetType = typeof(AboutPage), Source = "question.png" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            #endregion
        }
    }
}