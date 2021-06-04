using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        /// <summary>
        /// Register the UserAgreedToContinue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ProzessListeProperty = 
            RegisterProperty(nameof(ProzessListe), typeof(ObservableCollection<Exchange>));

        public LieferantViewModel()
        {
            HoleProzessliste();
        }

        private async Task HoleProzessliste()
        {
            var liste = await BackendDataAccess.Instance.GetAll();
            ProzessListe = liste.ToObservableCollection();
        }
    }
}