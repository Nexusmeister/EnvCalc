using Catel.Data;
using Catel.MVVM;

namespace EnvCalc.Frontend.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected bool IstInitialisiert
        {
            get => GetValue<bool>(IstInitialisiertProperty);
            set => SetValue(IstInitialisiertProperty, value);
        }

        public bool IsBusy
        {
            get => GetValue<bool>(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        public bool IstLadekreisSichtbar
        {
            get => GetValue<bool>(IstLadekreisSichtbarProperty);
            set => SetValue(IstLadekreisSichtbarProperty, value);
        }

        protected void WechselArbeitsstatus()
        {
            IsBusy = !IsBusy;
            IstLadekreisSichtbar = !IstLadekreisSichtbar;
        }

        private static readonly PropertyData IsBusyProperty = RegisterProperty(nameof(IsBusy), typeof(bool));
        private static readonly PropertyData IstInitialisiertProperty = RegisterProperty(nameof(IstInitialisiert), typeof(bool));
        private static readonly PropertyData IstLadekreisSichtbarProperty = RegisterProperty(nameof(IstLadekreisSichtbar), typeof(bool));
    }
}