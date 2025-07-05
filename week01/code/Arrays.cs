

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[]
    MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of given length
        double[]
        result = new double[length];

        // Step 2: Fill array with multiples of the number
        for (int i = 0; i < length; i++)
        {
            result[i] = (i + 1) * number;
        }

        // Step 3: Return the filled array
        return result;
    }

    /// <summary>
    /// Rotates the 'data' list to the right by 'amount', in-place (without using extra lists).
    /// For example, rotating List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} by 3 results in:
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}
    /// </summary>
    public static void
    RotateListRight(List<int> data, int amount)
    {
        int n = data.Count;

        // Normalize amount in case it's greater than list size
        amount = amount % n;

        // Reverse the entire list
        Reverse(data, 0, n - 1);

        // Reverse the first 'amount' elements
        Reverse(data, 0, amount - 1);

        // Reverse the remaining elements
        Reverse(data, amount, n - 1);
    }

    // Helper method to reverse part of a list in-place
    private static void
    Reverse(List<int> list, int start, int end)
    {
        while (start < end)
        {
            int temp = list[start];
            list[start] = list[end];
            list[end] = temp;

            start++;
            end--;
        }
    }
}


