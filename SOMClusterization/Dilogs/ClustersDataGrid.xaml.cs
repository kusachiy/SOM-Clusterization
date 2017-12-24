using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SOMClusterization.Dilogs;

namespace SOMClusterization.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class ClustersDataGrid
    {
        public ClustersDataGrid(ClustersDataGridManager dataGridManager)
        {
            InitializeComponent();
            DataContext = dataGridManager;
            dataGridManager.Exit = Close;
        }
    }
}
