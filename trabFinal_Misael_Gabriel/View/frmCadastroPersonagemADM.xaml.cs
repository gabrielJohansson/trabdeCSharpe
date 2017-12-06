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
    /// Interaction logic for frmCadastroPersonagemADM.xaml
    /// </summary>
    public partial class frmCadastroPersonagemADM : Window
    {
        Usuario u = new Usuario();
        Missao m = new Missao();
        public frmCadastroPersonagemADM(int id,string nome,string descr,double exp,double gold)
        {
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            this.m.Name = nome;
            this.m.Descricao = descr;
            this.m.ExperienciaConcedida = exp;
            this.m.GoldConcedido = gold;
            InitializeComponent();
        }














        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();

        }

        private void btnVCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Personagem p = new Personagem { user = u };
            p.Modelo = 0;
            p.Elemento = "";
            //cadastra o personagem com o id do user
            //faz os if para linkar o elemento com atk,iniciativa e vida total
            //linka o radio btn com o type 
            if (rbtn1.IsChecked == true)
            {
                p.Modelo = 1;
            }
            if (rbtn2.IsChecked == true)
            {
                p.Modelo = 2;
            }
            if (rbtn3.IsChecked == true)
            {
                p.Modelo = 3;
            }
            if (rbtn4.IsChecked == true)
            {
                p.Modelo = 4;
            }




            if (rbtnAgua.IsChecked == true)
            {
                p.Elemento = "Agua";
            }
            if (rbtnAr.IsChecked == true)
            {
                p.Elemento = "Ar";
            }
            if (rbtnTera.IsChecked == true)
            {
                p.Elemento = "Terra";
            }
            if (rbtnFogo.IsChecked == true)
            {
                p.Elemento = "Fogo";
            }


            if (txtNome.Text.Trim() == string.Empty || p.Elemento.Equals("") || p.Modelo == 0 || txtLVL.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha os campos");

            }
            else
            {
                p.Nome = txtNome.Text;
                p.Experiencia = 0;
                p.Level = Convert.ToInt32(txtLVL.Text);
                p.Missao = 0;
                p.UltimaConexao = DateTime.Now;
                switch (p.Elemento)
                {
                    case "Agua":
                        p.VidaTotal = 900+(p.Level*100);
                        p.VidaAtual = p.VidaTotal;
                        p.Iniciativa = 3;
                        p.Ataque = 40 + (p.Level * 10);
                        break;
                    case "Ar":
                        p.VidaTotal = 700 + (p.Level * 100);
                        p.VidaAtual = p.VidaTotal;
                        p.Iniciativa = 5;
                        p.Ataque = 20 + (p.Level * 10);
                        break;
                    case "Terra":
                        p.VidaTotal = 1000 + (p.Level * 100);
                        p.VidaAtual = p.VidaTotal;
                        p.Iniciativa = 1;
                        p.Ataque = 60 + (p.Level * 10);
                        break;
                    case "Fogo":
                        p.VidaTotal = 800 + (p.Level * 100);
                        p.VidaAtual = p.VidaTotal;
                        p.Iniciativa = 4;
                        p.Ataque = 30 + (p.Level * 10);
                        break;
                }

                MessageBoxResult resultado = MessageBox.Show("Deseja Cadastrar o Personagem?", "Confirmação de Cadastro", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.No)
                {
                    //cancela a alteração !! e manda para a page do user
                    frmAdm frm = new frmAdm(u.IDUsuario);
                    frm.Show();
                    Close();
                }
                else
                {
                    Missao n = new Missao();
                    //mandando para o banco
                    if (PersogemDAO.CadastrarPersonagem(p))
                    {
                        n.Name = m.Name; n.Descricao = m.Descricao; n.ExperienciaConcedida = n.ExperienciaConcedida; n.GoldConcedido = n.GoldConcedido; n.personagem = p ;
                        MissaoDAO.CadastrarMissao(n);
                        MessageBox.Show("Cadastro Efetuado com Sucesso ");
                        frmAdm frm = new frmAdm(u.IDUsuario);
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }
    }
}
