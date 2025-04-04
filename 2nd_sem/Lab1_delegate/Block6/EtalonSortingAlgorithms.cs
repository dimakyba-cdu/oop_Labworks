public partial class SortingAlgorithms
{
  // Еталонний метод сортування вибором
  public static void SelectionSort(int[] array)
  {
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
      int minIndex = i;
      for (int j = i + 1; j < n; j++)
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

  public static void ShakerSort(int[] array)
  {
    int n = array.Length;
    bool swapped;
    do
    {
      swapped = false;
      for (int i = 0; i < n - 2; i++)
      {
        if (array[i] > array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
          swapped = true;
        }
      }
      if (!swapped) break;
      swapped = false;
      for (int i = n - 2; i >= 0; i--)
      {
        if (array[i] >= array[i + 1])
        {
          int temp = array[i];
          array[i] = array[i + 1];
          array[i + 1] = temp;
          swapped = true;
        }
      }
    } while (swapped);
  }
}
