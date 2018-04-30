using System.ComponentModel;
using System.Runtime.CompilerServices;
using EnglishExams.Annotations;

namespace EnglishExams.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Set<T>(ref T variable, T value, string propertyName)
        {
            variable = value;
            OnPropertyChanged(propertyName);
        }
    }
}    