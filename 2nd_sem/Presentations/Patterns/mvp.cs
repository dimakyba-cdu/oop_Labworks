// Інтерфейс для View
public interface IWeatherView
{
    string CityInput { get; }
    void ShowWeather(string weatherInfo);
    void ShowError(string message);
}

// Інтерфейс для Model
public interface IWeatherModel
{
    string GetWeather(string city);
}

public class WeatherModel : IWeatherModel
{
    public string GetWeather(string city)
    {
        // Імітація запиту до API погоди
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Назва міста не може бути порожньою");

        // В реальному додатку тут буде HTTP-запит до API
        return $"Погода в {city}: 25°C, ясно, вологість 60%";
    }
}

public class WeatherPresenter
{
    private readonly IWeatherView _view;
    private readonly IWeatherModel _model;

    public WeatherPresenter(IWeatherView view, IWeatherModel model)
    {
        _view = view;
        _model = model;
    }

    public void UpdateWeather()
    {
        try
        {
            string city = _view.CityInput;
            string weatherInfo = _model.GetWeather(city);
            _view.ShowWeather(weatherInfo);
        }
        catch (Exception ex)
        {
            _view.ShowError($"Помилка: {ex.Message}");
        }
    }
}

public class ConsoleWeatherView : IWeatherView
{
    public string CityInput
    {
        get
        {
            Console.Write("Введіть місто: ");
            return Console.ReadLine();
        }
    }

    public void ShowWeather(string weatherInfo)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(weatherInfo);
        Console.ResetColor();
    }

    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public class WinFormsWeatherView : Form, IWeatherView
{
    private TextBox cityTextBox;
    private Button getWeatherButton;
    private Label resultLabel;

    public string CityInput => cityTextBox.Text;

    public WinFormsWeatherView()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Ініціалізація елементів управління
        cityTextBox = new TextBox { Width = 200 };
        getWeatherButton = new Button { Text = "Отримати погоду" };
        resultLabel = new Label { AutoSize = true };

        // Розміщення елементів
        Controls.Add(cityTextBox);
        Controls.Add(getWeatherButton);
        Controls.Add(resultLabel);

        // Позиціонування
        cityTextBox.Location = new Point(10, 10);
        getWeatherButton.Location = new Point(220, 10);
        resultLabel.Location = new Point(10, 40);
    }

    public void ShowWeather(string weatherInfo)
    {
        resultLabel.ForeColor = Color.Green;
        resultLabel.Text = weatherInfo;
    }

    public void ShowError(string message)
    {
        resultLabel.ForeColor = Color.Red;
        resultLabel.Text = message;
    }

    public void SetPresenter(WeatherPresenter presenter)
    {
        getWeatherButton.Click += (sender, e) => presenter.UpdateWeather();
    }
}

class Program
{
    static void Main()
    {
        // Вибираємо реалізацію View
        Console.WriteLine("Оберіть інтерфейс: 1 - Консоль, 2 - WinForms");
        var choice = Console.ReadLine();

        IWeatherView view;
        if (choice == "1")
        {
            view = new ConsoleWeatherView();
        }
        else
        {
            Application.EnableVisualStyles();
            view = new WinFormsWeatherView();
        }

        // Створюємо Model і Presenter
        var model = new WeatherModel();
        var presenter = new WeatherPresenter(view, model);

        if (view is WinFormsWeatherView winFormsView)
        {
            winFormsView.SetPresenter(presenter);
            Application.Run(winFormsView);
        }
        else
        {
            while (true)
            {
                presenter.UpdateWeather();
                Console.WriteLine("Натисніть Enter для продовження або 'q' для виходу");
                if (Console.ReadLine() == "q") break;
            }
        }
    }
}
