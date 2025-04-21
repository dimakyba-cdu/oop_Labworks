class MySQLDatabase {
    fun saveData(data: String) {
        println("Зберігаю дані в MySQL: $data")
    }
}

class ReportService {
    private val database = MySQLDatabase() // Пряма залежність! Погано!

    fun generateReport() {
        database.saveData("Звіт 2024")
    }
}
