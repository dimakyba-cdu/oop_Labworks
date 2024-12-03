public class Square : Figure
{
  private int SideLength;

  public Square(int x, int y, int sideLength, Color backgroundColor) : base(x, y, backgroundColor)
  {
    SideLength = sideLength;
  }

  public override void DrawBlack(Graphics g)
  {
    using (Pen pen = new Pen(Color.Black))
    {
      g.DrawRectangle(pen, CenterX - SideLength / 2, CenterY - SideLength / 2, SideLength, SideLength);
    }
  }

  public override void HideDrawingBackGround(Graphics g)
  {
    using (Pen pen = new Pen(BackgroundColor))
    {
      g.DrawRectangle(pen, CenterX - SideLength / 2, CenterY - SideLength / 2, SideLength, SideLength);
    }
  }
}
