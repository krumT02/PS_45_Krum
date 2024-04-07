using DataLayers.DataBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayers.Model;

namespace UI.Componets
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();
            using (var context = new DatabaseContext())
            {
                var records = context.Logs.ToList();
                students.DataContext = records;
            }

        }
        private void LogsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedLog = students.SelectedItem as LogEntry;
            if (selectedLog != null)
            {
                MessageBox.Show($"Timestamp: {selectedLog.Timestamp}\nMessage: {selectedLog.Message}", "Log Details");
            }
        }

    }
}
