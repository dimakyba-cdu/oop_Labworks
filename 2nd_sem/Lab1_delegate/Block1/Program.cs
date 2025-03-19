namespace TimerLab
{
  public class Program
  {
    public static void CustomMethod1()
    {
      Console.WriteLine("Started from the bottom now we still there");
    }
    public static void CustomMethod2()
    {
      Console.WriteLine("Don't be a fool get a pool");

    }

    static void Main()
    {
      Timer timer1 = new(CustomMethod1, 1000);
      Timer timer2 = new(CustomMethod2, 500);
      Console.ReadLine();
      timer1.Stop();

      Console.ReadLine();
      timer2.Stop();
    }
  }

  public class Timer
  {
    private int _time;
    public delegate void Method();
    private bool isActive;
    private Thread timerThread;

    public Timer(Method meth, int time)
    {
      _time = time;
      isActive = true;
      timerThread = new Thread(() => Start(meth));
      timerThread.IsBackground = true;
      timerThread.Start();
    }

    private void Start(Method meth)
    {
      while (isActive)
      {
        meth();
        Thread.Sleep(_time);
      }
    }

    public void Stop()
    {
      isActive = false;
      if (timerThread.IsAlive)
      {
        timerThread.Join();
      }
    }
  }


}
