using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SOMClusterization.DAL;

namespace SOMClusterization.Dilogs
{
    public class ClustersDataGridManager:ViewModelBase
    {
        public List<Neuron> DataGridInfo { get; set; }
        public Action Exit { get; set; }

        public ClustersDataGridManager(List<Neuron> data)
        {
            DataGridInfo = data;
            RaisePropertyChanged("DataGridInfo");
        }
    }
}
