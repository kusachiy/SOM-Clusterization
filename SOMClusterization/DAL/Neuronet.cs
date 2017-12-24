using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMClusterization.DAL
{
    class Neuronet
    {
        public const float CRITICAL_DISTANCE = 0.95f;
        public const float VALUELESS_DISTANCE = 0.05f;
        public const int NUMBER_OF_LEARNING_EPOCHS= 6;

        public List<Neuron> _neurons { get; set; }
        public List<float[]> NormalizeInput { get; set; }

        private int _countOfRows;
        public Neuronet(List<float[]> input)
        {
            VectorTuning.AnalyzeAndNormalizeInput(input);
            NormalizeInput = input;
            _countOfRows = NormalizeInput.Count;
            _neurons = new List<Neuron>();
        }

        public void StartLearning()
        {
            //Enter First Neuron
            _neurons = new List<Neuron>();
            CreateNewCluster(0);
            int epoch = 0;
            do
            {
                _neurons.ForEach(n=>n.ElementsInCluster=new List<int>());
                MixInput();
                for (int i = 0; i < 20; i++)
                {
                    #region Определение нейрона победителя
                    float minDistance = float.MaxValue;
                    Neuron neuronWinner = null;
                    for (int j = 0; j < _neurons.Count; j++)
                    {
                        var d = _neurons[j].GetEuclideanDistance(NormalizeInput[i]);
                        if (d < minDistance)
                        {
                            minDistance = d;
                            neuronWinner = _neurons[j];
                        }
                    }
                    #endregion
                    if (minDistance < CRITICAL_DISTANCE)
                    {
                        neuronWinner.CorrectWeights(NormalizeInput[i]);
                        neuronWinner.ElementsInCluster.Add(i);
                    }
                    else
                        CreateNewCluster(i);
                }
                _neurons.RemoveAll(n => n.ElementsInCluster.Count == 0);
                Neuron.SPEED_OF_LEARNING -= 0.05f;
                epoch++;
            } while (epoch<NUMBER_OF_LEARNING_EPOCHS);
        }

        public List<Neuron> GetClusters()
        {
            return _neurons;
        }

        private void CreateNewCluster(int indexOfParent)
        {
            var neuron = new Neuron(NormalizeInput[indexOfParent],_neurons.Count+1);
            neuron.ElementsInCluster.Add(indexOfParent);
            _neurons.Add(neuron);
        }
        private void MixInput()
        {
            Random rnd = new Random();
            NormalizeInput = NormalizeInput.OrderBy(v => rnd.Next()).ToList();
        }
    }
}
