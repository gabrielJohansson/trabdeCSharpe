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
    /// Interaction logic for SelLogU.xaml
    /// </summary>
    public partial class SelLogU : Window
    {
        Usuario u = new Usuario();
        public SelLogU(int id)
        {
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
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
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        comboBox.ItemsSource = PersogemDAO.RetornarPersonagensUser(u.IDUsuario);
        comboBox.DisplayMemberPath = "Nome";
        comboBox.SelectedValuePath = "IDPesonagem";
      }

        Personagem p = new Personagem();
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idP = (int)comboBox.SelectedValue;
            Personagem d = new Personagem();
            d.IDPesonagem = idP;
            d = PersogemDAO.BuscarPersonagemPorId(d);
            dtg.ItemsSource = LogCombateDAO.RetornarLogP(d.IDPesonagem);
            LogCombate lg = new LogCombate();
            p = d;
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