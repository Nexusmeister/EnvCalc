using System;
using System.Windows.Input;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.Frontend.Commands;

namespace EnvCalc.Frontend.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, ICloseWindows
    {
        public override string Title => "EnvCalc";

        public string IconPath
        {
            get => GetValue<string>(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public ICommand CloseCommand { get; set; }
        public Action Close { get; set; }

        public static readonly PropertyData IconProperty = RegisterProperty(nameof(IconPath), typeof(string));

        public MainWindowViewModel()
        {
            IconPath = "Ressourcen/envCalc_icon.png";
            CloseCommand = new Command(SchliesseAnwendung);
        }

        private void SchliesseAnwendung()
        {
            Close?.Invoke();
        }

        public bool CanClose()
        {
            return true;
        }
    }
}