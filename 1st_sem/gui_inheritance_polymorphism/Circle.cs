public class Circle : Figure
{
  private int Radius;

  public Circle(int x, int y, int radius, Color backgroundColor) : base(x, y, backgroundColor)
  {
    Radius = radius;
  }

  public override void DrawBlack(Graphics g)
  {
    using (Pen pen = new Pen(Color.Black))
    {
      g.DrawEllipse(pen, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
    }
  }

  public override void HideDrawingBackGround(Graphics g)
  {
    using (Pen pen = new Pen(BackgroundColor))
    {
      g.DrawEllipse(pen, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
    }
  }
}
