using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class ArrayCollection
    {
        public int[] FindTwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            if (numbers.Length > 1)
            {
                //brute force:
                //for (int i = 0; i < numbers.Length - 1; i++)
                //{
                //    for (int j = i + 1; j < numbers.Length; j++)
                //    {
                //        if (numbers[i] + numbers[j] == target)
                //        {

                //            Console.WriteLine("the two idexes which sum is equal to target are " + i + "," + j);
                //            result[0] = i;
                //            result[1] = j;
                //return;

                //        }
                //    }
                //}


                //Find one element and subtract that with target and try to find another number.

                //for (int i = 0; i < numbers.Length; i++)                {
                //    //Check ith element is less than target

                //    int firstElement = numbers[i];
                //    int secondElementtoFind = target - firstElement;

                //    if (numbers.Contains(secondElementtoFind))
                //    {
                //        result[0] = i;
                //        for (int j = i + 1; j < numbers.Length; j++)
                //        {
                //            if (numbers[j] == secondElementtoFind)
                //            {
                //                result[1] = j;
                //                return result;
                //            }
                //        }
                //    }
                //}

                //using Hash Map
                Dictionary<int, int> dictNumbers = new Dictionary<int, int>();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int firstNumnber = numbers[i];
                    if (dictNumbers.TryGetValue(target - numbers[i], out int index))
                    {
                        return new[] { i, index };
                    }

                    dictNumbers[firstNumnber] = i;
                }
            }
            return result;
        }

        internal IList<IList<int>> FindAllUniqueTripletsWithZeroSum(int[] nums)

        {
            IList<IList<int>> result = new List<IList<int>>();
            SortedSet<string> set = new SortedSet<string>();

            //This will work but, it will give duplicate triplets (O(n^3)

            //for (int i = 0; i < nums.Length - 2; i++)
            //{
            //    for (int j = i + 1; j < nums.Length - 1; j++)
            //    {
            //        for (int k = j + 1; k < nums.Length; k++)
            //        {
            //            if (nums[i] + nums[j] + nums[k] == 0)
            //            {
            //                List<int> lstTriplets = new List<int>();
            //                lstTriplets.AddRange(new List<int> { nums[i], nums[j], nums[k] });

            //                string str = nums[i] + ":" + nums[j] + ":" + nums[k];

            //                if (!set.Contains(str))
            //                {
            //                    result.Add(lstTriplets);
            //                    set.Add(str);
            //                }
            //            }
            //        }
            //    }
            //}

            Array.Sort(nums);

            // Two pointers logic.

            //for (int i = 0; i < nums.Length - 2; i++)
            //{
            //    //Since array is sorted, if i element and previous elemens are same we can skip the loop and continue
            //    if (i > 0 && nums[i] == nums[i - 1])
            //    {
            //        continue;
            //    }

            //    //If current value is greater than break from the loop.
            //    if(nums[i] > 0)
            //    {
            //        continue;
            //    }

            //    int j = i + 1, k = nums.Length - 1;
            //    while (j < k)
            //    {
            //        int sum = nums[i] + nums[j] + nums[k];

            //        if (sum == 0)
            //        {
            //            string str = nums[i] + ":" + nums[j] + ":" + nums[k];
            //            if (!set.Contains(str))
            //            {
            //                set.Add(str);
            //                result.Add(new List<int> { nums[i], nums[j], nums[k] });
            //            }

            //            j++;
            //            k--;
            //        }
            //        else if (sum > 0)
            //        {
            //            k--;
            //        }
            //        else
            //        {
            //            j++;
            //        }
            //    }

            //}

            //Using HashSet

            for (int i = 0; i < nums.Length - 1 && nums[i] <= 0; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var seen = new HashSet<int>();
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    int complement = -nums[i] - nums[j];
                    if (seen.Contains(complement))
                    {
                        result.Add(new List<int> { nums[i], nums[j], complement });
                        while (j + 1 < nums.Length && nums[j] == nums[j + 1])
                            ++j;
                    }
                    seen.Add(nums[j]);
                }

            }


            return result;
        }

        internal int ThreeSumClosest(int[] nums, int target)
        {
            int arrSize = nums.Length;
            int diff = int.MaxValue;

            if (arrSize < 2)
            {
                Console.WriteLine("Invalid array Length");
                return 0;
            }
            Array.Sort(nums);

            for (int i = 0; i < arrSize - 2 && diff != 0; i++)
            {
                int lo = i + 1, hi = arrSize - 1;
                while (lo < hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (Math.Abs(target - sum) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }

                    if (sum < target)
                    {
                        ++lo;
                    }
                    else
                    {
                        --hi;
                    }
                }
            }
            return target - diff;
        }



        internal int threeSumSmaller(int[] nums, int target)
        {
            int arrSize = nums.Length;
            int smallerCount = 0;

            if (arrSize < 3)
            {
                return smallerCount;
            }
            //Brute force logic.- Getting time Limit Exceeded error

            //for (int i = 0; i < arrSize - 2; i++)
            //{
            //    for (int j = i + 1; j < arrSize - 1; j++)
            //    {
            //        for (int k = j + 1; k < arrSize; k++)
            //        {
            //            if (nums[i] + nums[j] + nums[k] < target)
            //            {
            //                smallerCount++;
            //            }
            //        }
            //    }
            //}

            // Using two pointers // O(nlogn + n2) = O(n2)
            // Declare Sum value as 0
            // Loop through n-2 elements 
            //Split this in to twoSmaller function (Which accepts array and target-num[i] -
            // As we are already having i element and will add this value to return value of two smaller function

            //in two smaller function, loop through all elements when left < right reaches, 
            // When find a pair (left + right <target) (That means all the pairts from left to right--, the condition is true).

            Array.Sort(nums);
            //for (int i = 0; i < arrSize - 2; i++)  // O(nlogn)
            //{
            //    smallerCount += twoSmaller(nums, i + 1, target - nums[i]);
            //}

            // Using Binary Search. (Just like two pointers, but we use binary search to find the right element
            for (int i = 0; i < arrSize - 2; i++)
            {
                smallerCount += twoSmallerBS(nums, i + 1, target - nums[i]);
            }

            return smallerCount;
        }

        private int twoSmallerBS(int[] nums, int startIndex, int target)
        {
            int sum = 0;
            for (int j = startIndex; j < nums.Length - 1; j++)
            {
                int k = binarySearch(nums, j, target - nums[j]);

                sum += k - j;
            }
            return sum;
        }

        private int binarySearch(int[] nums, int startIndex, int target)
        {
            int left = startIndex, right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right + 1) / 2;

                if (nums[mid] < target)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }

        private int twoSmaller(int[] nums, int startIndex, int target) // O(n) // but calling this in each itenration O(n2)
        {
            int sum = 0;

            int left = startIndex, right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] + nums[right] < target)
                {
                    sum += right - left;
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return sum;
        }

        internal int findTrianglecombiatonTripplets(int[] nums)
        {
            int count = 0;

            if (nums.Length == 0 || nums.Length < 3)
            {
                return count;
            }
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] > nums[k] && nums[i] + nums[k] > nums[j] && nums[j] + nums[k] > nums[i])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}

