using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using EnvCalc.BusinessObjects.ProduktManager;
using EnvCalc.Tools;
using EnvCalc.Tools.Extensions;
using Serilog.Events;

namespace EnvCalc.Frontend.ViewModels
{
    public class ProduktManagerViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title => "Exchangesicht";

        public ICatelCommand ProdukteLadenCommand { get; private set; }
        public ICatelCommand AktualisierenCommand { get; private set; }
        public ICatelCommand ProduktHinzufuegenCommand { get; private set; }

        /// <summary>
        /// Gets or sets whether the user has agreed to continue.
        /// </summary>
        public ObservableCollection<Produkt> ProduktListe
        {
            get => GetValue<ObservableCollection<Produkt>>(ProduktListeProperty);
            set => SetValue(ProduktListeProperty, value);
        }

        public Produkt SelectedProdukt
        {
            get => GetValue<Produkt>(SelectedProduktProperty);
            set => SetValue(SelectedProduktProperty, value);
        }

        public ICollectionView ProduktView
        {
            get => GetValue<ICollectionView>(FilteredProperty);
            set => SetValue(FilteredProperty, value);
        }
       
        public string SuchText
        {
            get => GetValue<string>(SuchTextProperty);
            set
            {
                SetValue(SuchTextProperty, value);
                // Damit bei einer neuen Suche immer wieder die volle Liste angezeigt wird
                // Das geht bestimmt smarter, aber zumindest funktioniert das
                if (SuchText is not null && value is "" && ProduktView is not null)
                {
                    ProduktView.Filter = null;
                }
                else if (ProduktView is not null && ProduktView.Filter is null && SuchText is not null && value is not "")
                {
                    ProduktView.Filter = SucheExchange;
                }

                ProduktView?.Refresh();
            }
        }

        public ProduktManagerViewModel()
        {
            ProdukteLadenCommand = new TaskCommand(LadeProduktListeAsync, CanExecute);
            AktualisierenCommand = new TaskCommand(AktualisiereProduktListeAsync, CanExecute);
            ProduktHinzufuegenCommand = new TaskCommand(ProduktHinzufuegen, CanExecute);
        }

        private async Task ProduktHinzufuegen()
        {
            var dependencyResolver = this.GetDependencyResolver();
            var uiVisualizerService = dependencyResolver.Resolve<IUIVisualizerService>();
            var x = await uiVisualizerService.ShowDialogAsync(this, CompletedProc);

            if (x.GetValueOrDefault())
            {
                
            }
        }

        private void CompletedProc(object sender, UICompletedEventArgs e)
        {
            if (!e.Result.GetValueOrDefault())
            {
                var dependencyResolver = this.GetDependencyResolver();
                var messageService = dependencyResolver.Resolve<IMessageService>();
                //await messageService.Show("My first message via the service");
                messageService.ShowInformationAsync("Des ist nur ein Test lol");
            }
        }

        private bool CanExecute()
        {
            return !IsBusy;
        }

        private async Task AktualisiereProduktListeAsync()
        {
            await HoleProduktListeAsync();
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        private async Task LadeProduktListeAsync()
        {
            if (IstInitialisiert)
            {
                return;
            }

            await HoleProduktListeAsync();
            IstInitialisiert = true;
        }

        private async Task HoleProduktListeAsync()
        {
             try
             {
                WechselArbeitsstatus();
                var result = await BackendDataAccess.Instance.GetAllProdukteAsync();
                ProduktListe = result.ToObservableCollection();
                ProduktView = CollectionViewSource.GetDefaultView(ProduktListe);

                ProduktView.Filter = SucheExchange;
                WechselArbeitsstatus();
             }
             catch (Exception e)
             {
                Logger.Instanz.WriteException("Fehler beim Abrufen der Produktliste", LogEventLevel.Error, e);
                ProduktListe = new ObservableCollection<Produkt>
                {
                     new()
                     {
                         Name = "Fehler beim Abrufen der Produkte, bitte versuchen Sie es erneut" // Das vlt. als Statusbar einbauen
                     }
                };

                ProduktView = CollectionViewSource.GetDefaultView(ProduktListe);
                IsBusy = false;
             }
        }
        
        private bool SucheExchange(object obj)
        {
            if (obj is not Produkt ex)
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

        public static readonly PropertyData FilteredProperty =
            RegisterProperty(nameof(ProduktView), typeof(ICollectionView));

        public static readonly PropertyData SuchTextProperty =
            RegisterProperty(nameof(SuchText), typeof(string));

        public static readonly PropertyData ProduktListeProperty =
            RegisterProperty(nameof(ProduktListe), typeof(ObservableCollection<Produkt>));

        public static readonly PropertyData SelectedProduktProperty =
            RegisterProperty(nameof(SelectedProdukt), typeof(Produkt));
    }
}