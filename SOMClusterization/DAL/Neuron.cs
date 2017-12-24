using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMClusterization.DAL
{
    public class Neuron
    {
        public static float SPEED_OF_LEARNING = 0.3f;

        public float[] Weigths { get; set; }
        public int Number { get; set; }

        #region Garbage fields

        public float Gender => Weigths[0];
        public float Credits => Weigths[1];

        public float AverageScore => (Weigths[2] + Weigths[3] + Weigths[4] + Weigths[5] + Weigths[6]) / 5;



        #endregion

        public List<int> ElementsInCluster { get; set; }
        
        public Neuron(float[] weights,int number)
        {
            Weigths = weights;
            Number = number;
            ElementsInCluster = new List<int>();
        }

        public float GetEuclideanDistance(float[] vector)
        {
            double result = 0;
            for (int i = 0; i < vector.Length; i++)
                result += Math.Pow(vector[i] - Weigths[i], 2);
            return (float)Math.Sqrt(result);
        }

        public void CorrectWeights(float[] vector)
        {
            for (int i = 0; i < Weigths.Length; i++)
            {
                Weigths[i] +=  SPEED_OF_LEARNING * (vector[i] - Weigths[i]);
            }
        }
    }
}
