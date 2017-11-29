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
    /// Interaction logic for frmCadastroUsuario.xaml
    /// </summary>
    public partial class frmCadastroUsuario : Window
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            //cadastro
            Usuario u = new Usuario();
            //nao se pode repetir o login!!!!!          

            if (txtUsuario.Text.Trim()!=string.Empty && txtSenha.Text.Trim()!= string.Empty && txtNome.Text.Trim()!= string.Empty)
            {
                u.Login = txtUsuario.Text;
                u.Nome = txtNome.Text;
                u.Senha = txtSenha.Text;
                Usuario f = UsuarioDAO.BuscarUsuarioPorLogin(u);
                //verifica se ja existe o login

                if (f != null)
                {
                    MessageBox.Show("Esse Login já está em uso,Tente outro", "Falha ao Cadastrar");
                }
                else
                {
                    MessageBoxResult resultado = MessageBox.Show("Deseja Cadastrar?", "Confirmação de Cadastro", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.No)
                    {
                        //cancela o cadastro !! e manda para a page inicial
                        frmPageInicial frm = new frmPageInicial();
                        frm.Show();
                        Close();
                    }
                    else
                    {
                        //mandando para o banco
                        if (UsuarioDAO.CadastrarUsuario(u))
                        {
                            //cadastre e envie para a pagina de usuario ja logado
                            Usuario a = UsuarioDAO.BuscarUsuarioPorLogin(u);
                            MessageBox.Show("Cadastro Efetuado com Sucesso " + a.Nome);
                            frmUsuario frm = new frmUsuario(a.IDUsuario);
                            frm.Show();
                            Close();
                        }
                        else
                        {
                            //tirar isso dps
                            MessageBox.Show("Erro no Banco");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Valores em Todos os Campos");
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmPageInicial frm = new frmPageInicial();
            frm.Show();
            Close();
        }
  
    }
}
