using DSandPS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSandPS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = { 5, 4, 8, 7, 1, 2, 3, 4, 5, 6, };
            int[] arr = { 5, 4, 5, 8, 1, 7, 1, 2, 5 };

            //int[] arr = { 1,2,2,3,4,5,5,5,6,6,7,8,9,9 };

            //Single Linked List
            //SingleLinkedList list = new SingleLinkedList();

            ////Create a list
            //list.create(arr);

            // Print the list items, Iterative way.
            //Console.WriteLine("Print all list elements");
            //list.PrintListElements();

            //Print the list items using recursive way.
            //Console.WriteLine("Print all list element using recursive");
            //list.PrintListItemsRecursively();


            //Console.WriteLine("Reverse Linked list");
            //Reverse Linked list using recursion.
            //list.reverseLinkedListRecursively();

            // Reverse Linked list with out recursion.
            //list.ReverseLinkedListitterative();

            ////Print the list items using recursive way.
            //Console.WriteLine("Print all list element using recursive");
            //list.PrintListItemsRecursively();

            //// Insert element at the Begning.
            //list.InsertAtBegning();
            //Console.WriteLine("Elements after Insert a new element at Begning");
            //list.PrintListItemsRecursively();

            //// Insert element at the end.
            //list.InsertAtEnd();
            //Console.WriteLine("Elements after Insert a new element at the end");
            //list.PrintListItemsRecursively();

            //Insert element at middle.
            //list.InserElementAtMiddle();
            //Console.WriteLine("Elements after Insert a new element at the middle");
            //list.PrintListItemsRecursively();

            //Insert element at specific position
            //list.InsertElementAtSpecificPosition();
            //Console.WriteLine("Elements after Insert a new element at specific position");
            //list.PrintListItemsRecursively();

            //Delete an element at the Begning
            //list.DeleteElementAtBegning();
            //Console.WriteLine("Elements after Deleting the element at the begning");
            //list.PrintListItemsRecursively();

            ////Delete an element at the End
            //list.DeleteElementAtEnd();
            //Console.WriteLine("Elements after Deleting the element at the begning");
            //list.PrintListItemsRecursively();

            //Delete an element at the middle
            //list.DeleteElementAtMid();
            //Console.WriteLine("Elements after Deleting the element at middile");
            //list.PrintListItemsRecursively();

            //Delete the element at the speicfic position
            //list.DeleteElementAtSpecificPosition();
            //Console.WriteLine("Elements after Deleting the element at sppecfc position");
            //list.PrintListItemsRecursively();

            // Merge two sorted lists
            //list.MergeTwosortedLists();
            //Console.WriteLine("Elements after merging two lists");
            //list.PrintListItemsRecursively();

            // Check linked list is pallindrome
            //list.isListisPallindrome();

            // Remove duplicates from unsortedList
            //list.RemoveDuplicatesFromUnsortedList();
            //Console.WriteLine("Elements after remvoing duplicates from unsorted list");
            //list.PrintListItemsRecursively();

            // Remove duplicates from sortedList
            //list.RemoveDuplicatesFromSortedList();
            //Console.WriteLine("Elements after remvoing duplicates from sorted list");
            //list.PrintListItemsRecursively();

            // Swap nodes pairwise.
            //list.SwapNodesPairwise();
            //Console.WriteLine("Elements after swapping the elements pair wise");
            //list.PrintListItemsRecursively();

            // Add two linked lists.
            //list.AddTwoLinkedList();
            //Console.WriteLine("Elements after adding two linked lists");
            //list.PrintListItemsRecursively();



            // Array Related questions.

            ArrayCollection array = new ArrayCollection();

            // 1) Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

            //You may assume that each input would have exactly one solution, and you may not use the same element twice.

            //You can return the answer in any order.

            //int[] numnsarray = { -1, -2, -3, -4, -5 }; //{ 2, 7, 11, 15 };

            //array.Findtwosum(numnsarray, -8);


            // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
            // Notice that the solution set must not contain duplicate triplets.

            //int[] nums1 = { -2, 0, 0, 2, 2 }; // { -1, 0, 1, 2, -1, -4};
            //IList<IList<int>> result = array.FindAllUniqueTripletsWithZeroSum(nums1);


            //int[] nums = { -1, 2, 1, -4 };
            //int target = 1;

            //int sumofThreeIntegers = array.ThreeSumClosest(nums, target);


            //Given an array of n integers nums and an integer target, find the number of index triplets i, j, k with 0 <= i < j < k < n that satisfy the condition
            // nums[i] + nums[j] + nums[k] < target.

            //        Input: nums = [-2, 0, 1, 3], target = 2
            //Output: 2
            //Explanation: Because there are two triplets which sums are less than 2:
            //[-2,0,1]
            //[-2,0,3]

            //int[] nums = { -2, 0, 1, 3 }; int target = 2;

            //int threeSumSmaller = array.threeSumSmaller(nums, target);


            //Given an integer array nums, return the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.
            //Example 1:

            //Input: nums = [2, 2, 3, 4]
            //Output: 3

            //int[] nums = { 0, 1, 1, 1 };//{ 2, 2, 3, 4 };
            //array.findTrianglecombiatonTripplets(nums);

            // A dieter consumes calories[i] calories on the i-th day. 

            //            Given an integer k, for every consecutive sequence of k days(calories[i], calories[i + 1], ..., calories[i + k - 1] for all 0 <= i <= n - k), they look at T, the total calories consumed during that sequence of k days(calories[i] + calories[i + 1] + ... +calories[i + k - 1]):

            //If T<lower, they performed poorly on their diet and lose 1 point;
            //            If T > upper, they performed well on their diet and gain 1 point;
            //            Otherwise, they performed normally and there is no change in points.
            //            Initially, the dieter has zero points.Return the total number of points the dieter has after dieting for calories.length days.


            //           Note that the total points can be negative.

            //int[] calories = { 6,5,0,0 };
            //int k = 2, lower = 3, upper = 5;
            //int totalPoints = array.DietPlanPerformance(calories, k, lower, upper);


            #region largestUniqueNumber

            //            Given an integer array nums, return the largest integer that only occurs once. If no integer occurs once, return -1.



            //Example 1:

            //int[] nums = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            ////Output: 8
            ////Explanation: The maximum integer in the array is 9 but it is repeated.The number 8 occurs only once, so it is the answer.
            //int largestUniqueNumber = array.LargestUniqueNumber(nums);

            #endregion

            #region tic-toc-game-winner

            List<KeyValuePair<int, int>> moves = new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(0, 0), new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(0, 1), new KeyValuePair<int, int>(1, 0), new KeyValuePair<int, int>(0, 2), new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(2, 1), new KeyValuePair<int, int>(2, 2), new KeyValuePair<int, int>(2, 0) };

            int[][] testMoves = new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 0 } };

            //Brute force
            //array.FindTicTacToeGameWinner(test);
            // array.FindTicTacToeGameWinnerwithJaggedArray(testMoves);

            //Record each Move
            // array.FindTicTicGameWinnerRecordEachMove(testMoves);
            #endregion

            //Add two Linked Lists.

            //Create a Linked List
            //LinkedList list1 = new LinkedList();
            //list1.createLL(new int[] { 1, 2, 3, 4 });
            ////list1.print();
            //list1.PritnRecursivly();
            ////list1.reverseLL();
            //list1.reverseLLRecusiveLogic();
            //list1.PritnRecursivly();

            ////Add two numbers;
            //ListNode firstList = list1.createLL(new int[] { 9, 9, 9, 9, 9, 9, 9 });
            //ListNode secondList = list1.createLL(new int[] { 9, 9, 9, 9 });

            //ListNode SumList = list1.AddTWoNumbers(firstList, secondList);



            //Longest Substring without repeating characters.
            //string sText = "abcabcbb"; // "abcabcbb";
            //array.LengthOfLongestSubString(sText);

            // Failed scenarios (" "(1), "" (0), "c" (1)), "aab"(1, 2)(expected 2, output 1), "dvdf"(3, 2)

            //Longest Substring with At Most Two Distinct Characters
            //Given a string s, return the length of the longest substring that contains at most two distinct characters.

            //string sText = "eceba";
            //array.LengthOfLongestSubStringTwoDistinct(sText);

            // LongestPalindrome substring
            //string sText = "aaaaa"; //babad, aa, ccc, "aacabdkacaa", "abacab", "aaaabaaa", "aaaabaaa","aaaaa"
            //array.LongestPalindromeSubString(sText);

            // Zigzag Conversion
            //string sText = "PAYPALISHIRING";
            //array.ZigzagConvert(sText, 4);

            //// Reverse Integer
            //int number = 123;
            //array.Reverse(number);

            //Convert String to Integer (MyAtoi)
            //string sText = " -41-93";
            //array.ConvertStringToInteger(sText);

            //Convert int to Roman value.
            //int num = 320;
            //array.ConvertInttoRoman(num);

            //Conver Roman to Int.
            //string romanValue = "MCMXCIV"; //III
            //array.ConvertRomantoInt(romanValue);

            //Longest Common Prefix.
            //Write a function to find the longest common prefix string amongst an array of strings.
            //string[] strs = { "flower", "flow", "flight", "fight" };
            //array.LongestCommonPrefix(strs);

            // Container with Most Water.
            // You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
            //int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //array.containerWithMostWater(height);

            // Letter Combinations of a Phone Number
            // Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
            //string digits = "23";
            //array.LetterCombinations(digits);

            // Valid Parentheses
            //string symbol = "()[]{}";
            //array.ValidParantheses(symbol);

            // Generate Parentheses
            // Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
            //int number = 3;
            //array.GenerateParenthesis(number);

            // Remove Duplicates from Sorted Array
            //int[] arrayElements = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //array.removeDuplicateElements(arrayElements);

            // Remove Element

            //int[] arrayElements = { 0, 1, 2, 2, 3, 0, 4, 2 };
            //int val = 2; // Remove all 2 number elements.
            //array.removeElement(arrayElements, val);

            // Find the Index of the First Occurrence in a String
            //string haystack = "sadbutsad", needle = "sad";
            //array.findFirstOccurance(haystack, needle);

            // Divide Two Integers
            // Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
            // Need to handle overlfow exception too.

            //int dividend = -1, divisor = -1; //10/-3
            //array.DividetwoIntegers(dividend, divisor);

            // Substring with Concatenation of All Words
            // You are given a string s and an array of strings words. All the strings of words are of the same length.

            //string mainWord = "barfoothefoobarman";
            //string[] words = { "foo", "bar"};
            //array.FindSubstring(mainWord, words);

            //Longest Valid Parentheses
            //string symbol = ")()())";
            //array.LongestValidParentheses(symbol);

            // Search in Rotated Sorted Array
            //int[] arrayItems = { 4, 5, 6, 7, 8, 9, 0, 1, 2, 3 };
            //array.SearchinRotatedSortedArray(arrayItems, 2);

            // Find First and Last Position of Element in Sorted Array
            //int[] nums = { 5, 7, 7, 8, 8, 10 };
            //array.findFirstandLastOuccranceinArray(nums, 8);


            // Valid Sudoku
            //string[,] board = new string[9, 9] { { "5", "3", ".", "5", "7", ".", ".", ".", "." },{"6", ".", ".", "1", "9", "5", ".", ".", "." }
            //                                    ,{".", "9", "8", ".", ".", ".", ".", "6", "." } ,{"8", ".", ".", ".", "6", ".", ".", ".", "3" }
            //                                    ,{"4", ".", ".", "8", ".", "3", ".", ".", "1" } ,{"7", ".", ".", ".", "2", ".", ".", ".", "6" }
            //                                    ,{".", "6", ".", ".", ".", ".", "2", "8", "." } ,{".", ".", ".", "4", "1", "9", ".", ".", "5" }
            //                                    ,{".", ".", ".", ".", "8", ".", ".", "7", "9" } };

            //array.IsValidSudoku(board);

            // Combination Sum
            // Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

            // The same number may be chosen from candidates an unlimited number of times.Two combinations are unique if the frequency of at least one of the chosen numbers is different.
            //int[] candidates = { 2,3,5}; int target = 8; //2, 3, 6, 7  (7)
            //array.combinationSum(candidates, target);

            //Sort the people.
            // You are given an array of strings names, and an array heights that consists of distinct positive integers.Both arrays are of length n.
            //For each index i, names[i] and heights[i] denote the name and height of the ith person.
            //Return names sorted in descending order by the people's heights.

            //string[] names = { "Mary", "John", "Emma" }; int[] heights = { 180, 165, 170 };

            //string[] result = array.sortPeople(names, heights);

            // Given an unsorted integer array nums, return the smallest missing positive integer.
            // You must implement an algorithm that runs in O(n) time and uses constant extra space.

            //int[] numbers = { 3, 4, -1, 1 }; // { 1, 2, 0 }; //{ 3, 4, -1, -2, 1, 5, 16, 0, 2, 0 };
            //int missingNumber = array.FirstMissingPositiveInteger(numbers);
            //Console.WriteLine("Missing first postive number {0}", missingNumber);

            //Wildcard Matching
            //            Given an input string(s) and a pattern(p), implement wildcard pattern matching with support for '?' and '*' where:

            //'?' Matches any single character.
            //'*' Matches any sequence of characters(including the empty sequence).
            ////The matching should cover the entire input string (not partial).
            //string s = "adceb";//"abcabczzzde";//"aa"; //"adceb",
            //string p = "*a*b";//"*abc???de*";//  "a*"; //"*a*b";
            //bool isMatch = array.isMatch(s, p);

            // Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.
            //A subarray is a contiguous part of an array. (Kadanes alogoritham)
            //int[] nums = { 5, 4, -1, 7, 8 };//{ -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //int maxSubSum = array.MaxSubArray(nums);

            //Best Time to Buy and Sell Stock
            //You are given an array prices where prices[i] is the price of a given stock on the ith day.

            //You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

            //Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
            //int[] prices = { 7, 1, 5, 3, 6, 4 };
            //int maxProfit = array.MaxProfit(prices);

            //Single LL
            //SingleLL list = new SingleLL();

            //int[] arr1 = { 1, 2, 4 };
            //int[] arr2 = {1,3,4 };

            //int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            //SingleLLNode list1 = list.CreateList(arr1);

            //list.SwapNodeInPairs(list1);

            //list.ReverseNodesInKGroup(list1, 2);

            //SingleLLNode list1 = list.CreateList(arr1);
            //SingleLLNode list2 = list.CreateList(arr2);

            //SingleLLNode mergedList = list.Merge(list1, list2);

            //int[] listItems = { 3, 4, 5, 6, 7, 8, 5, 4, 9 };
            //list.CreateList(listItems);

            //list.TraverseAndPrintLL();
            //list.InserAtStart();
            //list.InsertAtEnd();

            //list.InsertAtSpecificPosition(10);
            //list.InsertAtMiddle();

            //list.ReverstLL();
            //Console.WriteLine("Reversed List");
            //list.TraverseAndPrintLL();

            //list.TraverseAndPrintLLInReverse();

            //Double LL
            //DoubleLL list = new DoubleLL();
            //list.Create(listItems);
            //list.traverseDoubleLLFromStart();
            ////list.InsertAtStart();
            ////list.InsertAtEnd();
            //list.reverseLL();
            //list.traverseDoubleLLFromStart();

            //BST
            //int[] listItems = { 6, 7, 5, 8, 9, 3, 4 };
            //int[] listItems1 = { 6, 5, 3, 4, 15, 14, 12, 13, 20, 18, 21, 17, 19, 22 };
            //BinarySearchTree bst = new BinarySearchTree();
            //DoubleLLNode root1 = bst.CreateBST(listItems);
            //DoubleLLNode root2 = bst.CreateBST(listItems1);

            //bst.BSTTraversal();

            //bst.FindInorderPredecessor(9);
            //bst.numberBSTTrees(5);

            //bst.DeleteNodeFromBST(20);

            //int bstHeight = bst.heightOfBST(root);
            //Console.WriteLine("BST height is : " + bstHeight); 

            //int bstDiameter = bst.DiameterofaBST(root);
            //Console.WriteLine("BST Diameter is : " + bstDiameter); 

            //bool isIsomarphic = bst.isIso(root1, root2);
            //Console.WriteLine("BST trees are : " + (isIsomarphic ? "IsomarPhic" :"NotIsomarphic"));

            //bst.printNodesHavingKNodes(root2, 2);


            // Matrix Collection.
            MatrixCollection matrix = new MatrixCollection();

            //int[,] matrixInput = new int[3, 4] {
            //    { 1, 2, 3, 4 }, { 5,6,7,8 }, { 9,10,11,12 }
            //};
            //matrix.printSpiralmatrix(matrixInput);

            int[,] intervals = new int[,] { { 1, 3 },{ 6, 9 }};
            int[] newInterval = { 2, 5 };
            //matrix.mergeIntervals(intervals);
            matrix.insertInterval(intervals, newInterval);
        }
    }
}

