using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for frmCadastroMissao.xaml
    /// </summary>
    public partial class frmCadastroMissao : Window
    {
        Usuario u = new Usuario();

        public frmCadastroMissao(int id)
        {
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();
            
        }

        string nome="";
        string descricao="";
        double gold=0;
        double exp=0;
        private void btnVCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //cadastra a missao
            //verificar se tudo está preenchido
            //volta para adm
        }

        private void btnVCadastrarP_Click(object sender, RoutedEventArgs e)
        {
            //verifica se tudo está preenchido
            //se o char estiver nulo n cadastre
            //manda para o adm cadastro p 
            //manda a missão
            //ao cadastrar o personagem lá já vincula ele na missão
            /*
            int idP = (int)comboBox.SelectedValue;
            Personagem p =new Personagem();
            p.IDPersonagem=idP;
            p = PersogemDAO.BuscarPersonagemPorId(p);
            Missao m = new Missao { Nome = txtNome.Text, Preco = Convert.ToDouble(txtPreco.Text),personagem = p };
            */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //preenche o drop down com os personagens q tem o user com adm==true
            comboBox.ItemsSource = PersogemDAO.returnPAdm();
            comboBox.DisplayMemberPath = "Nome";
            comboBox.SelectedValuePath = "user.IDUsuario";
            
        }

        private void txtGold_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
