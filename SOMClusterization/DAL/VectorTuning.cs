using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMClusterization.DAL
{
    static class VectorTuning
    {
        public static int Length { get; set; } = 7;
        public static float[] MaximalValues { get; set; }
        public static float[] MinimalValues { get; set; }

        static VectorTuning()
        {
            MaximalValues = new float[Length];
            MinimalValues = new float[Length];
        }

        public static void AnalyzeAndNormalizeInput(List<float[]> input)
        {
            //Tuning
            Length = input.First().Length;
            for (int i = 0; i < Length; i++)
            {
                var cortege = input.Select(r => r.ElementAt(i)).ToArray();
                MaximalValues[i] = cortege.Max();
                MinimalValues[i] = cortege.Min();
            }
            ////______________

            /// Normalizaton
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = Normalize(input[i]);
            }
        }
        public static float[] Normalize(float[] input)
        {
            var data = new float[Length];
            for (int i = 0; i < Length; i++)
            {
                var min = MinimalValues[i];
                var max = MaximalValues[i];
                data[i] = (input[i] - min) / (max - min);
            }
            return data;
        }
        public static void Denormalize()
        {
            //тут что-то будет
        }
    }
}
