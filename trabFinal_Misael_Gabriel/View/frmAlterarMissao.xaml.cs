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
    /// Interaction logic for frmAlterarMissao.xaml
    /// </summary>
    public partial class frmAlterarMissao : Window
    {
        Usuario u = new Usuario();
        Missao m = new Missao();
        public frmAlterarMissao(int id,int id2)
        {

            this.m.IDMissao = id2;
            m = MissaoDAO.BuscarMissaoPorId(m);
            this.u.IDUsuario = id;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }


        private void btnVCadastrarP_Click(object sender, RoutedEventArgs e)
        {
            Missao mii = new Missao();
            if (txtNome.Text.Trim() == string.Empty || txtDescr.Text.Trim() == string.Empty || txtExp.Text.Trim() == string.Empty || txtGold.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                mii = m;
                mii.Name = txtNome.Text;
                mii.Descricao = txtDescr.Text;
                mii.ExperienciaConcedida = Convert.ToDouble(txtExp.Text);
                mii.GoldConcedido = Convert.ToDouble(txtGold.Text);

                 frmAlteraMissaoP frm = new frmAlteraMissaoP(u.IDUsuario, mii.Name, mii.Descricao, mii.ExperienciaConcedida, mii.GoldConcedido,mii.IDMissao);
                 frm.Show();
                Close();

            }
        }
         
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmAdm frm = new frmAdm(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnVCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Missao mii = new Missao();
            int idP = (int)comboBox.SelectedValue;
    Personagem p = new Personagem();
    p.IDPesonagem = idP;
    p = PersogemDAO.BuscarPersonagemPorId(p);
    if (txtNome.Text.Trim() == string.Empty || txtDescr.Text.Trim() == string.Empty || txtExp.Text.Trim() == string.Empty || txtGold.Text.Trim() == string.Empty)
    {
        MessageBox.Show("Preencha todos os campos");

    }
    else
    {
                mii = m;
                mii.Name = txtNome.Text;
                mii.Descricao = txtDescr.Text;
                mii.ExperienciaConcedida = Convert.ToDouble(txtExp.Text);
                mii.GoldConcedido = Convert.ToDouble(txtGold.Text);
                mii.personagem = p;

                if (MissaoDAO.AlterarMissao(m))
        {
            //cadastra
            MessageBox.Show("Alterado com Sucesso ");
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.ItemsSource = PersogemDAO.returnPAdm();
            //comboBox.ItemsSource = PersogemDAO.RetornarPersonagens();
            comboBox.DisplayMemberPath = "Nome";
            comboBox.SelectedValuePath = "IDPesonagem";

            txtNome.Text = m.Name;
            txtDescr.Text = m.Descricao;
            txtExp.Text = m.ExperienciaConcedida.ToString();
            txtGold.Text = m.GoldConcedido.ToString();
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
