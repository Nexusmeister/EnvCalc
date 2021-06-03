using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EnvCalc.Frontend.CustomControls
{
    /// <summary>
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        private readonly Thickness _leftSide = new(-39, 0, 0, 0);
        private readonly Thickness _rightSide = new(0, 0, -39, 0);
        private readonly SolidColorBrush _off = new(Color.FromRgb(160, 160, 160));
        private readonly SolidColorBrush _on = new(Color.FromRgb(130, 190, 125));
        private bool _toggled;

        public ToggleButton()
        {
            InitializeComponent();
            Back.Fill = _off;
            _toggled = false;
            Dot.Margin = _leftSide;
        }

        public bool Toggled1 { get => _toggled; set => _toggled = value; }

        private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_toggled)
            {
                Back.Fill = _on;
                _toggled = true;
                Dot.Margin = _rightSide;
            }
            else
            {
                Back.Fill = _off;
                _toggled = false;
                Dot.Margin = _leftSide;

            }
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_toggled)
            {
                Back.Fill = _on;
                _toggled = true;
                Dot.Margin = _rightSide;
            }
            else
            {
                Back.Fill = _off;
                _toggled = false;
                Dot.Margin = _leftSide;
            }
        }
    }
}
