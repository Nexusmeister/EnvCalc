using System.Collections.ObjectModel;
using Catel.Data;
using Catel.MVVM;
using EnvCalc.BusinessObjects;

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
        public ObservableCollection<Prozess> ProzessListe
        {
            get => GetValue<ObservableCollection<Prozess>>(ProzessListeProperty);
            set => SetValue(ProzessListeProperty, value);
        }

        /// <summary>
        /// Register the UserAgreedToContinue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ProzessListeProperty = 
            RegisterProperty(nameof(ProzessListe), typeof(ObservableCollection<Prozess>));

        public LieferantViewModel()
        {
            ProzessListe = new ObservableCollection<Prozess>()
            {
                new Prozess()
                {
                    Id = "123123",
                    Titel = "NeuerTest"
                }
            };
        }
    }
}