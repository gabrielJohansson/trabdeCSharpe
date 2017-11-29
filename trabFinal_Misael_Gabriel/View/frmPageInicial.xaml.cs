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
    /// Interaction logic for frmPageInicial.xaml
    /// </summary>
    public partial class frmPageInicial : Window
    {
        public frmPageInicial()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //verificar o login
            Usuario u = new Usuario();
            u.Login = txtUsuario.Text;
            u.Senha = txtSenha.Text;
            Usuario c = UsuarioDAO.BuscarUsuarioPorLogin(u);
            if(c==null)
            {
                //caso o login n exista dar uma mensagem
                MessageBox.Show("Esse Login não Existe","Erro ao Logar");               
            }
            else
            {
                c = UsuarioDAO.Logar(u);
                if (c==null)
                {
                    MessageBox.Show("A senha está Incorreta","Erro ao Logar");
                }
                else
                {
                    //verificar se for adm ou n

                    if(c.Adm==true)
                    {
                        //ir para adm
                        frmAdm frm = new frmAdm();
                        frm.Show();
                        Close();
                    }
                    else
                    {
                        frmUsuario frm = new frmUsuario(c.IDUsuario);
                        frm.Show();
                        Close();
                    }
                    
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //mandar para a pagina de cadastro
           // Usuario u = new Usuario();
           // u.Adm = true;
           // u.Login = "ADM";
           // u.Senha = "123";
          //  UsuarioDAO.CadastrarUsuario(u);
            //xxxxxxxx
            frmCadastroUsuario frm = new frmCadastroUsuario();
            frm.Show();
            Close();
        }
    }
}
