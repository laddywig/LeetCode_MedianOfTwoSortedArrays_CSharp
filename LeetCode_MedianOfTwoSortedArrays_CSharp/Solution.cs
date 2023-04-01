using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_MedianOfTwoSortedArrays_CSharp
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int sum = nums1.Length + nums2.Length;
            int num1tracker = 0;
            int num2tracker = 0;
            double lastNum = 0;
            bool isEven = sum % 2 == 0;
            bool willBreak = false;
            int count = GetCombinedSizeHalf(sum);
            int lastNumTracker = isEven ? count - 2 : count - 1;
            for (int i = 0; i < count; i++)
            {
                if(nums1.Length <= num1tracker)
                {
                    if (i >= lastNumTracker)
                    {
                        lastNum += nums2[num2tracker];
                    }
                    num2tracker++;
                }
                else if (nums2.Length <= num2tracker)
                {
                    if (i >= lastNumTracker)
                    {
                        lastNum += nums1[num1tracker];
                    }
                    num1tracker++;
                }
                else if (nums1[num1tracker] < nums2[num2tracker])
                {
                    if (i >= lastNumTracker)
                    {
                        lastNum += nums1[num1tracker];
                    }
                    num1tracker++;
                }
                else if (nums2[num2tracker] < nums1[num1tracker])
                {
                    if (i >= lastNumTracker)
                    {
                        lastNum += nums2[num2tracker];
                    }
                    num2tracker++;
                }
                else if (nums2[num2tracker] == nums1[num1tracker])
                {
                    if (i >= lastNumTracker)
                    {
                        if (!isEven || lastNum != 0)
                        {
                            willBreak = true;
                        }
                        lastNum += nums2[num2tracker];

                        if (willBreak)
                        {
                            break;
                        }
                    }
                    i++;
                    if (i >= lastNumTracker)
                    {
                        lastNum += nums2[num2tracker];
                    }
                    num1tracker++;
                    num2tracker++;
                }
                else
                {
                    throw new ApplicationException("Logic should never execute this line of code");
                }
            }

            if (isEven)
            {
                return (lastNum) / 2.0;
            }
            else
            {
                return Convert.ToDouble(lastNum);
            }
        }

        public int GetCombinedSizeHalf(int sum) 
        {
            if (sum % 2 == 0)
            {
                return (sum / 2)+1;
            }
            else
            {
                return (sum + 1) / 2;
            }
        }
    }
}
