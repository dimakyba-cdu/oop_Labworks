interface IFlyable {
    fun fly()
}

open class Bird {
    open fun makeSound() {
        println("Some bird sound")
    }
}

// Пінгвін - це птах, але не вміє літати
class Penguin : Bird() {
    fun swim() {
        println("Penguin swimming")
    }

    override fun makeSound() {
        println("Penguin sound")
    }
}

// Папуга - це птах, який вміє літати
class Parrot : Bird(), IFlyable {
    override fun fly() {
        println("Parrot flying")
    }

    override fun makeSound() {
        println("Parrot sound")
    }
}

// Клієнтський код, який працює з птахами
fun interactWithBird(bird: Bird) {
    bird.makeSound()

    // Можна додатково перевірити, чи птах вміє літати
    if (bird is IFlyable) {
        bird.fly()
    }
}

// Клієнтський код, який працює з літаючими об'єктами
fun makeFly(flyable: IFlyable) {
    flyable.fly()
}

fun main() {
    val penguin = Penguin()
    val parrot = Parrot()

    // Працюємо з птахами
    interactWithBird(penguin)  // Виведе: Penguin sound
    interactWithBird(parrot)   // Виведе: Parrot sound та Parrot flying

    // Працюємо тільки з літаючими об'єктами
    makeFly(parrot)            // Виведе: Parrot flying
    // makeFly(penguin)        // Не скомпілюється, бо пінгвін не реалізує IFlyable
}
