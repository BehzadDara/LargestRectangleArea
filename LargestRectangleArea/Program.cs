#region Problem
/*
Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, 
return the area of the largest rectangle in the histogram.

Example 1:
Input: heights = [2,1,5,6,2,3]
Output: 10
Explanation: The above is a histogram where width of each bar is 1.
The largest rectangle is shown in the red area, which has an area = 10 units.

Example 2:
Input: heights = [2,4]
Output: 4

LeetCode link: https://leetcode.com/problems/largest-rectangle-in-histogram/description/
*/
#endregion

#region Solution

Console.WriteLine(LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 }));
static int LargestRectangleArea(int[] heights)
{
    var furthestHigherLeftNeighbor = new int[heights.Length];
    var furthestHigherRightNeighbor = new int[heights.Length];

    for (int i = 0; i < heights.Length; i++)
    {
        var left = i - 1;
        while (left > 0 && heights[left] >= heights[i])
        {
            left = furthestHigherLeftNeighbor[left];
        }
        furthestHigherLeftNeighbor[i] = left;
    }
    for (int i = heights.Length - 1; i >= 0; i--)
    { 
        var right = i + 1;
        while (right < heights.Length - 1 && heights[right] >= heights[i])
        {
            right = furthestHigherRightNeighbor[right];
        }
        furthestHigherRightNeighbor[i] = right;
    }

    var result = 0;

    for (int i = 0; i < heights.Length; i++)
    {
        result = Math.Max(result, heights[i] * (furthestHigherRightNeighbor[i] - furthestHigherLeftNeighbor[i] - 1));
    }

    return result;
}

#endregion