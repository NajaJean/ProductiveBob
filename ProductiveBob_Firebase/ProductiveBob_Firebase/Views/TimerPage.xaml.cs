using Plugin.DeviceInfo;
using ProductiveBob_Firebase.Services;
using System;
using System.Timers;
using Xamarin.Forms;

namespace ProductiveBob_Firebase.Views
{
    public partial class TimerPage : ContentPage
    {
        Timer t;
        int hours = 0, mins = 0, secs = 0;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        IGetDeviceInfo dID;

        public TimerPage()
        {
            InitializeComponent();
            BindingContext = this;
            StopClick.IsVisible = false;
            showRating(false);
        }

        private void btn_Start_Clicked(object sender, EventArgs e)
        {
            hours = 0; mins = 0; secs = 0;
            t = new Timer();
            t.Interval = (1000);
            t.Elapsed += Timer_Elapsed;
            t.Start();
            StartClick.IsVisible = false;
            StopClick.IsVisible = true;
            LabelTimer.Text = "\n You go! \n";
        }
        private void btn_Stop_Clicked(object sender, EventArgs e)
        {
            t.Stop();
            t.Dispose();
            StartClick.IsVisible = true;
            StopClick.IsVisible = false;
            showRating(true);
        }
        private void showRating(Boolean b)
        {
            Rating.IsVisible = b;
            Good.IsVisible = b;
            Medium.IsVisible = b;
            Bad.IsVisible = b;
        }
        private static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd HH:mm:ss");
        }
        private async void resetButton(object sender, EventArgs e, int Rating)
        {
            try
            {
                dID = DependencyService.Get<IGetDeviceInfo>();
                Console.WriteLine("Device Id: ", dID);
                string deviceID = dID.GetDeviceID();
                Console.WriteLine("Device id = ", deviceID);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
   //         IGetDeviceInfo d = DependencyService.Get<IGetDeviceInfo>();
    //        string dd = d.GetDeviceID();
            try {Console.WriteLine("This is a suckky id: ", CrossDeviceInfo.Current.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            await firebaseHelper.AddSession("Device ID", Guid.NewGuid(), Rating, new TimeSpan(hours,mins,secs), GetTimestamp(DateTime.Now) );

            ResultTimer.Text = "00:00:00";
            LabelTimer.Text = "\n You can do it! \n";
            Alert(sender, e);
            showRating(false);

        }
        private void btn_Good_Clicked(object sender, EventArgs e)
        {
            resetButton(sender, e, 3);
        }
        private void btn_Medium_Clicked(object sender, EventArgs e)
        {
            resetButton(sender, e,2);
        }
        private void btn_Bad_Clicked(object sender, EventArgs e)
        {
            resetButton(sender, e, 1);
        }
        async void Alert(object sender, EventArgs e)
        {
            await DisplayAlert(
                "Good job!",
                string.Format("Congrats, you were productve for {0:00}:{1:00}:{2:00}", hours, mins, secs),
                "Nice!");
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            secs++;
            if (secs == 59)
            {
                mins++;
                secs = 0;
            }
            if (mins == 59)
            {
                hours++;
                mins = 0;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                ResultTimer.Text = string.Format("\n {0:00}:{1:00}:{2:00}", hours, mins, secs);
            });
        }
    }
}
