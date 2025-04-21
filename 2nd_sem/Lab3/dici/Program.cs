using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DynamicButtons;

public partial class MainWindow : Window
{
  private readonly Dictionary<int, (bool isClicked, string result)> clickStates = new();

  public MainWindow()
  {
    InitializeComponent();
    GenerateButton.Click += GenerateButton_Click;
  }

  private void GenerateButton_Click(object sender, RoutedEventArgs e)
  {
    if (!int.TryParse(FromTextBox.Text, out int n) ||
        !int.TryParse(ToTextBox.Text, out int k) ||
        !int.TryParse(StepTextBox.Text, out int s) || s <= 0)
    {
      MessageBox.Show("Введите корректные целые числа для From, Till и положительное Step.", "Ошибка ввода",
          MessageBoxButton.OK, MessageBoxImage.Warning);
      return;
    }

    ButtonsPanel.Children.Clear();
    clickStates.Clear();
    GenerateSampleButtons(n, k, s);
  }

  private void GenerateSampleButtons(int n, int k, int s)
  {
    for (int i = n; i <= k; i += s)
    {
      int number = i;

      Button btn = new Button
      {
        Content = number.ToString(),
        Margin = new Thickness(5),
        Padding = new Thickness(5, 2, 5, 2),
        MinWidth = 30,
        HorizontalAlignment = HorizontalAlignment.Left
      };

      btn.Click += (sender, args) =>
      {
        if (number < 1)
        {
          MessageBox.Show($"Число {number} не проходит проверку (меньше 1)");
          return;
        }

        if (!clickStates.TryGetValue(number, out var state))
        {
          // Первый клик
          string result = CheckPrimeOrComposite(number);
          clickStates[number] = (true, result);
          MessageBox.Show(result);
        }
        else
        {
          // Повторный клик
          MessageBox.Show($"Ну сколько можно нажимать, бро...\n{state.result}");
        }
      };

      ButtonsPanel.Children.Add(btn);
    }
  }

  private string CheckPrimeOrComposite(int n)
  {
    if (n < 0)
    {
      return $"Число {n} ніяке, не просте і не складене";
    }

    if (n == 1)
    {
      return "Число 1 — ні просте, ні складене";
    }

    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
      if (n % i == 0)
      {
        return $"Число {n} складене, бо поділилося на {i}";
      }
    }

    return $"Число {n} просте";
  }
}
