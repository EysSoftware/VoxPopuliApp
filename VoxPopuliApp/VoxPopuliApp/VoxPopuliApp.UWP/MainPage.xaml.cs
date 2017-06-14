namespace VoxPopuliApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new VoxPopuliApp.App());
        }
    }
}