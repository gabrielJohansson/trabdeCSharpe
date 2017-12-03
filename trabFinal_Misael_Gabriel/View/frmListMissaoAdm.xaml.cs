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
    /// Interaction logic for frmListMissaoAdm.xaml
    /// </summary>
    public partial class frmListMissaoAdm : Window
    {
        Usuario u = new Usuario();
        public frmListMissaoAdm(int id)
        {
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void btnAlt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Deseja Alterar Mesmo?", "Alterar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                frmAlterarMissao frm = new frmAlterarMissao(u.IDUsuario, m.IDMissao);
                frm.Show();
                Close();              
            }
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();
        }

        Missao m = new Missao();
        private void dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //pega o obj da row

            m = (Missao)dtg.SelectedItem;
            txtNome.Text = m.Name;            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dtg.ItemsSource = MissaoDAO.RetornarMissoes();

        }
    }
}
