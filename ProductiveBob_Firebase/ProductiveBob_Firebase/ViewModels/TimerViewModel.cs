using System.Windows.Input;

namespace ProductiveBob_Firebase.ViewModels
{
    public class TimerViewModel : BaseViewModel
    {
        public TimerViewModel()
        {
            Title = "Productivity Timer";
        }
        public ICommand OpenWebCommand { get; }
    }
}
