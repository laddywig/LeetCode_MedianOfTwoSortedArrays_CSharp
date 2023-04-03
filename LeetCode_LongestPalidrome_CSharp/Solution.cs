using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_LongestPalidrome_CSharp
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            string longestPalindrome = $"{s[0]}";
            for(int i=0; i<s.Length; i++)
            {
                int nextIndex = i + 1;
                var matchingIndex = () => s.IndexOf(s[i], nextIndex);
                while (nextIndex < s.Length && s.IndexOf(s[i], nextIndex) > -1)                   
                {
                    if (IsPalidrome(s, i, (matchingIndex() + 1) - i))
                    {
                        string palindrome = s.Substring(i, (matchingIndex() + 1) - i);
                        if (palindrome.Length > longestPalindrome.Length)
                        {
                            longestPalindrome = palindrome;
                        }
                    }

                    nextIndex = matchingIndex() + 1;
                }
            }

            return longestPalindrome;
        }

        public bool IsPalidrome(string s, int startIndex, int endIndex)
        {
            string possibleAnswer = s.Substring(startIndex, endIndex);
            char[] array = possibleAnswer.ToCharArray();
            Array.Reverse(array);
            string reversedPossibleAnswer = new string(array);
            //Console.WriteLine(reversedPossibleAnswer);
            return possibleAnswer.Equals(reversedPossibleAnswer);
        }
    }
}
