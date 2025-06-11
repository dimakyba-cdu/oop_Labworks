public class TodoModel
{
    private readonly List<string> _tasks = new List<string>();

    public void AddTask(string task)
    {
        if (!string.IsNullOrWhiteSpace(task))
            _tasks.Add(task);
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < _tasks.Count)
            _tasks.RemoveAt(index);
    }

    public IEnumerable<string> GetTasks() => _tasks;
}

public class TodoViewModel : INotifyPropertyChanged
{
    private readonly TodoModel _model;
    private string _newTask = "";

    public ObservableCollection<string> Tasks { get; } = new ObservableCollection<string>();
    public string NewTask
    {
        get => _newTask;
        set
        {
            _newTask = value;
            OnPropertyChanged(nameof(NewTask));
        }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand RemoveTaskCommand { get; }

    public TodoViewModel(TodoModel model)
    {
        _model = model;
        AddTaskCommand = new RelayCommand(AddTask);
        RemoveTaskCommand = new RelayCommand<int>(RemoveTask);
        LoadTasks();
    }

    private void AddTask()
    {
        _model.AddTask(NewTask);
        NewTask = "";
        LoadTasks();
    }

    private void RemoveTask(int index)
    {
        _model.RemoveTask(index);
        LoadTasks();
    }

    private void LoadTasks()
    {
        Tasks.Clear();
        foreach (var task in _model.GetTasks())
            Tasks.Add(task);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class RelayCommand : ICommand
{
    private readonly Action _execute;
    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action execute) => _execute = execute;
    public bool CanExecute(object parameter) => true;
    public void Execute(object parameter) => _execute();
}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action<T> execute) => _execute = execute;
    public bool CanExecute(object parameter) => true;
    public void Execute(object parameter) => _execute((T)parameter);
}

class Program
{
    static void Main()
    {
        var model = new TodoModel();
        var viewModel = new TodoViewModel(model);
        var view = new ConsoleTodoView(viewModel);

        view.Run();
    }
}
