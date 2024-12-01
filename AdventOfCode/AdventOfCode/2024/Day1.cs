using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    public class Day1
    {
        public static string Solve()
        {
            int TotalDistance = 0;
            
            List<int> Right = new List<int>();
            List<int> Left = new List<int>();

            foreach (var line in File.ReadLines(@".\2024\Input\Day1.txt"))
            {
                var Nums = line.Split("   ");

                Right.Add(int.Parse(Nums[0]));
                Left.Add(int.Parse(Nums[1]));
            }

            Right.Sort();
            Left.Sort();

            for(int index = 0; index < Right.Count; index++)
            {
                TotalDistance += Right[index] <= Left[index] ? Left[index] - Right[index] : Right[index] - Left[index];
            }

            return TotalDistance.ToString();
        }
    }
}
