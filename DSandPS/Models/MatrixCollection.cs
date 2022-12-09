using System;
using System.Collections.Generic;
using System.Linq;
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
            bool newIntervalMerged = false;  // Not added new interval Yet

            foreach (var interval in intervals)
            {
                //If List is empty and newInterval start value is less than current Interval
                if (merged.Count() == 0)
                {
                    calcuate(newInterval, interval, ref merged);
                }
                else
                {
                    int[] lastItemFromtheList = merged.LastorDefault();

                    if (newIntervalMerged)
                    {
                        calcuate(interval, lastItemFromtheList, merged);
                    }
                    else
                    {
                        calcuate(newInterval, interval);
                        calcuate(lastItemFromtheList, interval, merged);
                    }

                }
            }
        }

        public void calcuate(int[] newInterval, int[] interval,  ref IList<int[]> merged)
        {
            if (newInterval[0] < interval[0])
            {
                //if new interval is able to merget with first interval then we need merge them
                if (newInterval[1] > interval[0])
                {
                    newInterval[1] = interval[1];
                    merged.Add(newInterval);
                }
                // If new interval is not mapping then we need to add newInterval and Interval to the List
                else
                {
                    merged.Add(newInterval);
                    merged.Add(interval);
                }
                newIntervalMerged = true;
            }
            else
            {
                merged.Add(interval);
            }
        }
    }
}
