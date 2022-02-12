using DSandPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SingleLinkedList list = new SingleLinkedList();

            //Create a list
            list.create(arr);

            // Print the list items, Iterative way.
            Console.WriteLine("Print all list elements");
            list.PrintListElements();

            //Print the list items using recursive way.
            //Console.WriteLine("Print all list element using recursive");
            //list.PrintListItemsRecursively();


            //Console.WriteLine("Reverse Linked list");
            //Reverse Linked list using recursion.
            //list.reverseLinkedListRecursively();

            // Reverse Linked list with out recursion.
            //list.ReverseLinkedListitterative();

            //Print the list items using recursive way.
            Console.WriteLine("Print all list element using recursive");
            list.PrintListItemsRecursively();

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
            list.SwapNodesPairwise();
            Console.WriteLine("Elements after swapping the elements pair wise");
            list.PrintListItemsRecursively();

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

            int[] calories = { 6,5,0,0 };
            int k = 2, lower = 3, upper = 5;
            int totalPoints = array.DietPlanPerformance(calories, k, lower, upper);

        }


    }
}
