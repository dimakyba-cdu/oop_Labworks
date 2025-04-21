public class MySQLDatabase {
    public void SaveData(string data) {
        Console.WriteLine($"Зберігаю дані в MySQL: {data}");
    }
}

public class ReportService {
    private MySQLDatabase _database = new MySQLDatabase(); // Пряма залежність! Погано!

    public void GenerateReport() {
        _database.SaveData("Звіт 2024");
    }
}
