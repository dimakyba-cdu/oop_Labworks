interface IFlyable
{
    void Fly();
}

public class Bird
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Some bird sound");
    }
}

// Пінгвін - це птах, але не вміє літати
public class Penguin : Bird
{
    public void Swim()
    {
        Console.WriteLine("Penguin swimming");
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Penguin sound");
    }
}

// Папуга - це птах, який вміє літати
public class Parrot : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Parrot flying");
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Parrot sound");
    }
}

class Program
{
    // Клієнтський код, який працює з птахами
    static void InteractWithBird(Bird bird)
    {
        bird.MakeSound();
        
        // Можна додатково перевірити, чи птах вміє літати
        if (bird is IFlyable flyableBird)
        {
            flyableBird.Fly();
        }
    }

    // Клієнтський код, який працює з літаючими об'єктами
    static void MakeFly(IFlyable flyable)
    {
        flyable.Fly();
    }

    static void Main(string[] args)
    {
        var penguin = new Penguin();
        var parrot = new Parrot();
        
        // Працюємо з птахами
        InteractWithBird(penguin);  // Виведе: Penguin sound
        InteractWithBird(parrot);   // Виведе: Parrot sound та Parrot flying
        
        // Працюємо тільки з літаючими об'єктами
        MakeFly(parrot);            // Виведе: Parrot flying
        // MakeFly(penguin);        // Не скомпілюється, бо пінгвін не реалізує IFlyable
    }
}