using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class MatrixCollection
    {
        internal void printSpiralmatrix(int[,] matrixInput)
        {
            int left = 0, top = 0;
            int right = matrixInput.GetUpperBound(1), bottom = matrixInput.GetUpperBound(0);
            int k = 0;
            while (k <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++)
                {
                    Console.WriteLine(matrixInput[k, i]);
                }
                k++;

                for (int i = k; i <= bottom; i++)
                {
                    Console.WriteLine(matrixInput[i, right]);
                }
                right--;
                if (k <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        Console.WriteLine(matrixInput[bottom, i]);
                    }
                    bottom--;
                }
                if (left <= right)
                {
                    for (int i = bottom; i >= k; i--)
                    {
                        Console.WriteLine(matrixInput[i, left]); ;
                    }
                    left++;
                }
            }

        }
        internal void mergeIntervals(int[,] intervals)
        {
            // Sort the array of elements (Compare the first item in all the arrays)
            //Array.Sort(intervals, new Comparison<int[]>((i1, i2) => i1[0].CompareTo(i2[0])));
            //Array.Sort(intervals, (a,b) => int.comp )
            //intervals.OrderBy();

        }

        internal void insertInterval(int[,] intervals, int[] newInterval)
        {
            IList<int[]> merged = new List<int[]>();
            //    bool newIntervalMerged = false;  // Not added new interval Yet

            //    foreach (var interval in intervals)
            //    {
            //        //If List is empty and newInterval start value is less than current Interval
            //        if (merged.Count() == 0)
            //        {
            //            calcuate(newInterval, interval, ref merged);
            //        }
            //        else
            //        {
            //            int[] lastItemFromtheList = merged.LastorDefault();

            //            if (newIntervalMerged)
            //            {
            //                calcuate(interval, lastItemFromtheList, merged);
            //            }
            //            else
            //            {
            //                calcuate(newInterval, interval);
            //                calcuate(lastItemFromtheList, interval, merged);
            //            }

            //        }
            //}
        }

        //public void calcuate(int[] newInterval, int[] interval,  ref IList<int[]> merged)
        //{
        //    if (newInterval[0] < interval[0])
        //    {
        //        //if new interval is able to merget with first interval then we need merge them
        //        if (newInterval[1] > interval[0])
        //        {
        //            newInterval[1] = interval[1];
        //            merged.Add(newInterval);
        //        }
        //        // If new interval is not mapping then we need to add newInterval and Interval to the List
        //        else
        //        {
        //            merged.Add(newInterval);
        //            merged.Add(interval);
        //        }
        //        newIntervalMerged = true;
        //    }
        //    else
        //    {
        //        merged.Add(interval);
        //    }
        //}

        internal int[,] GenerateMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            if (n == 0) return matrix;

            if (n == 1)
            {
                matrix[0, 0] = 1;
                return matrix;
            }

            int colStart = 0, rowStart = 0, rows = n - 1, cols = n - 1, startValue = 1;

            while (rows != 0 && cols != 0 && rows == cols)
            {
                for (int i = colStart; i <= cols; i++)
                {
                    matrix[rowStart, i] = startValue;
                    startValue++;
                }
                rowStart++;

                for (int i = rowStart; i <= cols; i++)
                {
                    matrix[i, cols] = startValue;
                    startValue++;
                }
                cols--;

                for (int i = cols; i >= colStart; i--)
                {
                    matrix[rows, i] = startValue;
                    startValue++;
                }
                rows--;

                for (int i = rows; i >= rowStart; i--)
                {
                    matrix[i, colStart] = startValue;
                    startValue++;
                }
                colStart++;

            }


            return matrix;
        }

        internal int UniquePaths(int m, int n)
        {
            // Recursive.
            //return UniquePathsRecursive(m, n);

            //DP
            int[,] matrix = new int[m, n];

            for (int i = 1; i < n; i++)
            {
                matrix[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                matrix[i, 0] = 1;
            }

            for (int col = 1; col < m; col++)
            {
                for (int row = 1; row < n; row++)
                {
                    matrix[col, row] = matrix[col - 1, row] + matrix[col, row - 1];
                }
            }

            return matrix[m - 1, n - 1];

        }

        private int UniquePathsRecursive(int m, int n)
        {
            if (m == 1 || n == 1)
            {
                return 1;
            }

            return UniquePaths(m - 1, n) + UniquePaths(m, n - 1);
        }

        internal int UniquePathwithObstacles(int[,] matrixInput)
        {
            int rows = matrixInput.GetUpperBound(0);
            int cols = matrixInput.GetUpperBound(1);

            if (matrixInput[0, 0] == 1)
            {
                return 0;
            }

            matrixInput[0, 0] = 1;

            for (int i = 1; i <= rows; i++)
            {
                matrixInput[i, 0] = matrixInput[i, 0] == 0 && matrixInput[i - 1, 0] == 1 ? 1 : 0;
            }
            for (int i = 1; i <= cols; i++)
            {
                matrixInput[0, i] = matrixInput[0, i] == 0 && matrixInput[0, i - 1] == 1 ? 1 : 0;
            }

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrixInput[i, j] == 0)
                    {
                        matrixInput[i, j] = matrixInput[i - 1, j] + matrixInput[i, j - 1];
                    }
                    else
                    {
                        matrixInput[i, j] = 0;
                    }
                }
            }

            return matrixInput[rows, cols];
        }

        internal int MinPathSum(int[,] matrixInput)
        {
            int rowsCount = matrixInput.GetUpperBound(0); // GetUpperBound is 0 based, and GetLength is 1 based (Starting index)
            int colsCount = matrixInput.GetUpperBound(1);
            int minPathSum = 0;

            //Recursive Logic.
            //minPathSum = MinPathSumRecursive(matrixInput, 0, 0);

            //using DP.
            minPathSum = MindPathSumDP(matrixInput, rowsCount, colsCount);

            return minPathSum;
        }

        private int MindPathSumDP(int[,] matrixInput, int rowsCount, int colsCount)
        {
            // Created new 2D array (or) update the same 2D array (or) take 1D array with size of the matrix.
            // Fill the last element as the same as the original array.
            // First complete the last row (From last) by adding the i,j value
            // Second complete last cell in each row by copying the bottom cell value. (Do the same of all other rows)
            // Third complete all other cells by taking the min of next cell (or) bottom cell + current cell value.

            int[,] newMatrix = new int[rowsCount + 1, colsCount + 1];
            for (int i = rowsCount; i >= 0; i--)
            {
                for (int j = colsCount; j >= 0; j--)
                {
                    if (i == rowsCount && j == colsCount)
                    {
                        newMatrix[i, j] = matrixInput[i, j];
                    }
                    //Last row
                    else if (i == rowsCount && j != colsCount)
                    {
                        newMatrix[i, j] = matrixInput[i, j] + newMatrix[i, j + 1];
                    }
                    // Last cell
                    else if (i != rowsCount && j == colsCount)
                    {
                        newMatrix[i, j] = matrixInput[i, j] + newMatrix[i + 1, j];
                    }
                    //Other cells.
                    else
                    {
                        newMatrix[i, j] = matrixInput[i, j] + Math.Min(newMatrix[i + 1, j], newMatrix[i, j + 1]);
                    }
                }
            }
            return newMatrix[0, 0];
        }

        private int MinPathSumRecursive(int[,] matrixInput, int i, int j)
        {
            int rowsCount = matrixInput.GetUpperBound(0); // GetUpperBound is 0 based, and GetLength is 1 based (Starting index)
            int colsCount = matrixInput.GetUpperBound(1);

            if (i > rowsCount || j > colsCount) { return int.MaxValue; }

            if (i == rowsCount && j == colsCount) { return matrixInput[i, j]; }

            return matrixInput[i, j] + Math.Min(MinPathSumRecursive(matrixInput, i + 1, j), MinPathSumRecursive(matrixInput, i, j + 1));

        }
    }
}
