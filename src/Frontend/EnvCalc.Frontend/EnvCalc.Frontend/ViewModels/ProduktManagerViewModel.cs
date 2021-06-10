using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Catel.Data;
using EnvCalc.BusinessObjects;

namespace EnvCalc.Frontend.ViewModels
{
    public class ProduktManagerViewModel : BaseViewModel
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
                else if (ExchangeView is not null && ExchangeView.Filter is null && SuchText is not null && value is not "")
                {
                    ExchangeView.Filter = SucheExchange;
                }

                ExchangeView?.Refresh();
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

        public static readonly PropertyData FilteredProperty =
            RegisterProperty(nameof(ExchangeView), typeof(ICollectionView));

        public static readonly PropertyData SuchTextProperty =
            RegisterProperty(nameof(SuchText), typeof(string));

        public static readonly PropertyData ExchangeListeProperty =
            RegisterProperty(nameof(ExchangeListe), typeof(ObservableCollection<Exchange>));
    }
}