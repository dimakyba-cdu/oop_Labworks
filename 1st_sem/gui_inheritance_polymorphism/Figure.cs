public abstract class Figure
{
  protected int CenterX, CenterY;
  protected Color BackgroundColor;

  protected Figure(int x, int y, Color backgroundColor)
  {
    CenterX = x;
    CenterY = y;
    BackgroundColor = backgroundColor;
  }

  public abstract void DrawBlack(Graphics g);
  public abstract void HideDrawingBackGround(Graphics g);

  public void MoveRight(Graphics g, int distance)
  {
    for (int i = 0; i < distance; i++)
    {
      HideDrawingBackGround(g);
      CenterX+=2;
      DrawBlack(g);
      Thread.Sleep(100);
    }
  }
}
