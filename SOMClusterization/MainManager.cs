using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SOMClusterization.DAL;
using SOMClusterization.Dialogs;
using SOMClusterization.Dilogs;

namespace SOMClusterization
{
    class MainManager : ViewModelBase
    {
        private Neuronet _net;
        private List<float[]> _input;
        public List<float[]> DataGridInfo { get; set; }
        public RelayCommand ButtonCommand { get; set; }
        public int SelectedIndex { get; set; }

        private RelayCommand _normalizeCommand;
        private RelayCommand _startLearningCommand;

        public MainManager()
        {
            _normalizeCommand = new RelayCommand(Normalize);
            _startLearningCommand = new RelayCommand(StartLearning);
            ButtonCommand = _normalizeCommand;
            var input = ParseInput("input.txt");
            _input = input.ToArray().ToList();
            DataGridInfo = input;
            RaisePropertyChanged("DataGridInfo");
        }
        private void Normalize()
        {
            _net = new Neuronet(_input);
            DataGridInfo = _input;
            ButtonCommand = _startLearningCommand;
            RaisePropertyChanged("DataGridInfo");
            RaisePropertyChanged("ButtonCommand");
        }
        private void StartLearning()
        {
            _net.StartLearning();
            var clusters = _net.GetClusters();
            var manager = new ClustersDataGridManager(clusters);
            var dialog = new ClustersDataGrid(manager);
            dialog.Show();
        }

        private List<float[]> ParseInput(string path)
        {
            List<float[]> result = new List<float[]>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                float[] parameters = new float[7];
                string[] row = sr.ReadLine().Split();
                parameters[0] = (row[2] == "М" ? 1 : 0);
                parameters[1] = (row[3] == "Да" ? 1 : 0);
                for (int i = 4; i < 9; i++)
                {
                    parameters[i-2] = float.Parse(row[i]);
                }
                result.Add(parameters.ToArray());
            }
            return result;
        }

        public void MouseDoubleClick()
        {

        }
    }
}
