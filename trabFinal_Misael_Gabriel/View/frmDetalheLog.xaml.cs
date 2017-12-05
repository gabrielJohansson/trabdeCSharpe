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
using trabFinal_Misael_Gabriel.DAO;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.View
{
    /// <summary>
    /// Interaction logic for frmDetalheLog.xaml
    /// </summary>
    public partial class frmDetalheLog : Window
    {
        LogCombate lg = new LogCombate();
        public frmDetalheLog(int id)
        {
            this.lg.IDLogCombate = id;
            lg = LogCombateDAO.BuscarLogsDosCombatesPorId(lg);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtg.ItemsSource = DetalheLogDAO.RetornarLog(lg.IDLogCombate);
        }
    }
}
