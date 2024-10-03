class ArithmeticProgression
{
  private int firstElement;
  private int difference;
  private int amount;

  public int FirstElement
  {
    get { return firstElement; }
    set { firstElement = value; }
  }

  public int Difference
  {
    get { return difference; }
    set { difference = value; }
  }

  public int Amount
  {
    get { return amount; }
    set { amount = value; }
  }

  public ArithmeticProgression(int firstElement, int difference, int amount)
  {
    this.firstElement = firstElement;
    this.difference = difference;
    this.amount = amount;
  }

  public ArithmeticProgression()
  {
    this.firstElement = 0;
    this.difference = 0;
    this.amount = 0;
  }

  public int this[int index]
  {
    get
    {
      return firstElement + index * difference;
    }
  }

  public int SumOfSequence()
  {
    return (amount * (2 * firstElement + (amount - 1) * difference)) / 2;
  }

}
