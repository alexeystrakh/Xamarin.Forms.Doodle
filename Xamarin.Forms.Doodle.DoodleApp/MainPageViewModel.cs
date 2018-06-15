using System;
namespace Xamarin.Forms.Doodle.DoodleApp
{
    public class MainPageViewModel : BindableObject
    {
        private int _state;

        public string Text => $"You clicked {_state} time(s). I need more!";

        public Command ExecuteAction { get; }

        public MainPageViewModel()
        {
            ExecuteAction = new Command(() => OnExecuteAction());
        }

        private void OnExecuteAction()
        {
            _state++;

            OnPropertyChanged("Text");
        }
    }
}
