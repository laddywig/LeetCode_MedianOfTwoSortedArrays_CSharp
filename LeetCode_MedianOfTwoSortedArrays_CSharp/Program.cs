// See https://aka.ms/new-console-template for more information
using LeetCode_MedianOfTwoSortedArrays_CSharp;

Solution classObject = new();
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { }, new int[] { 1 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { }, new int[] { 2, 3 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { 2, 2, 4, 4 }, new int[] { 2, 2, 4, 4 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { 1 }, new int[] { 1 }).ToString("0.00000"));
Console.WriteLine(classObject.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 1, 2, 3 }).ToString("0.00000"));
