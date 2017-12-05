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
    /// Interaction logic for frmSelLogADM.xaml
    /// </summary>
    public partial class frmSelLogADM : Window
    {
        Usuario u = new Usuario();
        public frmSelLogADM(int id)
        {
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.ItemsSource = MissaoDAO.RetornarMissoes();
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "IDMissao";
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {

            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnEscolher_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(lg.IDLogCombate.ToString());
            frmDetalheLog frm = new frmDetalheLog(lg.IDLogCombate);
            frm.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }


        Missao m = new Missao();
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idP = (int)comboBox.SelectedValue;
            Missao d = new Missao();
            d.IDMissao = idP;
            d = MissaoDAO.BuscarMissaoPorId(d);
            dtg.ItemsSource = LogCombateDAO.RetornarLogM(d.IDMissao);
            LogCombate lg = new LogCombate();
            m = d;
        }
        LogCombate lg = new LogCombate();


        private void dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //pega o obj da row

            lg = (LogCombate)dtg.SelectedItem;
            if (lg != null)
            {
                txtNome.Text = lg.missao.Name;
            }
        }
    }
}
