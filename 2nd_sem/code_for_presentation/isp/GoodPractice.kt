interface Serve {
    fun serve()
}

interface Cook {
    fun cook()
}

class Waiter : Serve {
    override fun serve() {/* Тільки свої функції */}
}
