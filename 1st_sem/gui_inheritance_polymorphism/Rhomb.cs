public class Rhomb : Figure
{
  private int HorDiagLen, VertDiagLen;

  public Rhomb(int x, int y, int horDiagLen, int vertDiagLen, Color backgroundColor) : base(x, y, backgroundColor)
  {
    HorDiagLen = horDiagLen;
    VertDiagLen = vertDiagLen;
  }

  public override void DrawBlack(Graphics g)
  {
    using (Pen pen = new Pen(Color.Black))
    {
      Point[] points =
      {
        new Point(CenterX, CenterY - VertDiagLen / 2),
        new Point(CenterX + HorDiagLen / 2, CenterY),
        new Point(CenterX, CenterY + VertDiagLen / 2),
        new Point(CenterX - HorDiagLen / 2, CenterY)
      };
      g.DrawPolygon(pen, points);
    }
  }

  public override void HideDrawingBackGround(Graphics g)
  {
    using (Pen pen = new Pen(BackgroundColor))
    {
      Point[] points =
      {
        new Point(CenterX, CenterY - VertDiagLen / 2),
        new Point(CenterX + HorDiagLen / 2, CenterY),
        new Point(CenterX, CenterY + VertDiagLen / 2),
        new Point(CenterX - HorDiagLen / 2, CenterY)
      };
      g.DrawPolygon(pen, points);
    }
  }
}
