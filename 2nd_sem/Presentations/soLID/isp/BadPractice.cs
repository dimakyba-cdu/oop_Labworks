public interface IWorker {
    void Cook();
    void Serve();
}

public class Waiter : IWorker {
    public void Cook() { /* Не потрібно!*/ }
    public void Serve() { /* Так */ }
    public void WashDishes()  { /* Інколи ;) */ }
}
