using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    public class Day1 : IDaySolution
    {
        public string Part1()
        {
            ReadNumbers(out List<int> Right, out List<int> Left);
            Right.Sort();
            Left.Sort();

            int TotalDistance = 0;

            for (int index = 0; index < Right.Count; index++)
            {
                TotalDistance += Right[index] <= Left[index] ? Left[index] - Right[index] : Right[index] - Left[index];
            }

            return TotalDistance.ToString();
        }

        public string Part2()
        {
            ReadNumbers(out List<int> Right, out List<int> Left);

            int SimilarityScore = 0;

            foreach(int left in Left)
            {
                int score = 0;
                foreach(int right in Right)
                {
                    if(left == right)
                    {
                        score++;
                    }
                }

                SimilarityScore += left * score;
            }

            return SimilarityScore.ToString();
        }

        private static void ReadNumbers(out List<int> Right, out List<int> Left)
        {
            Right = [];
            Left = [];
            foreach (var line in File.ReadLines(@".\2024\Input\Day1.txt"))
            {
                var Nums = line.Split("   ");

                Right.Add(int.Parse(Nums[0]));
                Left.Add(int.Parse(Nums[1]));
            }
        }
    }
}
