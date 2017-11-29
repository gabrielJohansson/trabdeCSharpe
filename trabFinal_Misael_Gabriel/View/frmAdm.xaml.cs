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
    /// Interaction logic for frmAdm.xaml
    /// </summary>
    public partial class frmAdm : Window
    {
        public frmAdm()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            //voltar ao inicio
            frmPageInicial frm = new frmPageInicial();
            frm.Show();
            Close();
        }

        private void Carregar(object sender, RoutedEventArgs e)
        {
            dtg.ItemsSource = UsuarioDAO.RetornarUsuarios();

        }

        private void btnCriarMissao_Click(object sender, RoutedEventArgs e)
        {
            //vai para a page de criaçao
            //tem a opção de criar um char novo ou de usar um já cadastrado pelo adm
            //parecido com a criaçao de char,mas tem campos para xp gold ,nome e descr
        }

        private void btnAlterarMissao_Click(object sender, RoutedEventArgs e)
        {
            //lista as missoes e deixa alterar o nome,gold,exp e o char nela
            //nunca excluir
        }

        private void btnRegistros_Click(object sender, RoutedEventArgs e)
        {
            //abre a lista de missao
            //datagrid q n carrega td,carrega quando vc for escolhendo 
            //seleciona a missao e abre os logs com o dia e personagem
            //ao clickar abre os detalhes do combate!
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            //abre uma lista de personagens e sua ultima missao ao lado
            //select abre o log por data
            //select abre os detalhes do combate!
        }
    }
}
