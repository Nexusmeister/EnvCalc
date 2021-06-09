using System;
using System.Windows.Input;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.BusinessObjects.Enums;
using EnvCalc.Frontend.Commands;
using EnvCalc.Tools;

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

        public bool IstDevMenuSichtbar
        {
            get => GetValue<bool>(IstDevMenuSichtbarProperty);
            set => SetValue(IstDevMenuSichtbarProperty, value);
        }

        public ICommand CloseCommand { get; set; }
        public Action Close { get; set; }

        public static readonly PropertyData IconProperty = RegisterProperty(nameof(IconPath), typeof(string));

        public static readonly PropertyData IstDevMenuSichtbarProperty =
            RegisterProperty(nameof(IstDevMenuSichtbar), typeof(bool));

        public MainWindowViewModel()
        {
            CloseCommand = new Command(SchliesseAnwendung);
            Initialisiere();
        }

        private void Initialisiere()
        {
            IconPath = "Ressourcen/envCalc_icon.png";
            IstDevMenuSichtbar = AppSettings.Betriebsmodus == Betriebsmodus.Debug;
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