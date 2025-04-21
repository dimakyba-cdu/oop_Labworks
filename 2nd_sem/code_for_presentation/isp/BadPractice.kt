interface Worker {
    fun cook()
    fun serve()
    fun washDishes()
}

class Waiter : Worker {
    override fun cook()  { /* не треба */ }
    override fun serve()  { /* так */ }
    override fun washDishes()  { /* інколи ;) */ }
}
