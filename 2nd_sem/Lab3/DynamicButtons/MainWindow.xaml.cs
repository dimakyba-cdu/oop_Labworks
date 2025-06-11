using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DynamicButtons;

public partial class MainWindow : Window
{
    private ObservableCollection<ButtonModel> ButtonModels = new();

    public MainWindow()
    {
        InitializeComponent();
        GenerateButton.Click += GenerateButton_Click;
        DeleteButton.Click += DeleteButton_Click;
    }

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(FromTextBox.Text, out int from) ||
            !int.TryParse(ToTextBox.Text, out int to) ||
            !int.TryParse(StepTextBox.Text, out int step) || step == 0)
        {
            MessageBox.Show("Please enter valid integers for From, To, and non-zero Step.", "Input Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if ((step > 0 && from > to) || (step < 0 && from < to))
        {
            MessageBox.Show($"i wont create {(to - from) / step} buttons", "Logic Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        GenerateButtons(from, to, step);
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(MultipleTextBox.Text, out int multiple))
        {
            MessageBox.Show("Please enter a valid integer in the 'Multiple' field.", "Input Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (multiple == 0)
        {
            MessageBox.Show("Division by zero is not allowed.", "Math Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var toRemove = ButtonModels.Where(b => b.Number % multiple == 0).ToList();

        foreach (var model in toRemove)
        {
            ButtonModels.Remove(model);
            var buttonToRemove = ButtonsPanel.Children
                .OfType<Button>()
                .FirstOrDefault(b => int.TryParse(b.Content.ToString(), out int val) && val == model.Number);
            if (buttonToRemove != null)
                ButtonsPanel.Children.Remove(buttonToRemove);
        }
    }

    private void GenerateButtons(int from, int to, int step)
    {
        for (int i = from; step > 0 ? i <= to : i >= to; i += step)
        {
            var model = new ButtonModel { Number = i };
            ButtonModels.Add(model);

            Button btn = new Button
            {
                Content = model.Number.ToString(),
                Margin = new Thickness(5),
                Padding = new Thickness(5, 2, 5, 2),
                MinWidth = 30,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            btn.Click += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(model.PrimeStatus))
                {
                    MessageBox.Show($"stop clicking bro\n{model.PrimeStatus}");
                }
                else
                {
                    model.PrimeStatus = CheckPrimeOrComposite(model.Number);
                    MessageBox.Show(model.PrimeStatus);
                }
            };

            ButtonsPanel.Children.Add(btn);
        }
    }

    private string CheckPrimeOrComposite(int n)
    {
        if (n <= 1)
            return $"number {n} is neither prime nor composite.";

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return $"number {n} is composite because it is divisible by {i}";
        }

        return $"number {n} is prime";
    }
}

public class ButtonModel
{
    public int Number { get; set; }
    public string PrimeStatus { get; set; } = string.Empty;
}
