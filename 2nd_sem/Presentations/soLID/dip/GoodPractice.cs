// easy-expandable code
public interface IDatabase
{
    void SaveData(string data);
}

public class MySQLDatabase : IDatabase
{
    public void SaveData(string data)
    {
        Console.WriteLine($"Зберігаю в MySQL: {data}");
    }
}

public class PostgreSQLDatabase : IDatabase
{
    public void SaveData(string data)
    {
        Console.WriteLine($"Зберігаю в PostgreSQL: {data}");
    }
}

public class FileStorage : IDatabase
{
    public void SaveData(string data)
    {
        File.WriteAllText("report.txt", data);
        Console.WriteLine($"Зберігаю в файл: {data}");
    }
}

public class ReportService
{
    private readonly IDatabase _database;

    public ReportService(IDatabase database)
    { // Залежність через інтерфейс!
        _database = database;
    }

    public void GenerateReport()
    {
        _database.SaveData("Звіт 2024");
    }
}

// dependency injection
var mySqlReport = new ReportService(new MySQLDatabase());
mySqlReport.GenerateReport(); // "Зберігаю в MySQL: Звіт 2024"

var postgresReport = new ReportService(new PostgreSQLDatabase());
postgresReport.GenerateReport(); // "Зберігаю в PostgreSQL: Звіт 2024"

var fileReport = new ReportService(new FileStorage());
fileReport.GenerateReport(); // Зберігає у файл "report.txt"
