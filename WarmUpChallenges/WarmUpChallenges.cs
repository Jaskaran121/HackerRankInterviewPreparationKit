using System;
using System.Collections.Generic;
namespace WarmUpChallenges
{
    class SockMerchant
    {
        static int sockMerchant(int n, int[] ar)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            foreach (var c in ar)
            {
                int count = 0;
                if (hashMap.ContainsKey(c))
                {
                    count = hashMap[c];
                }
                hashMap[c] = count + 1;
            }

            int returnCount = 0;
            foreach (var item in hashMap)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
                if (item.Value % 2 == 0)
                    returnCount++;
            }
            return returnCount;
        }

        static int jumpingOnClouds(int[] c)
        {
            int index = 0;
            int jumps = 0;
            while (index < c.Length - 1)
            {
                Console.WriteLine(index);
                if (index + 1 < c.Length && c[index + 1] == 1)
                {
                    jumps = jumps + 1;
                    index = index + 2;
                }
                if (index + 1 < c.Length && c[index + 1] == 0)
                {
                    if (index + 2 < c.Length && c[index + 2] == 0)
                    {
                        jumps = jumps + 1;
                        index = index + 2;
                    }
                    else
                    {
                        jumps = jumps + 1;
                        index = index + 1;
                    }
                }
            }
            return jumps;
        }

        static int anagram(string s)
        {
            if (s.Length % 2 == 1)
                return -1;
            List<char> list1 = new List<char>();
            List<char> list2 = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length / 2)
                    list1.Add(s[i]);
                else
                    list2.Add(s[i]);
            }
            int count = list1.Count;
            List<char> list3 = new List<char>();
            for (int i = 0; i < count; i++)
            {
                char value = list1[i];
                //Console.WriteLine(value);
                // Remove if value is 20.
                if (!list2.Contains(value))
                {
                    list3.Add(value);
                }
                else
                {
                    list2.Remove(value);
                }
            }
            return list3.Count;
        }

        static int countingValleys(int n, string s)
        {
            int valleys = 0;
            int currentLevel = 0;
            char initialStep = ' ';
            for (var i = 0; i < s.Length; i++)
            {
                if (currentLevel == 0)
                {

                    if (i != 0 && initialStep == 'D')
                    {
                        Console.WriteLine(i);
                        valleys++;
                    }
                    initialStep = s[i];
                    //Console.WriteLine(i);
                    Console.WriteLine(initialStep);
                }
                if (s[i] == 'D')
                    currentLevel++;
                else
                    currentLevel--;
            }
            return (currentLevel == 0 && s[s.Length - 1] == 'U') ? valleys + 1 : valleys;
        }

        static long repeatedString(string s, long n)
        {
            long occurences = 0;
            List<int> indexesOfOccurence = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    occurences++;
                    indexesOfOccurence.Add(i);
                }
            }
            if (occurences == 0)
                return 0;
            occurences = occurences * (n / s.Length);
            long left = n % s.Length;
            foreach (var index in indexesOfOccurence)
            {
                if (index < left)
                {
                    Console.WriteLine(index);
                    occurences++;
                }

            }
            return occurences;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(sockMerchant(9,new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 }));
            Console.WriteLine(countingValleys(8, "UDDDUDUU"));
            Console.WriteLine(jumpingOnClouds(new int[] { 0 ,0 ,1 ,0 ,0, 1 , 0 }));
            Console.WriteLine(repeatedString("aba",10));
            Console.WriteLine(anagram("aaabbb"));
        }
    }
}
