using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.BusinessObjects;
using EnvCalc.Tools;
using EnvCalc.Tools.Extensions;
using Serilog.Events;

namespace EnvCalc.Frontend.ViewModels
{
    public class ExchangeViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title => "Exchangesicht";

        /// <summary>
        /// Gets or sets whether the user has agreed to continue.
        /// </summary>
        public ObservableCollection<Exchange> ExchangeListe
        {
            get => GetValue<ObservableCollection<Exchange>>(ExchangeListeProperty);
            set => SetValue(ExchangeListeProperty, value);
        }

        public ICollectionView ExchangeView
        {
            get => GetValue<ICollectionView>(FilteredProperty);
            set => SetValue(FilteredProperty, value);
        }

        public ICatelCommand ProzesseLadenCommand { get; private set; }
        public ICatelCommand AktualisierenCommand { get; private set; }

        public string SuchText
        {
            get => GetValue<string>(SuchTextProperty);
            set
            {
                SetValue(SuchTextProperty, value);
                // Damit bei einer neuen Suche immer wieder die volle Liste angezeigt wird
                // Das geht bestimmt smarter, aber zumindest funktioniert das
                if (SuchText is not null && value is "" && ExchangeView is not null)
                {
                    ExchangeView.Filter = null;
                }
                else if(ExchangeView is not null && ExchangeView.Filter is null && SuchText is not null && value is not "")
                {
                    ExchangeView.Filter = SucheExchange;
                }

                ExchangeView?.Refresh();
            }
        }

        public ExchangeViewModel()
        {
            AktualisierenCommand = new TaskCommand(AktualisiereExchangeListeAsync, CanExecute);
            ProzesseLadenCommand = new TaskCommand(InitialisiereExchangeListeAsync, CanExecute);
        }

        private bool CanExecute()
        {
            return !IsBusy;
        }
        
        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        private async Task AktualisiereExchangeListeAsync()
        {
            ExchangeListe.Clear();
            ExchangeView.Refresh();

            await HoleExchangelisteAsync();
        }

        private async Task InitialisiereExchangeListeAsync()
        {
            if (IstInitialisiert)
            {
                return;
            }

            await HoleExchangelisteAsync();
            IstInitialisiert = true;
        }


        private async Task HoleExchangelisteAsync()
        {
            try
            {
                WechselArbeitsstatus();
                var liste = await BackendDataAccess.Instance.GetAllExchangesAsync();
                ExchangeListe = liste.ToObservableCollection();
                ExchangeView = CollectionViewSource.GetDefaultView(ExchangeListe);

                ExchangeView.Filter = SucheExchange;
                WechselArbeitsstatus();
            }
            catch (Exception e)
            {
                Logger.Instanz.WriteException("Fehler beim Abrufen der Prozessliste", LogEventLevel.Error, e);
                ExchangeListe = new ObservableCollection<Exchange>
                {
                    new()
                    {
                        Name = "Fehler beim Abrufen der Liste, bitte versuchen Sie es erneut" // Das vlt. als Statusbar einbauen
                    }
                };

                ExchangeView = CollectionViewSource.GetDefaultView(ExchangeListe);
                WechselArbeitsstatus();
            }
        }

        private bool SucheExchange(object obj)
        {
            if (obj is not Exchange ex)
            {
                return false;
            }

            if (SuchText is null)
            {
                return false;
            }

            var suche = SuchText;
            if (suche.Contains("ö", StringComparison.InvariantCultureIgnoreCase))
            {
                suche = suche.Replace("ö", "oe", StringComparison.InvariantCultureIgnoreCase);
            }
            if (suche.Contains("ü", StringComparison.InvariantCultureIgnoreCase))
            {
                suche = suche.Replace("ü", "ue", StringComparison.InvariantCultureIgnoreCase);
            }
            if (suche.Contains("ä", StringComparison.InvariantCultureIgnoreCase))
            {
                suche = suche.Replace("ä", "ae", StringComparison.InvariantCultureIgnoreCase);
            }

            return ex.Name.Contains(suche, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Register the UserAgreedToContinue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ExchangeListeProperty =
            RegisterProperty(nameof(ExchangeListe), typeof(ObservableCollection<Exchange>));

        public static readonly PropertyData FilteredProperty =
            RegisterProperty(nameof(ExchangeView), typeof(ICollectionView));

        public static readonly PropertyData SuchTextProperty =
            RegisterProperty(nameof(SuchText), typeof(string));
    }
}