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

       
        private void btnVCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //cadastra a missao
            //verificar se tudo está preenchido
            int idP = (int)comboBox.SelectedValue;
            Personagem p = new Personagem();
            p.IDPesonagem = idP;
            p = PersogemDAO.BuscarPersonagemPorId(p);
            if (txtNome.Text.Trim() == string.Empty || txtDescr.Text.Trim() == string.Empty || txtExp.Text.Trim() == string.Empty|| txtGold.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos");

            }
            else
            {
                Missao m = new Missao { Name = txtNome.Text, Descricao = txtDescr.Text, ExperienciaConcedida=Convert.ToDouble(txtExp.Text),GoldConcedido= Convert.ToDouble(txtGold.Text), personagem = p };

                if (MissaoDAO.CadastrarMissao(m))
                {
                    //cadastra
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
            //volta para adm
        }

        private void btnVCadastrarP_Click(object sender, RoutedEventArgs e)
        {
            //verifica se tudo está preenchido
            //se o char estiver nulo n cadastre
            //manda para o adm cadastro p 
            //manda a missão
            //ao cadastrar o personagem lá já vincula ele na missão
            if (txtNome.Text.Trim() == string.Empty || txtDescr.Text.Trim() == string.Empty || txtExp.Text.Trim() == string.Empty || txtGold.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos");          
            }
            else
            {
                Missao m = new Missao { Name = txtNome.Text, Descricao = txtDescr.Text, ExperienciaConcedida = Convert.ToDouble(txtExp.Text), GoldConcedido = Convert.ToDouble(txtGold.Text) };
                frmCadastroPersonagemADM frm = new frmCadastroPersonagemADM(u.IDUsuario, m.Name, m.Descricao, m.ExperienciaConcedida, m.GoldConcedido);
                frm.Show();
                Close();

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //preenche o drop down com os personagens q tem o user com adm==true
            //!!!!!!!!!!!!!
            //trocar ara isso dps
            comboBox.ItemsSource = PersogemDAO.returnPAdm();
            //comboBox.ItemsSource = PersogemDAO.RetornarPersonagens();
            comboBox.DisplayMemberPath = "Nome";
            comboBox.SelectedValuePath = "IDPesonagem";

            if (comboBox.Items.IsEmpty)
            {
                comboBox.IsHitTestVisible = false;
                btnVCadastrar.IsEnabled = false;
            }
            
        }

        private void txtGold_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
