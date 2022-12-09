using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

            //    //If current value is greater than break from the loop. (Since this is sorted i is greater than o remaining all are greater than 0.
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

        internal int LengthOfLongestSubString(string sText)
        {
            if (string.IsNullOrEmpty(sText.Trim()))
            {
                if (sText == "")
                {
                    Console.WriteLine("Count: 0");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Count: 1");
                    return 1;
                }
            }
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
            ////Two pointer logic. (It will work if we want to know only the count, if we want to see the result then it might not work)
            //int a_pointer = 0;
            //int b_pointer = 0;
            //int max = 0;
            //int maxSoFar = 0;

            ////Place unique items in Hash table
            //HashSet<string> resultSet = new HashSet<string>();

            //HashSet<char> charSet = new HashSet<char>();
            //while (b_pointer < sText.Length)
            //{
            //    if (!charSet.Contains(sText[b_pointer]))
            //    {
            //        charSet.Add(sText[b_pointer]);
            //        b_pointer++;
            //        max = Math.Max(max, charSet.Count);
            //    }
            //    else
            //    {
            //        if (max > maxSoFar)
            //        {
            //            resultSet.Clear();
            //        }
            //        if (max <= charSet.Count)
            //        {
            //            maxSoFar = max;
            //            if (!resultSet.Contains(sText.Substring(a_pointer, b_pointer - a_pointer)))
            //            {
            //                resultSet.Add(sText.Substring(a_pointer, b_pointer - a_pointer));
            //            }

            //        }
            //        charSet.Remove(sText[a_pointer]);
            //        a_pointer++;
            //    }
            //}

            //if (max > maxSoFar)
            //{
            //    resultSet.Clear();
            //}
            //if (max >= maxSoFar && max <= charSet.Count)
            //{
            //    if (!resultSet.Contains(sText.Substring(a_pointer, b_pointer - a_pointer)))
            //    {
            //        resultSet.Add(sText.Substring(a_pointer, b_pointer - a_pointer));
            //    }
            //}
            //Console.WriteLine(String.Join(", ", resultSet) + " Count is " + max);

            ///Logic to get Count and  substring. (This is having so many issues with different strings)
            // 1) If string is empty (or) emptry space (return 0 (or) 1)
            // 1) Create  hashset, result string, result Lengh variables
            // 2) Loop through and add characters in Hashset (if we don't have already, if you find move to step 3)
            // 3) If we find any element in store hash set result and empty the hashset resuult (Note: before stroing check the lenth is smaller than new hashset values else just empty the hashset and proceed).
            // 4) If there are no duplicates retrun the final string.

            //HashSet<char> charSet = new HashSet<char>();
            //string result = "";
            //int resultCount = 0;

            //char[] chars = sText.ToCharArray();

            //for (int i = 0; i < chars.Length; i++)
            //{
            //    if (!charSet.Contains(chars[i]))
            //    {
            //        charSet.Add(chars[i]);
            //    }
            //    else
            //    {
            //        if(charSet.Count > resultCount)
            //        {
            //            resultCount = charSet.Count;
            //            result = new string(charSet.ToArray());
            //            charSet.Clear();
            //            charSet.Add(chars[i]);
            //        }
            //    }
            //}
            //if (charSet.Count > resultCount) //That means no duplicates
            //{
            //    resultCount = charSet.Count;
            //    result = new string(charSet.ToArray());
            //}
            //Console.WriteLine(result + " and the count is " + resultCount);          


            int result = 0;
            int strLength = sText.Length;
            int maxSofar = 0;
            StringBuilder sb = new StringBuilder();

            //if (strLength == 0)
            //{
            //    return result;
            //}

            //if (strLength == 1)
            //{
            //    return 1;
            //}

            Queue<string> queue = new Queue<string>();

            queue.Enqueue(sText[0].ToString());

            for (int i = 1; i < strLength; i++)
            {
                if (queue.Contains(sText[i].ToString()))
                {
                    if (queue.Count > maxSofar)
                    {
                        sb.Clear();
                        for (int k = 0; k < queue.Count; k++)
                        {
                            sb.Append(queue.Peek());
                        }
                        maxSofar = queue.Count;
                    }
                    while (sText[i].ToString() != queue.Peek())
                    {
                        queue.Dequeue();
                    }
                    queue.Dequeue();
                    queue.Enqueue(sText[i].ToString());
                }
                else
                {
                    queue.Enqueue(sText[i].ToString());
                }
            }

            if (queue.Count > maxSofar)
            {
                sb.Clear();
                for (int k = 0; k < queue.Count; k++)
                {
                    sb.Append(queue.Peek());
                }
                maxSofar = queue.Count;
            }

            result = sb.Length;

            return result;


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

        internal int LengthOfLongestSubStringTwoDistinct(string sText)
        {
            char[] charText = sText.ToCharArray();

            int stringLength = charText.Length;

            if (stringLength < 1)
            {
                Console.WriteLine("Invalid Input");
            }

            int LeftIndex = 0, rightIndex = 0, MaxLengthSofar = 0;

            Dictionary<char, int> dicResult = new Dictionary<char, int>();

            while (rightIndex < stringLength)
            {
                if (!dicResult.ContainsKey(sText[rightIndex]))
                {
                    dicResult.Add(sText[rightIndex], rightIndex);
                }
                else
                {
                    dicResult[sText[rightIndex]] = rightIndex;
                }
                int minValue = int.MaxValue;
                int smallestIndex = 0;
                if (dicResult.Count() == 3)
                {
                    foreach (KeyValuePair<char, int> kvp in dicResult)
                    {
                        if (kvp.Value < minValue)
                        {
                            smallestIndex = kvp.Value;
                            minValue = kvp.Value;
                        }
                    }

                    dicResult.Remove(sText[smallestIndex]);
                    LeftIndex = smallestIndex + 1;
                }
                MaxLengthSofar = Math.Max(MaxLengthSofar, rightIndex - LeftIndex + 1);
                rightIndex++;
            }

            return MaxLengthSofar;
        }

        public string LongestPalindromeSubString(string sText)
        {
            string result = "";
            if (sText.Length <= 1)
            {
                return sText;
            }

            #region kind of brute force using two pointers 
            //// This logic is giving Time Limit Exceeded error.
            ////Taking two pointers (first point is i and second pointer is i+1)
            //// loop through second pointer reached end of the array and find the current palindromic sub string.
            //// Increase the first Potiner and reeat the step2 and Step3.

            ////This solution is working but it take lot of time.

            //HashSet<string> resultSet = new HashSet<string>();

            //int aPointer = 0, bPointer = 1;
            //string currentPalindromeSubString = "";
            //string previousPalindromeSubString = "";
            //for (; aPointer < sText.Length - 1; aPointer++)
            //{
            //    bPointer = aPointer + 1;
            //    while (bPointer < sText.Length)
            //    {
            //        string subString = sText.Substring(aPointer, bPointer - aPointer + 1);
            //        if (checkSubstringisPallindrome(subString))
            //        {
            //            currentPalindromeSubString = subString;
            //            bPointer++;
            //        }
            //        else
            //        {
            //            if (!string.IsNullOrEmpty(currentPalindromeSubString) && currentPalindromeSubString.Length >= previousPalindromeSubString.Length && currentPalindromeSubString != previousPalindromeSubString)
            //            {
            //                if(currentPalindromeSubString.Length > previousPalindromeSubString.Length && resultSet.Any() && currentPalindromeSubString.Length > resultSet.FirstOrDefault().Length)
            //                {
            //                    resultSet.Clear();
            //                }
            //                previousPalindromeSubString = currentPalindromeSubString;
            //                resultSet.Add(currentPalindromeSubString);
            //                bPointer++;

            //            }
            //            else
            //            {
            //                bPointer++;
            //            }
            //        };
            //    }

            //    if (!string.IsNullOrEmpty(currentPalindromeSubString) && currentPalindromeSubString.Length >= previousPalindromeSubString.Length && !resultSet.Contains(currentPalindromeSubString)){
            //        if (currentPalindromeSubString.Length > previousPalindromeSubString.Length && resultSet.Any() && currentPalindromeSubString.Length > resultSet.FirstOrDefault().Length)
            //        {
            //            resultSet.Clear();
            //        }
            //        resultSet.Add(currentPalindromeSubString);
            //    }
            //}

            //if (resultSet.Count > 0 || !string.IsNullOrEmpty(currentPalindromeSubString))
            //{
            //    if (resultSet.Count == 0 && !string.IsNullOrEmpty(currentPalindromeSubString))
            //    {
            //        result = currentPalindromeSubString;
            //    }
            //    else
            //    {
            //        Console.WriteLine(string.Join(", ", resultSet));
            //        result = resultSet.First();
            //    }
            //}
            //else
            //{
            //    result = sText.First().ToString();
            //}
            #endregion

            #region expandMiddle Logic
            //int start = 0, end = 0;
            //for (int i = 0; i < sText.Length; i++)
            //{
            //    int len1 = expandFromMiddle(sText, i, i);
            //    int len2 = expandFromMiddle(sText, i, i + 1);
            //    int len = Math.Max(len1, len2);

            //    if (len > end - start)
            //    {
            //        start = i - ((len - 1) / 2);
            //        end = i + (len / 2);
            //    }
            //}

            //result = sText.Substring(start, end + 1);

            #endregion

            #region Dynamic Progrmaing
            // Created 2 dimensional array
            // if text lenth is lest than 1 return the input string.
            // Loop through all the elements from len >= 3  (if it is two the logic might not work
            // If we update table with 1 and 2 elements then we can run the DP.

            int[,] resultTable = new int[sText.Length, sText.Length];
            string palindromSubStringSoFar = "";

            for (int i = 0; i < sText.Length; i++)
            {
                resultTable[i, i] = 1;
                if (i + 1 < sText.Length)
                {
                    if (sText[i] == sText[i + 1] && palindromSubStringSoFar == "")
                    {
                        palindromSubStringSoFar = sText.Substring(i, 2);
                    }
                    resultTable[i, i + 1] = sText[i] == sText[i + 1] ? 1 : 0;
                }

            }

            for (int i = 0; i < sText.Length; i++)
            {
                int k = 0;
                for (int j = i + 2; j < sText.Length; j++)
                {
                    if (sText[k] == sText[j] && resultTable[k + 1, j - 1] == 1)
                    {
                        string currentPalindromicSubstring = sText.Substring(k, j - k + 1);
                        if (palindromSubStringSoFar.Length < currentPalindromicSubstring.Length)
                        {
                            palindromSubStringSoFar = currentPalindromicSubstring;
                        }
                        resultTable[k, j] = 1;
                    }
                    k++;
                }

            }
            if (string.IsNullOrEmpty(palindromSubStringSoFar))
            {
                palindromSubStringSoFar = sText[0].ToString();
            }

            result = palindromSubStringSoFar;
            #endregion Dynamic 

            return result;
        }

        private int expandFromMiddle(string sText, int left, int right)
        {
            if (string.IsNullOrEmpty(sText) || left > right) return 0;

            while (left >= 0 && right < sText.Length && sText[left] == sText[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        private bool checkSubstringisPallindrome(string subString)
        {
            int i = 0, j = subString.Length - 1;

            for (; i < j; i++, j--)
            {
                if (subString[i] != subString[j])
                {
                    return false;
                }
            }

            return true;
        }

        //if we place the input string in zig Zag order as the numberof rows specified, we need to pring out in row wise.

        internal string ZigzagConvert(string sText, int numberOfRows)
        {
            string result = "";
            if (numberOfRows <= 1)
            {
                result = sText;
            }
            else
            {
                StringBuilder sbResult = new StringBuilder();

                int cycleLength = 2 * numberOfRows - 2;

                for (int i = 0; i < numberOfRows; i++)
                {
                    for (int j = 0; j + i < sText.Length; j += cycleLength)
                    {
                        sbResult.Append(sText[j + i]);
                        if (i != 0 && i != numberOfRows - 1 && j + cycleLength - i < sText.Length)
                        {
                            sbResult.Append(sText[j + cycleLength - i]);
                        }
                    }
                }

                result = sbResult.ToString();
            }

            return result;
        }

        public int Reverse(int x)
        {
            int result = 0;
            return ReverseInteger(x, result);
        }

        internal int ReverseInteger(int num, int result)
        {
            int rem = 0;

            if (num == 0)
            {
                return result;
            }

            rem = num % 10;
            num = num / 10;

            if ((result > int.MaxValue / 10 || (result == int.MaxValue / 10 && rem > 7)) || (result < int.MinValue / 10 || (result == int.MinValue / 10 && rem < -8)))
            {
                num = 0;
                result = 0;

            }
            else
            {
                result = result * 10 + rem;
            }

            int finalResult = ReverseInteger(num, result);

            return finalResult;
            //    int pop = 0, rev = 0;

            //    if (num == 0 && num.ToString().Length == 1)
            //    {
            //        return num;
            //    }

            //    while (num != 0)
            //    {

            //        pop = num % 10;
            //        num = num / 10;

            //        // Make sure it is not overflow the number
            //        //Check that before adding multiplication

            //        Console.WriteLine(string.Format("Divide {0}, Module {1}", int.MaxValue / 10, int.MaxValue % 10));

            //        if (rev > int.MaxValue / 10 || rev == int.MaxValue / 10 && pop > 7) return 0;
            //        if (rev < int.MinValue / 10 || rev == int.MaxValue / 10 && pop < -8) return 0;

            //        rev = rev * 10 + pop;
            //    }
            //    return rev;
        }


        internal int ConvertStringToInteger(string sText)
        {
            // Text is not empty
            // Text is having any empty spaces at the begning (if there are any trim that) and if number starts with 0 trim that too
            // Text is having any Symbol at the begning (+ (or) -) , If we are having more than one symbol at the begning return and say it is invalid.
            // loop through the digits. if you find any not digit charater stop return the current value

            //To get current value use this logic (0 * 10 + digit).

            int result = 0;
            int currIndex = 0;
            int textLength = sText.Length;
            int sign = 1;

            if (string.IsNullOrEmpty(sText)) return result;

            while (currIndex < textLength && (sText[currIndex].ToString() == " " || sText[currIndex].ToString() == "0"))
            {
                currIndex++;
            }

            if (currIndex < textLength && sText[currIndex].ToString() == "+")
            {
                sign = 1;
                currIndex++;
            }
            else if (currIndex < textLength && sText[currIndex].ToString() == "-")
            {
                sign = -1;
                currIndex++;
            }

            while (currIndex < textLength && char.IsDigit(sText[currIndex]))
            {
                int digit = sText[currIndex] - '0';

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > int.MaxValue % 10))
                {
                    //over flow reutr 2^31-1, underflowed return -2^31
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                result = result * 10 + digit; // There might be a chance of overflow exception, So the conditions before calculating this one

                currIndex++;
            }

            Console.WriteLine(sign * result);
            return sign * result;


        }

        internal string ConvertInttoRoman(int num)
        {
            string result = "";
            if (num <= 0)
            {
                return result;
            }
            // Max roman Value is 1000 (M).
            // So First create possible values and corresponding roman symbols. (note 4 is not IIII and it shoud be IV and same to other).

            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (values[i] <= num)
                {
                    num = num - values[i];

                    //When value is less than the num, add corresponding numner and subract number from that value and continue the loop.
                    sbResult.Append(symbols[i]);

                }

            }

            result = sbResult.ToString();

            return result;
        }

        internal int ConvertRomantoInt(string romanValue)
        {
            int result = 0;
            //if roman value is empty return
            if (string.IsNullOrEmpty(romanValue)) return result;

            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            //// Loop through all the characters 

            //for (int i = 0; i < romanValue.Length; i++)
            //{
            //    string subString = "";
            //    bool subStringFoundInSymbols = false;
            //    //take two letters and check if that sumbol is present in Symbols list.
            //    if (i + 1 < romanValue.Length)
            //    {
            //        subString = romanValue.Substring(i, 2);
            //        if (symbols.Contains(subString))
            //        {
            //            subStringFoundInSymbols = true;
            //            i++;
            //        }
            //    }
            //    if (!subStringFoundInSymbols)
            //    {
            //        subString = romanValue[i].ToString();
            //        subStringFoundInSymbols = false;
            //    }

            //    int j = 0;
            //    while (j < symbols.Length)
            //    {
            //        if (symbols[j] == subString)
            //        {
            //            result += values[j];
            //            break;
            //        }
            //        j++;
            //    }
            //}

            //Using dictionary.
            Dictionary<string, int> dicSymbolsandValues = new Dictionary<string, int>();

            for (int i = 0; i < values.Length; i++)
            {
                dicSymbolsandValues.Add(symbols[i], values[i]);
            }

            for (int i = 0; i < romanValue.Length; i++)
            {
                string subString = "";
                bool subStringFoundInSymbols = false;
                if (i + 1 < romanValue.Length)
                {
                    subString = romanValue.Substring(i, 2);
                    if (dicSymbolsandValues.ContainsKey(subString))
                    {
                        i++;
                        subStringFoundInSymbols = true;
                    }
                }
                if (!subStringFoundInSymbols)
                {
                    subString = romanValue.Substring(i, 1);
                    subStringFoundInSymbols = false;
                }

                result += dicSymbolsandValues[subString];
            }
            return result;

        }

        internal string LongestCommonPrefix(string[] strs)
        {
            string result = "";

            // 1) if strs length is 0 , return emtpty string
            // 2) Take default LCP as first string.
            // 3) Lopp through all other string and check for prefix and generate a new prefix by triming the last character
            if (strs.Length <= 0) return result;

            //string lcp = strs[0];

            //for (int i = 1; i < strs.Length; i++)
            //{
            //    while (strs[i].IndexOf(lcp) != 0)
            //    {                    
            //        lcp = lcp.Substring(0, lcp.Length - 1);

            //        if (lcp.Length == 0)
            //        {

            //            return result;
            //        }
            //    }
            //}
            //result = lcp;

            //return result;

            //Divide and Conquer Logic.

            result = longetsCommonPrefix(strs, 0, strs.Length - 1);

            return result;
        }

        private string longetsCommonPrefix(string[] strs, int left, int right)
        {
            if (left == right)
            {
                return strs[left];
            }

            else
            {
                int mid = (left + right) / 2;
                string sLeft = longetsCommonPrefix(strs, left, mid);
                string sRight = longetsCommonPrefix(strs, mid + 1, right);
                return commonprefix(sLeft, sRight);
            }
        }

        private string commonprefix(string sLeft, string sRight)
        {
            int min = Math.Min(sLeft.Length, sRight.Length);

            for (int i = 0; i < min; i++)
            {
                if (sLeft[i].ToString() != sRight[i].ToString())
                {
                    return sLeft.Substring(0, i);
                }
            }
            return sLeft.Substring(0, min);
        }

        internal int containerWithMostWater(int[] height)
        {
            int result = 0;
            if (height.Length <= 1)
            {
                return result;
            }

            int heightLength = height.Length;
            int first = 0, last = heightLength - 1;
            while (first < last)
            {
                int width = last - first;
                result = Math.Max(result, Math.Min(height[first], height[last]) * width);

                if (height[first] < height[last])
                {
                    first++;
                }
                else
                {
                    last--;
                }
            }

            return result;
        }

        internal IList<string> LetterCombinations(string digits)
        {
            //create string array of Symbols.
            // create a dictionray with numnber and corresponding symbols.
            // Loop thorugh all the characters in the input (Assumption of max two characters) 
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            //dictionary of numbers and corresponding symboxl
            Dictionary<int, string> dicValueSymbpols = new Dictionary<int, string>();

            string[] symbols = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            string phoneDigits = digits;


            for (int i = 0; i <= 7; i++)
            {
                dicValueSymbpols.Add(i + 2, symbols[i]);
            }

            backtrack(0, new StringBuilder(), phoneDigits, result, dicValueSymbpols);

            return result;

        }

        private void backtrack(int index, StringBuilder path, string phoneDigits, List<string> result, Dictionary<int, string> dicValueSymbpols)
        {
            //Get symbols for current index
            if (phoneDigits.Length == path.Length)
            {
                result.Add(path.ToString());
                return;
            }


            //Get symbols for current index digit that maps to and loop through them.
            string possibleLetters = dicValueSymbpols[phoneDigits[index] - '0'];

            for (int i = 0; i < possibleLetters.Length; i++)
            {
                path.Append(possibleLetters[i].ToString());

                backtrack(index + 1, path, phoneDigits, result, dicValueSymbpols);

                path.Remove(path.Length - 1, 1);
            }
        }

        internal bool ValidParantheses(string symbol)
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(symbol) || symbol.Length == 1) return isValid;

            // First generate the mappings.
            Dictionary<string, string> dicMatchingSymbols = new Dictionary<string, string>();
            dicMatchingSymbols.Add(")", "(");
            dicMatchingSymbols.Add("}", "{");
            dicMatchingSymbols.Add("]", "[");

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < symbol.Length; i++)
            {
                if (symbol[i].ToString() == "(" || symbol[i].ToString() == "{" || symbol[i].ToString() == "[")
                {
                    stack.Push(symbol[i].ToString());
                }
                else
                {
                    if (stack.Count == 0) { return isValid; }
                    string popSymbol = stack.Pop();

                    // Check that is valid close symbol by comapring with popped element
                    if (dicMatchingSymbols[symbol[i].ToString()] != popSymbol)
                    {
                        return isValid;
                    }
                }
            }

            if (stack.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        internal IList<string> GenerateParenthesis(int number)
        {

            List<string> lstResult = new List<string>();

            if (number < 1) return lstResult;

            generateAll(new char[2 * number], 0, lstResult);

            return lstResult;
        }

        private void generateAll(char[] current, int pos, List<string> lstResult)
        {
            if (pos == current.Length)
            {
                if (valid(current))
                    lstResult.Add(new String(current));
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, lstResult);
                current[pos] = ')';
                generateAll(current, pos + 1, lstResult);
            }
        }

        public bool valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }

        internal int removeDuplicateElements(int[] arrayElements)
        {
            int result = 0;

            if (arrayElements.Length < 1) return result;


            int k = 0;

            for (int i = 0; i < arrayElements.Length; i++)
            {
                while (i + 1 < arrayElements.Length && arrayElements[i] == arrayElements[i + 1])
                {
                    i++;
                }

                arrayElements[k] = arrayElements[i];
                k++;
            }

            // Logic to remove elements from arry 
            arrayElements = arrayElements.Where((source, index) => index <= k - 1).ToArray();

            result = k;


            return result;
        }

        internal int removeElement(int[] arrayElements, int val)
        {
            int result = 0, k = 0;

            if (arrayElements.Length < 1) return result;

            for (int i = 0; i < arrayElements.Length; i++)
            {
                if (arrayElements[i] != val)
                {
                    arrayElements[k] = arrayElements[i];
                    k++;
                }
            }

            result = k;
            return result;
        }

        internal int findFirstOccurance(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle)) return -1;

            if (!haystack.Contains(needle)) return -1;

            Console.WriteLine(haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase));

            return haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
        }

        internal int DividetwoIntegers(int dividend, int divisor)
        {

            int result = 0;
            if (dividend == 0 || divisor == 0) return result;

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            //Count number of - sings 
            // If it is 1 then we need append - to the result.
            int negatvieSigns = 0;

            if (dividend < 0)
            {
                negatvieSigns++;
                dividend = -dividend;
            }
            if (divisor < 0)
            {
                negatvieSigns++;
                divisor = -divisor;
            }

            int quotient = 0;

            while (dividend - divisor >= 0)
            {
                quotient++;
                dividend -= divisor;
            }

            if (negatvieSigns == 1)
            {
                quotient = -quotient;
            }

            return quotient;

        }

        internal IList<int> FindSubstring(string mainWord, string[] words)
        {

            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(mainWord) || words.Length <= 0) return result;

            //Create a dictionary and add all the words and their repated times (int)
            Dictionary<string, int> dicWords = new Dictionary<string, int>();

            // Find length of main word (n)
            int n = mainWord.Length;
            // Find length of words.(k)
            int k = words.Length;
            //Fign length of word (all words are same length) (wordLength)
            int wordLength = words[0].Length;
            // k * wordLength is the final sub string.
            int subStringSize = wordLength * k;


            foreach (string word in words)
            {
                if (!dicWords.ContainsKey(word))
                {
                    dicWords.Add(word, 1);
                }
                else
                {
                    dicWords[word] += 1;
                }
            }


            for (int i = 0; i < n - subStringSize + 1; i++)
            {
                if (check(i, mainWord, dicWords, k, wordLength, subStringSize))
                {
                    result.Add(i);
                }
            }



            return result;

        }

        private bool check(int index, string s, Dictionary<string, int> dicWords, int k, int wordLength, int subStringSize)
        {
            // copy the original dictionary
            Dictionary<string, int> dicRemaining = new Dictionary<string, int>(dicWords);
            int wordsUsed = 0;
            for (int j = index; j < index + subStringSize; j += wordLength)
            {
                string sub = s.Substring(j, wordLength);

                if (dicRemaining.ContainsKey(sub) && dicRemaining[sub] > 0)
                {
                    dicRemaining[sub] -= 1;
                    wordsUsed++;
                }
                else
                {
                    break;
                }
            }

            return wordsUsed == k;
        }

        internal int LongestValidParentheses(string symbol)
        {
            int result = 0;
            Stack<int> stack = new Stack<int>();

            stack.Push(-1);

            for (int i = 0; i < symbol.Length; i++)
            {
                if (symbol[i].ToString() == "(")
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    result = Math.Max(result, i - stack.Peek());
                }

            }

            return result;
        }

        internal int SearchinRotatedSortedArray(int[] arrayItems, int target)
        {
            int result = -1;

            if (arrayItems.Length == 0 || (arrayItems.Length == 1 && arrayItems[0] != target)) return result;

            int start = 0, end = arrayItems.Length - 1, mid = 0;

            while (start <= end)
            {
                mid = (start + (end - start) / 2);

                if (arrayItems[mid] == target) return mid;

                if (arrayItems[mid] >= arrayItems[start])
                {
                    if (target >= arrayItems[start] && target < arrayItems[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target <= arrayItems[end] && target > arrayItems[mid])
                    {
                        start = mid + 1;
                    }
                    else end = mid - 1;
                }
            }

            return result;
        }

        internal int[] findFirstandLastOuccranceinArray(int[] nums, int target)
        {
            int[] result = { -1, -1 };

            int firstOccurance = findOccurance(nums, target, true);

            if (firstOccurance == -1) return result;

            int secondOcurance = findOccurance(nums, target, false);

            result = new int[] { firstOccurance, secondOcurance };

            return result;

        }

        private int findOccurance(int[] nums, int target, bool isFirstOccurance)
        {
            int start = 0, end = nums.Length - 1, mid = 0;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] == target)
                {
                    if (isFirstOccurance)
                    {
                        if (mid == start || nums[mid - 1] != target)
                        {
                            return mid;
                        }

                        else
                        {
                            end = mid - 1;
                        }
                    }
                    else
                    {
                        if (mid == end || nums[mid + 1] != target)
                        {
                            return mid;
                        }

                        else
                        {
                            start = mid + 1;
                        }

                    }
                }
                else if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        internal bool IsValidSudoku(string[,] board)
        {
            int boardSize = board.GetUpperBound(1) + 1; // Marix is zero indexed.

            //use Hashset to recrod the status.

            HashSet<string>[] rows = new HashSet<string>[boardSize];
            HashSet<string>[] cols = new HashSet<string>[boardSize];
            HashSet<string>[] boxes = new HashSet<string>[boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                rows[i] = new HashSet<string>();
                cols[i] = new HashSet<string>();
                boxes[i] = new HashSet<string>();
            }

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    string value = board[row, col];

                    if (value == ".")
                    {
                        continue;
                    }

                    if (rows[row].Contains(value))
                    {
                        return false;
                    }
                    rows[row].Add(value);

                    if (cols[col].Contains(value))
                    {
                        return false;
                    }
                    cols[col].Add(value);

                    //Check the box.
                    int idx = (row / 3) * 3 + col / 3;

                    if (boxes[idx].Contains(value))
                    {
                        return false;
                    }
                    boxes[idx].Add(value);
                }
            }

            return true;

        }

        internal IList<IList<int>> combinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (candidates.Length == 0) return result;

            int[] copyArr = candidates;

            for (int i = 0; i < candidates.Length; i++)
            {
                List<int> list = new List<int>();

                if (candidates[i] > target)
                    continue;

                if (candidates[i] == target)
                {
                    result.Add(new List<int> { candidates[i] });
                    continue;
                }

                int numRepeat = target / candidates[i];

                for (int j = numRepeat; j > 0; j--)
                {
                    int currentNum = candidates[i] * j;
                    int balence = target - currentNum;

                    if (balence == 0 || candidates.Contains(balence))
                    {

                        for (int k = j; k > 0; k--)
                        {
                            list.Add(candidates[i]);
                        }
                        if (balence == 0)
                        {
                            j--;
                        }
                        if (balence != 0)
                        {
                            list.Add(balence);
                        }

                        result.Add(list);
                    }

                    list = new List<int>();
                }
                copyArr = copyArr.Skip(1).ToArray();
            }

            return result;
        }

        internal string[] sortPeople(string[] names, int[] heights)
        {
            string[] result = new string[names.Length];
            if (names.Length == 0 || heights.Length == 0 || names.Length != heights.Length)
            {
                return result;
            }
            int itemsLength = names.Length;

            Dictionary<int, string> dicItems = new Dictionary<int, string>();

            int i = 0;
            while (i < itemsLength)
            {
                dicItems.Add(heights[i], names[i]);
                i++;
            }

            //sort the heights;
            Array.Sort(heights, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

            for (int j = 0; j < heights.Length; j++)
            {
                result[j] = dicItems[heights[j]];
            }


            return result;
        }

        internal int FirstMissingPositiveInteger(int[] numbers)
        {
            int missingNumber = 1;
            int totalNumbers = numbers.Length;
            if (totalNumbers == 0)
            {
                return missingNumber;
            }

            int contains = 0;

            //Check the array in haivng the element 1.
            for (int i = 0; i < totalNumbers; i++)
            {
                if (numbers[i] == 1)
                {
                    contains++;
                    break;
                }
            }

            if (contains == 0) // 1 is not found, so that is the first missing positive and return that number
            {
                return missingNumber;
            }

            // Replace all negative numbers and numbers which are greater than the totalNumbers with 1

            for (int i = 0; i < totalNumbers; i++)
            {
                if (numbers[i] > totalNumbers || numbers[i] <= 0)
                {
                    numbers[i] = 1;
                }
            }

            // Take the i value and updated the corresponding array index value as -ve number
            // That way we can loop through and return the first not negative number Index as missing first positive number

            for (int i = 0; i < totalNumbers; i++)
            {
                int a = Math.Abs(numbers[i]);

                if (a == totalNumbers) // If the values is max array lenth, we need to update the 0 index value, as it is zero based
                    numbers[0] = -Math.Abs(numbers[0]);
                else
                    numbers[a] = -Math.Abs(numbers[a]);
            }

            //Now find the index of not negative number and that is the first missing positive number
            for (int i = 1; i < totalNumbers; i++)
            {
                if (numbers[i] > 0)
                {
                    return i;
                }
            }

            if (numbers[0] > 0)
            {
                return totalNumbers;
            }

            return totalNumbers + 1;
        }

        internal bool isMatch(string s, string p)
        {
            bool isMatching = false;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
            {
                return isMatching;
            }

            if (p == "*")
            {
                isMatching = true;
                return isMatching;
            }

            //if (s.Length != p.Length)
            //{
            //    return isMatching;
            //}

            int j = 0;

            for (int i = 0; i < s.Length; i++, j++)
            {
                if (p[j].ToString() == "*")
                {
                    if (p.Length - 1 == j)
                    {
                        return true;
                    }
                    i++; j++;
                    if (s[i] == p[j])
                    {
                        continue;
                    }
                    while (s.Length > i && s[i] != p[j])
                    {
                        i++;
                    }
                }
                if (p[j].ToString() == "?")
                {
                    continue;
                }

                if (s[i] != p[j])
                {
                    return false;
                }
            }

            if (j != p.Length - 1)
            {
                return false;
            }

            isMatching = true;

            return isMatching;
        }

        internal int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int maxSoFar = 0;
            int currentSum = 0;
            int arrLength = nums.Length;
            int i = 0;

            while (i < arrLength)
            {
                currentSum = currentSum + nums[i];
                if (maxSoFar < currentSum)
                {
                    maxSoFar = currentSum;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                }
                i++;
            }

            // If array contains only negative numbers return the last element.
            if (maxSoFar == 0)
            {
                maxSoFar = nums[arrLength];
            }

            return maxSoFar;
        }

        internal int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            //This is giving time out error
            //
            //int currentProfit = 0;

            //for (int i = 0; i < prices.Length - 1; i++)
            //{
            //    int j = i + 1;
            //    while (j < prices.Length)
            //    {
            //        if (prices[i] > prices[j])
            //        {
            //            j++;
            //        }
            //        else if (j < prices.Length)
            //        {
            //            currentProfit = prices[j] - prices[i];

            //            if (maxProfit < currentProfit)
            //            {
            //                maxProfit = currentProfit;
            //            }
            //            j++;
            //        }
            //    }

            //}
            int minPrice = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }

                else
                {
                    if (prices[i] - minPrice > maxProfit)
                    {
                        maxProfit = prices[i] - minPrice;
                    }
                }
            }

            return maxProfit;
        }
    }
}

