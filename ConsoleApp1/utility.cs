using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Utility
    {
        public static bool Pelindrom(string str)
        {
            bool status = false;
            string temp_str = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                temp_str += str[i];
            }
            status = str == temp_str;
            return status;
        }
        public static string Replace(string str, char replaceChar, char replaceWith)
        {
            string temp_str = string.Empty;
            for (int index = 0; index < str.Length; index++)
            {
                if (replaceChar == str[index])
                {
                    temp_str += replaceWith;
                }
                else
                {
                    temp_str += str[index];
                }
            }
            return temp_str;
        }
        public static string LongestPelindrom(string str)
        {
            string temp_str = string.Empty;
            string result = string.Empty;
            for (int index = 0; index < str.Length; index++)
            {
                temp_str = string.Empty;
                for (int index_j = index; index_j < str.Length; index_j++)
                {
                    temp_str += str[index_j];
                    var pel = Pelindrom(temp_str);
                    if (pel)
                    {
                        result = temp_str.Length > result.Length ? temp_str : result;
                    }
                }
            }
            return result;
        }
        public static Dictionary<char, int> GetCharCount(string str)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int index = 0; index < str.Length; index++)
            {
                if (!charCount.ContainsKey(str[index]))
                {
                    charCount.Add(str[index], 0);
                }
                charCount[str[index]]++;
            }
            return charCount;
        }
        public static char[] UniqeChar(string str)
        {
            var charCount = GetCharCount(str);
            List<char> uniqeChar = new List<char>();
            foreach (var item in charCount)
            {
                if (item.Value == 1)
                {
                    uniqeChar.Add(item.Key);
                }
            }
            return uniqeChar.ToArray();
        }
        public static bool Anagram(string str1, string str2)
        {
            bool status = true;
            var getCharCount1 = GetCharCount(str1);
            var getCharCount2 = GetCharCount(str2);
            foreach (var item in getCharCount2)
            {
                if (!(getCharCount1.ContainsKey(item.Key) && getCharCount1[item.Key] >= getCharCount2[item.Key]))
                {
                    status = false;
                    break;
                }
            }
            return status;
        }
        public static int[] FindMissingNumberInRange(int start, int end, int[] arr)
        {
            List<int> missingNumber = new List<int>();
            for (int i = start; i < end; i++)
            {
                if (!arr.Contains(i))
                {
                    missingNumber.Add(i);
                }
            }
            return missingNumber.ToArray();
        }
        public static Dictionary<int, int> GetNumberCount(int[] arr)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();
            for (int index = 0; index < arr.Length; index++)
            {
                if (!numberCount.ContainsKey(arr[index]))
                {
                    numberCount.Add(arr[index], 0);
                }
                numberCount[arr[index]]++;
            }
            return numberCount;
        }
        public static int[] GetDuplicateNumber(int[] arr)
        {
            List<int> duplicateNumber = new List<int>();
            foreach (var item in GetNumberCount(arr))
            {
                if (item.Value > 1)
                {
                    duplicateNumber.Add(item.Key);
                }
            }
            return duplicateNumber.ToArray();
        }
        public static int[] GetMissingNumber(int[] arr1, int[] arr2)
        {
            List<int> duplicateNumber = new List<int>();
            for (int index = 0; index < arr2.Length; index++)
            {
                if (!arr1.Contains(arr2[index]))
                {
                    duplicateNumber.Add(arr2[index]);
                }
            }
            return duplicateNumber.ToArray();
        }
        public static int FindNthHigestNumber(int[] arr, int positionNuber)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int index_j = 0; index_j < arr.Length; index_j++)
                {
                    if (arr[index] > arr[index_j])
                    {
                        int swap = arr[index];
                        arr[index] = arr[index_j];
                        arr[index_j] = swap;
                    }
                }
            }
            return arr[positionNuber - 1];
        }
        public static int FindNthLowestNumber(int[] arr, int positionNuber)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int index_j = 0; index_j < arr.Length; index_j++)
                {
                    if (arr[index] < arr[index_j])
                    {
                        int swap = arr[index];
                        arr[index] = arr[index_j];
                        arr[index_j] = swap;
                    }
                }
            }
            return arr[positionNuber - 1];
        }
        public static string[] FindPairWhichMatchTheGivenNumberInArray(int[] arr, int number)
        {
            List<string> pair = new List<string>();
            for (int index = 0; index < arr.Length; index++)
            {
                for (int index_j = index + 1; index_j < arr.Length - 1; index_j++)
                {
                    if ((arr[index] + arr[index_j]) == number)
                    {
                        pair.Add("{" + arr[index] + "," + arr[index_j] + "}");
                    }
                }
            }
            return GetUniqueFromList(pair.ToArray()).ToArray();
        }
        public static List<T> GetUniqueFromList<T>(T[] arr)
        {
            List<T> uniqe = new List<T>();
            for (int index = 0; index < arr.Length; index++)
            {
                if (!uniqe.Contains(arr[index]))
                {
                    uniqe.Add(arr[index]);
                }
            }
            return uniqe;
        }
        public static string Fibonaci(int number)
        {
            int a = 0;
            int b = 1;
            string series = string.Empty;
            series = "0,1,";
            for (int index = 2; index < number; index++)
            {
                int sum = a + b;
                a = b;
                b = sum;
                series += sum + ",";
            }
            series = series.Trim(new char[] { ',' });
            return series;
        }
        
    }
}
