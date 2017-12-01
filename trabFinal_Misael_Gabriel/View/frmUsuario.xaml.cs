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
    /// Interaction logic for frmUsuario.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        Usuario u = new Usuario();

        public frmUsuario(int id)
        {
            this.u.IDUsuario = id;
            //Metodo para linkar o id no obj da page
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();

        }

        private void btnCriar_Click(object sender, RoutedEventArgs e)
        {
            //vai para a tela de criação
            //se tiver menos de 3 chars nessa conta
            List<Personagem> p = PersogemDAO.RetornarPersonagensUsuario(u);
            if (p.Count < 3)
            {
                frmCadastroPersonagem frm = new frmCadastroPersonagem(u.IDUsuario);
                frm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Máximo de Personagens Alcançado");
            }

        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            //vai para uma tela que lista os personagens coms suas informações
            //mostra o lvl e q missao ele parou
            frmListPersonagemU frm = new frmListPersonagemU(u.IDUsuario);
            frm.Show();
            Close();
            //tem o botao de deletar!
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            //vai estar separado por char
            //clickou no char vai abrir uma barra de data
            //clickou na data abre a missao
            //clickou na missao abre o log de battle dessa missao deste dia/hora
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //abre os dados da conta e deixa a alteraçao da senha e nome,LOGIN NAÃO
            frmAlterarDadosU frm = new frmAlterarDadosU(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            //Retorna para a tela de logon           
            frmPageInicial frm = new frmPageInicial();
            frm.Show();
            Close();
            //a ultima con do personagem é baseada na ultima missao feita!!
        }

        private void btnMissao_Click(object sender, RoutedEventArgs e)
        {
            //manda para a tela de escolha de char
            //na tela de char clicka no char
            //aparece as quest disponivel
            //fazer dropdow dos chars
            //escolheu abre um grid
            //faz igual a  amostra dos pers
        }

        private void btnLoja_Click(object sender, RoutedEventArgs e)
        {
            frmLoja frm = new frmLoja(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //USAR ISSO EM MUITAS TELAS!!!!!!!!!!!!!!!!!
            //atualizar a data
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bem-Vindo " + u.Nome, "Boas-Vindas");
        }

    }
}
