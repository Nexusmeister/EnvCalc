using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using AsyncAwaitBestPractices.MVVM;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.BusinessObjects;
using EnvCalc.Tools;
using EnvCalc.Tools.Extensions;
using Serilog.Events;

namespace EnvCalc.Frontend.ViewModels
{
    public class RootEntityViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title => "RootEntitysicht";

        /// <summary>
        /// Gets or sets whether the user has agreed to continue.
        /// </summary>
        public ObservableCollection<Prozess> ProzessListe
        {
            get => GetValue<ObservableCollection<Prozess>>(ProzessListeProperty);
            set => SetValue(ProzessListeProperty, value);
        }

        public ICollectionView CollectionView
        {
            get => GetValue<ICollectionView>(FilteredProperty);
            set => SetValue(FilteredProperty, value);
        }

        public bool IsBusy
        {
            get => GetValue<bool>(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        public Prozess SelectedProzess
        {
            get => GetValue<Prozess>(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public IAsyncCommand ProzesseLadenCommand { get; private set; }
        public IAsyncCommand AktualisierenCommand { get; private set; }

        public string SuchText
        {
            get => GetValue<string>(SuchTextProperty);
            set
            {
                SetValue(SuchTextProperty, value);
                // Damit bei einer neuen Suche immer wieder die volle Liste angezeigt wird
                // Das geht bestimmt smarter, aber zumindest funktioniert das
                if (SuchText is not null && value is "" && CollectionView is not null)
                {
                    CollectionView.Filter = null;
                }
                else if (CollectionView is not null && CollectionView.Filter is null && SuchText is not null && value is not "")
                {
                    CollectionView.Filter = SucheProzess;
                }

                CollectionView?.Refresh();
            }
        }

        /// <summary>
        /// Register the UserAgreedToContinue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ProzessListeProperty =
            RegisterProperty(nameof(ProzessListe), typeof(ObservableCollection<Prozess>));

        public static readonly PropertyData FilteredProperty =
            RegisterProperty(nameof(CollectionView), typeof(ICollectionView));

        public static readonly PropertyData SuchTextProperty =
            RegisterProperty(nameof(SuchText), typeof(string));

        public static readonly PropertyData IsBusyProperty = RegisterProperty(nameof(IsBusy), typeof(bool));

        public static readonly PropertyData SelectedItemProperty =
            RegisterProperty(nameof(SelectedProzess), typeof(Prozess));

        public RootEntityViewModel()
        {
            //HoleProzessliste();
            AktualisierenCommand = new AsyncCommand(AktualisiereProzessListeAsync, KannAktualisieren);
            ProzesseLadenCommand = new AsyncCommand(HoleProzessListeAsync, KannAktualisieren);
        }

        /// <summary>
        /// Method to check whether the Edit command can be executed.
        /// </summary>
        private bool KannAktualisieren(object arg)
        {
            return !IsBusy;
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        private async Task AktualisiereProzessListeAsync()
        {
            ProzessListe.Clear();
            CollectionView.Refresh();

            await HoleProzessListeAsync();
        }


        private async Task HoleProzessListeAsync()
        {
            try
            {
                IsBusy = true;
                var liste = await BackendDataAccess.Instance.GetAllProzessberechnungen();
                ProzessListe = liste.ToObservableCollection();
                CollectionView = CollectionViewSource.GetDefaultView(ProzessListe);

                CollectionView.Filter = SucheProzess;
                IsBusy = false;
            }
            catch (Exception e)
            {
                Logger.Instanz.WriteException("Fehler beim Abrufen der Prozessliste", LogEventLevel.Error, e);
                ProzessListe = new ObservableCollection<Prozess>
                {
                    new Prozess()
                    {
                        Name = "Fehler beim Abrufen der Liste, bitte versuchen Sie es erneut" // Das vlt. als Statusbar einbauen
                    }
                };

                CollectionView = CollectionViewSource.GetDefaultView(ProzessListe);
                IsBusy = false;
            }
        }

        private bool SucheProzess(object obj)
        {
            if (obj is not Prozess prozess)
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

            return prozess.Name.Contains(suche, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}