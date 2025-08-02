using System.Collections;
using System.Collections.Generic;
public static class Recursion
{
    
    // Problem 1: Sum of squares recursively
    public static int SumSquaresRecursive(int n)
    {if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }
// Problem 2: Permutations choose recursively
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
      if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();
         if (s < 0) return 0;
        if (s == 0) return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) +  CountWaysToClimb(s - 3, remember);
                        

        remember[s] = result;
        return result;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string prefix = pattern[..index];
        string suffix = pattern[(index + 1)..];

        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
{
    // Initialize path on first call
    if (currPath == null)
        currPath = new List<(int, int)>();

    // If move is invalid, return
    if (!maze.IsValidMove(currPath, x, y))
        return;

    // Add current position to path
    currPath.Add((x, y));

    // If we've reached the end, add current path to results
    if (maze.IsEnd(x, y))
    {
        results.Add(currPath.AsString()); // use extension method
    }
    else
    {
        // Explore all 4 directions
        SolveMaze(results, maze, x + 1, y, currPath); // Right
        SolveMaze(results, maze, x - 1, y, currPath); // Left
        SolveMaze(results, maze, x, y + 1, currPath); // Down
        SolveMaze(results, maze, x, y - 1, currPath); // Up
    }

    // Backtrack: remove last position to try other paths
    currPath.RemoveAt(currPath.Count - 1);
}
}