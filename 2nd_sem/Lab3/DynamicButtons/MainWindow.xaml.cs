﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DynamicButtons;

public partial class MainWindow : Window
{
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

        var toRemove = ButtonsPanel.Children
            .OfType<Button>()
            .Where(b => int.TryParse(b.Content.ToString(), out int value) && value % multiple == 0)
            .ToList();

        foreach (var btn in toRemove)
        {
            ButtonsPanel.Children.Remove(btn);
        }
    }

    private void GenerateButtons(int from, int to, int step)
    {
        for (int i = from; step > 0 ? i <= to : i >= to; i += step)
        {
            int number = i;

            Button btn = new Button
            {
                Content = number.ToString(),
                Margin = new Thickness(5),
                Padding = new Thickness(5, 2, 5, 2),
                MinWidth = 30,
                HorizontalAlignment = HorizontalAlignment.Left,
                Tag = null
            };

            btn.Click += (sender, args) =>
            {
                Button clickedButton = sender as Button;
                if (clickedButton == null) return;

                if (clickedButton.Tag is string result)
                {
                    MessageBox.Show($"stop clicking bro\n{result}");
                }
                else
                {
                    string newResult = CheckPrimeOrComposite(number);
                    clickedButton.Tag = newResult;
                    MessageBox.Show(newResult);
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
