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
    /// Interaction logic for frmLisPersonagemADM.xaml
    /// </summary>
    public partial class frmLisPersonagemADM : Window
    {
        Usuario u = new Usuario();
        public frmLisPersonagemADM(int id)
        {
            this.u.IDUsuario = id;
            //Metodo para linkar o id no obj da page
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtg.ItemsSource = PersogemDAO.RetornarPersonagensDeUsuarios();
            dtg2.ItemsSource = PersogemDAO.returnPAdm();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();
        }
    }
}
