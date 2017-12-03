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
    /// Interaction logic for frmSelMissao.xaml
    /// </summary>
    public partial class frmSelMissao : Window
    {
        Usuario u = new Usuario();
        public frmSelMissao(int id)
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
            comboBox.ItemsSource = PersogemDAO.RetornarPersonagensUser(u.IDUsuario);
            comboBox.DisplayMemberPath = "Nome";
            comboBox.SelectedValuePath = "IDPesonagem";
        }
        Personagem p = new Personagem();
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idP = (int)comboBox.SelectedValue;
            
            p.IDPesonagem = idP;
            p = PersogemDAO.BuscarPersonagemPorId(p);
            dtg.ItemsSource = MissaoDAO.RetornarMissoesP(p.Missao);
            Missao m = new Missao();
        }

        Missao m = new Missao();
        private void dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //pega o obj da row

            m = (Missao)dtg.SelectedItem;
            txtNome.Text = m.Name;
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnEscolher_Click(object sender, RoutedEventArgs e)
        {
            //
            //manda o personagem e a missao
            if (m.IDMissao != 0 && p.IDPesonagem != 0)
            {
                frmBatalha frm = new frmBatalha(u.IDUsuario, p.IDPesonagem, m.IDMissao);
                frm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Escolha o Personagem e a Missao");
            }
        }
    }
}
