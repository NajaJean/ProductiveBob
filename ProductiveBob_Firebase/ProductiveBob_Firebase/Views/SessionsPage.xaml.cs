using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductiveBob_Firebase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionsPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public SessionsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allSessions = await firebaseHelper.GetAllSessions();
            lstSessions.ItemsSource = allSessions;
        }
    }
}