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
    /// Interaction logic for frmAlterarDadosU.xaml
    /// </summary>
    public partial class frmAlterarDadosU : Window
    {
        Usuario u = new Usuario();
        public frmAlterarDadosU(int id)
        {
            this.u.IDUsuario = id;
            //Metodo para linkar o id no obj da page
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            //att
            Usuario t = new Usuario();        

            if (txtUsuario.Text.Trim() != string.Empty && txtSenha.Text.Trim() != string.Empty && txtNome.Text.Trim() != string.Empty)
            {
                t = u;
                t.Login = txtUsuario.Text;
                t.Nome = txtNome.Text;

                    MessageBoxResult resultado = MessageBox.Show("Deseja Alterar seus Dados?", "Confirmação de Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.No)
                    {
                        //cancela a alteração !! e manda para a page do user
                        frmUsuario frm = new frmUsuario(u.IDUsuario);
                        frm.Show();
                        Close();
                    }
                    else
                    {
                        //mandando para o banco
                        if (UsuarioDAO.AlterarUsuario(t))
                        {
                            //altere e manda para usuario
                            t = UsuarioDAO.BuscarUsuarioPorLogin(t);
                            MessageBox.Show("Alteração Efetuada com Sucesso");
                            frmUsuario frm = new frmUsuario(t.IDUsuario);
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
            else
            {
                MessageBox.Show("Insira Valores em Todos os Campos");
            }
        }

        private void txtNome_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = u.Nome;
            txtSenha.Text = u.Senha;
            txtUsuario.Text = u.Login;
        }
    }
}
