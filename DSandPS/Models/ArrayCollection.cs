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

            // Brute force (May get timeout error for big arrays).
            //for (int i = 0; i < nums.Length - 2; i++)
            //{
            //    for (int j = i + 1; j < nums.Length - 1; j++)
            //    {
            //        for (int k = j + 1; k < nums.Length; k++)
            //        {
            //            if (nums[i] + nums[j] > nums[k] && nums[i] + nums[k] > nums[j] && nums[j] + nums[k] > nums[i])
            //            {
            //                count++;
            //            }
            //        }
            //    }
            //}

            // Sort array elements
            // Take two elements i,j
            //Find the kth element where i+j > k matches.
            //Since the array is sorted , if we find the kth element (with i,j combination  we will be having (j+1)+(k-1)-1 entries

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int k = i + 2;
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    k = binarySearch(nums, k, nums.Length - 1, nums[i] + nums[j]);
                    count += k - j - 1;
                    if (count < 0)
                    {
                        count = 0;
                    }
                }
            }
            return count;
        }

        private int binarySearch(int[] nums, int left, int right, int sum)
        {
            while (left <= right && right < nums.Length)
            {
                int mid = (left + right + 1) / 2;
                if (nums[mid] >= sum)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        internal int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            int totalCalaries = 0;
            int points = 0;

            int start = 0;

            if (calories.Length < k || k < 0)
            {
                Console.WriteLine("Invalid input");
                return 0;
            }

            for (int i = 0; i < k; i++)
            {
                totalCalaries += calories[i];
            }


            for (int i = k; i < calories.Length; i++)
            {
                updatePoints(totalCalaries, lower, upper, ref points);
                totalCalaries -= calories[start++];
                totalCalaries += calories[i];
            }
            updatePoints(totalCalaries, lower, upper, ref points);
            return points;
        }

        private void updatePoints(int totalCalaries, int lower, int upper, ref int points)
        {

            if (totalCalaries < lower)
            {
                points--;
            }
            if (totalCalaries > upper)
            {
                points++;
            }
        }

        internal int LargestUniqueNumber(int[] nums)
        {
            int largetNumer = -1;

            if (nums.Length <= 0)
            {
                return largetNumer;
            }

            // Sort the array.
            Array.Sort(nums);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    return nums[i];
                }

                while (i > 0 && nums[i] == nums[i - 1])
                {
                    i--;
                }
            }

            return largetNumer;

        }

        internal string FindTicTacToeGameWinner(List<KeyValuePair<int, int>> moves)
        {
            // create a board
            //Board size
            int boardSize = 3;
            int[,] board = new int[boardSize, boardSize];
            int player = 1; // Player 1

            foreach (KeyValuePair<int, int> pair in moves)
            {
                int row = pair.Key;
                int col = pair.Value;

                // mark the current move and assign it to Players id (Starting is player 1)

                board[row, col] = player;

                //Check the winning condition with this move.

                if (checkRow(row, player, board, boardSize) || checkColumn(col, player, board, boardSize) || (row == col && checkDiagonal(player, board, boardSize)) || (row + col == boardSize - 1 && checkAntiDiagonal(player, board, boardSize)))
                {
                    return player == 1 ? "A" : "B";
                }

                player *= -1;

            }

            return moves.Count == boardSize * boardSize ? "Draw" : "Pending";
        }

        internal string FindTicTacToeGameWinnerwithJaggedArray(int[][] testMoves)
        {
            // create a board
            //Board size
            int boardSize = 3;
            int[,] board = new int[boardSize, boardSize];
            int player = 1; // Player 1

            foreach (var pair in testMoves)
            {
                int row = pair[0];
                int col = pair[1];

                // mark the current move and assign it to Players id (Starting is player 1)

                board[row, col] = player;

                //Check the winning condition with this move.

                if (checkRow(row, player, board, boardSize) || checkColumn(col, player, board, boardSize) || (row == col && checkDiagonal(player, board, boardSize)) || (row + col == boardSize - 1 && checkAntiDiagonal(player, board, boardSize)))
                {
                    return player == 1 ? "A" : "B";
                }

                player *= -1;

            }

            return testMoves.Length == boardSize * boardSize ? "Draw" : "Pending";
        }

        private bool checkAntiDiagonal(int player, int[,] board, int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                if (board[row, boardSize - 1 - row] != player) return false;
            }
            return true;
        }

        private bool checkDiagonal(int player, int[,] board, int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                if (board[row, row] != player) return false;
            }
            return true;
        }

        private bool checkColumn(int col, int player, int[,] board, int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                if (board[row, col] != player) return false;
            }
            return true;
        }

        private bool checkRow(int row, int player, int[,] board, int boardSize)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (board[row, col] != player) return false;
            }
            return true;
        }


        internal string FindTicTicGameWinnerRecordEachMove(int[][] testMoves)
        {
            int boardSize = 3;

            Dictionary<int, int> rows = new Dictionary<int, int>(boardSize);
            Dictionary<int, int> cols = new Dictionary<int, int>(boardSize);
            int diagonal = 0, antiDiagonal = 0;

            int player = 1;

            foreach (var pair in testMoves)
            {
                int row = Math.Abs(pair[0]);
                int col = Math.Abs(pair[1]);

                //Update the row value and column value              

                if (rows.ContainsKey(row))
                {
                    rows[row] += player;

                }
                else
                {
                    rows[row] = player;

                }

                if (cols.ContainsKey(col))
                {
                    cols[col] += player;

                }
                else
                {
                    cols[col] = player;

                }


                if (row == col)
                {
                    diagonal += player;
                }

                if (row + col == boardSize - 1)
                {
                    antiDiagonal += player;
                }

                if (Math.Abs((rows[row])) == boardSize || Math.Abs(cols[col]) == boardSize || Math.Abs(diagonal) == boardSize || Math.Abs(antiDiagonal) == boardSize)
                {
                    return player == 1 ? "A" : "B";
                }

                player = player * -1;
            }

            return testMoves.Length == boardSize * boardSize ? "Draw" : "Pending";
        }

        internal void LengthOfLongestSubString(string sText)
        {
            //char[] charText = sText.ToCharArray();
            //int res = 0;
            //int startCharIndex = 0, endCharIndex = 0;
            //for (int i = 0; i < charText.Length; i++)
            //{
            //    for (int j = i; j < charText.Length; j++)
            //    {
            //        if (checkRepeatOptions(sText, i, j))
            //        {
            //            if (res < j - i + 1)
            //            {
            //                startCharIndex = i;
            //                endCharIndex = j - i + 1;
            //            }
            //            res = Math.Max(res, j - i + 1);

            //        }
            //    }
            //}


            ////Print the characters from string. 
            //Console.WriteLine(sText.ToCharArray(startCharIndex, endCharIndex));

            //Logic using sliding window.
            //Two pointer logic.
            int a_pointer = 0;
            int b_pointer = 0;
            int max = 0;

            HashSet<char> charSet = new HashSet<char>();
            while (b_pointer < sText.Length)
            {
                if (!charSet.Contains(sText[b_pointer]))
                {
                    charSet.Add(sText[b_pointer]);
                    b_pointer++;
                    max = Math.Max(max, charSet.Count);
                }
                else
                {
                    charSet.Remove(sText[a_pointer]);
                    a_pointer++;
                }
            }
        }

        private bool checkRepeatOptions(string sText, int start, int end)
        {
            int[] chars = new int[128];

            for (int i = start; i <= end; i++)
            {
                char c = sText[i];
                chars[c]++;

                if (chars[c] > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

