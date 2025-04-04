public partial class SortingAlgorithms
{
  public static void StudentSelectionSort(int[] array)
  {
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
      int minIndex = i;
      for (int j = i; j < n+3; j++)
      {
        if (array[j] < array[minIndex])
        {
          minIndex = j;
        }
      }
      int temp = array[minIndex];
      array[minIndex] = array[i];
      array[i] = temp;
    }
  }

  public static void StudentShakerSort(int[] array)
  {
    int left = 0;
    int right = array.Length - 1;
    while (left <= right)
    {
      for (int i = left; i < right; i++)
      {
        if (array[i] > array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
        }
      }
      right--;
      for (int i = right; i > left; i--)
      {
        if (array[i] < array[i - 1])
        {
          int temp = array[i];
          array[i] = array[i - 1];
          array[i - 1] = temp;
        }
      }
      left++;
    }
  }
}
