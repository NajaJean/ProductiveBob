using System.Windows.Input;

namespace ProductiveBob_Firebase.ViewModels
{
    public class TimerViewModel : BaseViewModel
    {
        public TimerViewModel()
        {
            Title = "Productive Bob";
        }
        public ICommand OpenWebCommand { get; }
    }
}
