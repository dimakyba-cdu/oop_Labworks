interface Database {
    fun saveData(data: String)
}

class MySQLDatabase : Database {
    override fun saveData(data: String) {
        println("Зберігаю в MySQL: $data")
    }
}

class PostgreSQLDatabase : Database {
    override fun saveData(data: String) {
        println("Зберігаю в PostgreSQL: $data")
    }
}

class FileStorage : Database {
    override fun saveData(data: String) {
        File("report.txt").writeText(data)
        println("Зберігаю в файл: $data")
    }
}

class ReportService(private val database: Database) { // Залежність через інтерфейс!
    fun generateReport() {
        database.saveData("Звіт 2024")
    }
}



// dependency injection
fun main() {
    val mySqlReport = ReportService(MySQLDatabase())
    mySqlReport.generateReport() // "Зберігаю в MySQL: Звіт 2024"

    val postgresReport = ReportService(PostgreSQLDatabase())
    postgresReport.generateReport() // "Зберігаю в PostgreSQL: Звіт 2024"

    val fileReport = ReportService(FileStorage())
    fileReport.generateReport() // Зберігає у файл "report.txt"
}
