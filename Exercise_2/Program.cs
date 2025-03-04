class Program
{
    private static void Main()
    {
        int[][] numbers = [[2, 2, 1], [4, 1, 2, 1, 2], [1]];

        foreach (int[] array in numbers)
        {
            PrintNonRepeatingNumber(array);
        }
    }

    /// <summary>
    ///     Search for a non repeating number in the array
    ///     and print it if there is
    /// </summary>
    /// <param name="numbers">
    ///     The array of numbers
    /// </param>
    private static void PrintNonRepeatingNumber(int[] numbers)
    {
        HashSet<int> checkedNumbers = [];

        foreach (int n in numbers)
        {
            if (checkedNumbers.Contains(n))
            {
                // If hash set already contains this number, remove it
                checkedNumbers.Remove(n);
            } else
            {
                checkedNumbers.Add(n);
            }
        }

        // Given the task's requirement that there will always be one non repeating number,
        // just print the first element of the hash set
        Console.WriteLine(checkedNumbers.First());
    }
}