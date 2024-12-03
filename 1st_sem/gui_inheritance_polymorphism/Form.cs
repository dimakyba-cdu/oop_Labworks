public class MainForm : Form
{
  private Figure currentFigure;

  public MainForm()
  {
    this.Text = "gui_inheritance_polymorphism";
    this.Width = 640;
    this.Height = 480;
    this.BackColor = Color.White;

    Button btnCircle = new Button { Text = "Circle", Top = 10, Left = 10 };
    btnCircle.Click += (s, e) =>
    {
      currentFigure = new Circle(100, 100, 50, this.BackColor);
      Invalidate();
    };

    Button btnSquare = new Button { Text = "Square", Top = 10, Left = 100 };
    btnSquare.Click += (s, e) =>
    {
      currentFigure = new Square(100, 100, 100, this.BackColor);
      Invalidate();
    };

    Button btnRhomb = new Button { Text = "Rhomb", Top = 10, Left = 200 };
    btnRhomb.Click += (s, e) =>
    {
      currentFigure = new Rhomb(100, 100, 120, 80, this.BackColor);
      Invalidate();
    };

    Button btnMoveRight = new Button { Text = "Move Right", Top = 10, Left = 300 };
    btnMoveRight.Click += (s, e) =>
    {
      if (currentFigure != null)
      {
        using (Graphics g = this.CreateGraphics())
        {
          currentFigure.MoveRight(g, 100);
        }
      }
    };

    Controls.Add(btnCircle);
    Controls.Add(btnSquare);
    Controls.Add(btnRhomb);
    Controls.Add(btnMoveRight);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    currentFigure?.DrawBlack(e.Graphics);
  }

}
