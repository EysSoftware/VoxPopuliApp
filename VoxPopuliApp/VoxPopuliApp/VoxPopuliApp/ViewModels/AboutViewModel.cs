using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace VoxPopuliApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Acerca de";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/dereko182/VoxPopuli")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
