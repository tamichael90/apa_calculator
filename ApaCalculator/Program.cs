using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playerCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] data = args.Select(int.Parse).ToArray();
            //{ 6, 6, 5, 5, 4, 3, 3 };
            int k = 5;
            List<string> combArray = new List<string>();
            foreach (string comb in CombinationsOfK(data, k).Select(c => string.Join(" ", c)))
            {

                var newString = comb.Split(' ').ToArray();
                int[] int_arr = Array.ConvertAll(newString, Int32.Parse);
                if (int_arr.Sum() <= 23 && !combArray.Contains(comb))
                {
                    combArray.Add(comb);
                    Console.WriteLine(comb);
                }
            }
        }
        public static IEnumerable<IEnumerable<T>> CombinationsOfK<T>(T[] data, int k)
        {
            int size = data.Length;
            int runningTotal = 0;
            IEnumerable<IEnumerable<T>> Runner(IEnumerable<T> list, int n)
            {
                int skip = 1;

                foreach (var headList in list.Take(size - k + 1).Select(h => new T[] { h }))
                {
                    var numString = Convert.ToInt32(headList[0]);
                    runningTotal += 23;
                    if (n == 1)
                    {
                        yield return headList;
                    }
                    else
                    {
                        foreach (var tailList in Runner(list.Skip(skip), n - 1))
                        {
                            yield return headList.Concat(tailList);
                        }
                        skip++;
                    }
                }
            }
            return Runner(data, k);
        }

    }
}