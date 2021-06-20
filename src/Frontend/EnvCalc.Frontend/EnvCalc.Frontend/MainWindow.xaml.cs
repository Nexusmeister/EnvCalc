using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Catel.MVVM;
using Catel.Windows;
using EnvCalc.Frontend.Commands;

namespace EnvCalc.Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DataWindow
    {
        public MainWindow() : base(DataWindowMode.Custom)
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += Close;
                Closing += (s, x) =>
                {
                    x.Cancel = !vm.CanClose();
                };
            }
        }
    }
}
