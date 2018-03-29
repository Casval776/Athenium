using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenium.Percentile
{
    public static class PercentileHelper
    {
        /// <summary>
        /// Calculates grades into a numerical ranking system where
        /// A: 80-100th Percentile
        /// B: 60-80th Percentile
        /// C: 40-60th Percentile
        /// D: 20-40th Percentile
        /// F: 0-20th Percentile
        /// </summary>
        /// <param name="sequence">List of grades</param>
        /// <returns>Dictionary of grades and their associated scores</returns>
        public static Dictionary<char, IEnumerable<int>> Percentile(List<int> sequence)
        {
            //Declare variables
            var grades = new Dictionary<char, IEnumerable<int>>();
            var isMultiple = sequence.Count % 5 == 0;

            //Sort sequence
            sequence.Sort();

            //Calculate A rank grades
            var aIndex = (int)Math.Ceiling((0.8 * sequence.Count)) - 1;
            var aAvg = isMultiple
                ? MathHelper.Average(sequence[aIndex], sequence[aIndex+ 1])
                : sequence[aIndex];
            grades.Add('A', 
                sequence.Where(x => x >= aAvg));

            //Calculate B rank grades
            var bIndex = (int)Math.Ceiling((0.6 * sequence.Count)) - 1;
            var bAvg = isMultiple
                ? MathHelper.Average(sequence[bIndex], sequence[bIndex + 1])
                : sequence[bIndex];
            grades.Add('B', 
                sequence.Where(x => x >= bAvg && x < grades['A'].Min())
                );

            //Calculate C rank grades
            var cIndex = (int)Math.Ceiling((0.4 * sequence.Count)) - 1;
            var cAvg = isMultiple
                ? MathHelper.Average(sequence[cIndex], sequence[cIndex + 1])
                : sequence[cIndex];
            grades.Add('C',
                sequence.Where(x => x >= cAvg && x < grades['B'].Min())
                );

            //Calculate D rank grades
            var dIndex = (int)Math.Ceiling((0.2 * sequence.Count)) - 1;
            var dAvg = isMultiple
                ? MathHelper.Average(sequence[dIndex], sequence[dIndex + 1])
                : sequence[dIndex];
            grades.Add('D',
                sequence.Where(x => x >= dAvg && x < grades['C'].Min())
                );

            //Calculate F rank grades
            grades.Add('F',
                sequence.Where(x => x < grades['D'].Min()));

            return grades;
        }
    }
}
