using Catel.Data;
using Catel.MVVM;

namespace EnvCalc.Frontend.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public override string Title => "EnvCalc";

        public string IconPath
        {
            get => GetValue<string>(IconProperty);
            set => SetValue(IconProperty, value);
        }
        
        public static readonly PropertyData IconProperty = RegisterProperty(nameof(IconPath), typeof(string));

        public MainWindowViewModel()
        {
            IconPath = "Ressourcen/envCalc_icon.png";
        }
    }
}