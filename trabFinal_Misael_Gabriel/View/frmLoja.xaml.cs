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
            cboPersonagem.ItemsSource = PersogemDAO.returnFeridos(u.IDUsuario);
            cboPersonagem.DisplayMemberPath = "Nome";
            cboPersonagem.SelectedValuePath = "IDPesonagem";
            //carregar o cb box e o botao de cura
            if(cboPersonagem.Items.Count==0)
            {
                btnComprar.IsEnabled = false;
                btnHeal.IsEnabled = false;
                MessageBox.Show("Todos seus Personagens estão com Vida Cheia");
            }
            //cbo vai carregar so os que estao sem a vida máxima
            //btn vai estar disponivel se pelo menos um esta sem vida mxm
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            //cura tds os perssonagens do user
            if (u.Gold > u.Gold - (100 * cboPersonagem.Items.Count))
            {
                PersogemDAO.curarFeridos(u.IDUsuario);
                u.Gold = u.Gold - (100 * cboPersonagem.Items.Count);
                UsuarioDAO.AlterarUsuario(u);
                frmUsuario frm = new frmUsuario(u.IDUsuario);
                frm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Você Não Possui Gold para isso");
            }
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            int idP = (int)cboPersonagem.SelectedValue;
            Personagem p = new Personagem();
            p.IDPesonagem = idP;
            p = PersogemDAO.BuscarPersonagemPorId(p);
            txtPersonagem.Text = p.Nome;
            //escolhe o q ta no selecionado
            if (u.Gold > u.Gold - 100)
            {

                u.Gold = u.Gold - 100;
                UsuarioDAO.AlterarUsuario(u);
                p.VidaAtual = p.VidaTotal;
                PersogemDAO.AlterarPersonagem(p);
                frmUsuario frm = new frmUsuario(u.IDUsuario);
                frm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Você Não Possui Gold para isso");
            }

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
        }
    }
}
