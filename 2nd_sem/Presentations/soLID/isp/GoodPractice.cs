public interface IServe {
    void Serve();
}

public interface ICook {
    void Cook();
}

public class Waiter : IServe {
    public void Serve() { /* Тільки свої функції*/ }
}
