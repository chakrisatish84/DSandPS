using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class ArrayCollection
    {
        public int[] findTwoSum(int[] numbers, int target)
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
    }
}
