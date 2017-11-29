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
    /// Interaction logic for frmLoja.xaml
    /// </summary>
    public partial class frmLoja : Window
    {
        Usuario u = new Usuario();
        public frmLoja(int id)
        {
            this.u.IDUsuario = id;
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
            txtGold.Text = "Gold :" + u.Gold;
            //carregar o cb box e o botao de cura
            //cbo vai carregar so os que estao sem a vida máxima
            //btn vai estar disponivel se pelo menos um esta sem vida mxm
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            //cura tds os perssonagens do user
            //preço vai ser por pers curado
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            //escolhe o q ta no selecionado
            //vai ficar num text block?
            //vai
            //fazer os binds
            //!!
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
        }
    }
}
