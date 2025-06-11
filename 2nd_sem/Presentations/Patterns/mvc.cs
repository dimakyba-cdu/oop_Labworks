// Модель статті
public class ArticleModel
{`
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public List<CommentModel> Comments { get; } = new List<CommentModel>();

    public void AddComment(CommentModel comment)
    {
        Comments.Add(comment);
    }
}

// Модель коментаря
public class CommentModel
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
}

public class ArticleView
{
    // Відображення статті з коментарями
    public void ShowArticle(ArticleModel article)
    {
        Console.WriteLine($"\n--- {article.Title} ---");
        Console.WriteLine(article.Content);
        Console.WriteLine("\nКоментарі:");

        foreach (var comment in article.Comments)
        {
            Console.WriteLine($"- {comment.Author}: {comment.Text}");
        }
    }

    // Відображення помилки
    public void ShowError(string message)
    {
        Console.WriteLine($"Помилка: {message}");
    }

    // Отримання введення користувача
    public (string author, string text) GetCommentInput()
    {
        Console.Write("Ваше ім'я: ");
        string author = Console.ReadLine();
        Console.Write("Текст коментаря: ");
        string text = Console.ReadLine();
        return (author, text);
    }
}

public class ArticleController
{
    private readonly ArticleModel _model;
    private readonly ArticleView _view;

    public ArticleController(ArticleModel model, ArticleView view)
    {
        _model = model;
        _view = view;
    }

    // Завантаження та відображення статті
    public void DisplayArticle(int id)
    {
        try
        {
            // На практиці тут буде запит до бази даних
            _model.Id = id;
            _model.Title = "Що таке MVC?";
            _model.Content = "MVC - це архітектурний шаблон...";

            _view.ShowArticle(_model);
        }
        catch (Exception ex)
        {
            _view.ShowError(ex.Message);
        }
    }

    // Додавання коментаря
    public void AddComment(string author, string text)
    {
        var comment = new CommentModel
        {
            Id = _model.Comments.Count + 1,
            Author = author,
            Text = text
        };
        _model.AddComment(comment);
        _view.ShowArticle(_model); // Оновлюємо відображення
    }
}
