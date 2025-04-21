using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace happiness;
public partial class MainWindow : Window
{
    private Random _random = new Random();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void YesButton_MouseEnter(object sender, MouseEventArgs e)
    {
        double maxX = ActualWidth - YesButton.ActualWidth - 40;
        double maxY = ActualHeight - YesButton.ActualHeight - 80;

        double newX = _random.NextDouble() * maxX;
        double newY = _random.NextDouble() * maxY;

        Canvas.SetLeft(YesButton, newX);
        Canvas.SetTop(YesButton, newY);
    }

    private void NoButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("i hate your approach to life.", "wrong answer",
            MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void YesButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("i respect your lust for life.", "right answer",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }


    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.FocusedElement == YesButton)
        {
            NoButton.Focus();
        }
    }
}
