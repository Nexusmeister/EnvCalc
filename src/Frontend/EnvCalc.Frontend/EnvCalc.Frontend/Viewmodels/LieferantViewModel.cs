using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.BusinessObjects;
using EnvCalc.Tools;
using EnvCalc.Tools.Extensions;

namespace EnvCalc.Frontend.ViewModels
{
    public class LieferantViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title => "Lieferantensicht";

        /// <summary>
        /// Gets or sets whether the user has agreed to continue.
        /// </summary>
        public ObservableCollection<Exchange> ProzessListe
        {
            get => GetValue<ObservableCollection<Exchange>>(ProzessListeProperty);
            set => SetValue(ProzessListeProperty, value);
        }

        public ICollectionView ProzessView
        {
            get => GetValue<ICollectionView>(FilteredProperty);
            set => SetValue(FilteredProperty, value);
        }

        public Command MyAction { get; private set; }

        public string SuchText
        {
            get => GetValue<string>(SuchTextProperty);
            set
            {
                SetValue(SuchTextProperty, value);
                // Damit bei einer neuen Suche immer wieder die volle Liste angezeigt wird
                // Das geht bestimmt smarter, aber zumindest funktioniert das
                if (SuchText is not null && value is "" && ProzessView is not null) 
                {
                    ProzessView.Filter = null;
                }
                else if(ProzessView is not null && ProzessView.Filter is null && SuchText is not null && value is not "")
                {
                    ProzessView.Filter = SucheProzess;
                }

                ProzessView?.Refresh();
            }
        }

        /// <summary>
        /// Register the UserAgreedToContinue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ProzessListeProperty = 
            RegisterProperty(nameof(ProzessListe), typeof(ObservableCollection<Exchange>));

        public static readonly PropertyData FilteredProperty =
            RegisterProperty(nameof(ProzessView), typeof(ICollectionView));

        public static readonly PropertyData SuchTextProperty =
            RegisterProperty(nameof(SuchText), typeof(string));

        public LieferantViewModel()
        {
            HoleProzessliste();
        }

        private async void HoleProzessliste()
        {
            Thread.Sleep(100);
            var liste = await BackendDataAccess.Instance.GetAll();
            ProzessListe = liste.ToObservableCollection();
            ProzessView = CollectionViewSource.GetDefaultView(ProzessListe);

            ProzessView.Filter = SucheProzess;
        }

        private bool SucheProzess(object obj)
        {
            if (obj is not Exchange ex)
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

            return ex.Titel.Contains(suche, StringComparison.InvariantCultureIgnoreCase);
        }
        
    }
}