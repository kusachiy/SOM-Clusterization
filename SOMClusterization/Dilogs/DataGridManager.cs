using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace SOMClusterization.Dilogs
{
    public class DataGridManager:ViewModelBase
    {
        public List<float[]> DataGridInfo { get; set; }
        public Action Exit { get; set; }

        public DataGridManager(List<float[]> data)
        {
            DataGridInfo = data;
            RaisePropertyChanged("DataGridInfo");
        }
    }
}
