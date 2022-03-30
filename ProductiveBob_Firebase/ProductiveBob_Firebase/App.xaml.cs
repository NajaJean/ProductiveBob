using ProductiveBob_Firebase.Services;
using Xamarin.Forms;

namespace ProductiveBob_Firebase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Get<IGetDeviceInfo>().GetDeviceID();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
