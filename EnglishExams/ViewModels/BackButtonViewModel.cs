using EnglishExams.Infrastructure;

namespace EnglishExams.ViewModels
{
    public class BackButtonViewModel : ViewModelBase
    {
        public RelayCommand Back { get; set; }

        public BackButtonViewModel()
        {
            Back = new RelayCommand(BackMenu);
        }

        public void BackMenu()
        {
            RedirectDecorator.ToViewModel(typeof(MenuViewModel));
        }
    }
}