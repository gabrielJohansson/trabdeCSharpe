using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using trabFinal_Misael_Gabriel.DAO;
using trabFinal_Misael_Gabriel.Model;
using trabFinal_Misael_Gabriel.Util;

namespace trabFinal_Misael_Gabriel.View
{
    /// <summary>
    /// Interaction logic for frmBatalha.xaml
    /// </summary>
    public partial class frmBatalha : Window
    {
        Usuario u = new Usuario();
        Personagem p = new Personagem();
        Missao m = new Missao();
        public frmBatalha(int id1,int id2,int id3)
        {
            this.u.IDUsuario = id1;
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            this.p.IDPesonagem= id2;
            p = PersogemDAO.BuscarPersonagemPorId(p);
            this.m.IDMissao = id3;
            m = MissaoDAO.BuscarMissaoPorId(m);
            InitializeComponent();
            MessageBox.Show(u.Nome+"," +p.Nome+","+m.Name+","+m.personagem.Nome+","+m.personagem.Modelo);
        }
        int turn = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnInimigo.IsEnabled = false;
            ImageBrush brush = Utilidade.returnImage(p.Modelo);
            bdPersonagem.Background = brush;


            ImageBrush brush2 = Utilidade.returnImage(m.personagem.Modelo);
            bdInimigo.Background = brush2;

            
            txtP1.Text = "Vida :"+p.VidaAtual+"/"+p.VidaTotal;
            txtTrun.Text = turn.ToString();
            txtP2.Text = "Vida :" + m.personagem.VidaAtual + "/" + m.personagem.VidaTotal;

            btnAtk.IsEnabled = false;
            if (p.Iniciativa > m.personagem.Iniciativa)
            {
                btnAtk.IsEnabled = true;
            }
            else
            {
                btnInimigo.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //registra o user date
            //registra o p date
        }

        private void btnInimigo_Click(object sender, RoutedEventArgs e)
        {
            turn =turn+1;
            txtTrun.Text = turn.ToString();
            p.VidaAtual = p.VidaAtual - (Utilidade.atk(m.personagem.Ataque, p.Elemento,m.personagem.Elemento));
            txtP1.Text = "Vida :" + p.VidaAtual + "/" + p.VidaTotal;
            if(p.VidaAtual<0)
            {
                MessageBox.Show("Voce Perdeu");
                frmUsuario frm = new frmUsuario(u.IDUsuario);
                frm.Show();
                Close();
            }

            //fazer o registro no log

            btnAtk.IsEnabled = true;
        }

        private void btnDesistir_Click(object sender, RoutedEventArgs e)
        {
            //encerra td
            //registra no log
            //registra a vida perdida
        }

        private void btnAtk_Click(object sender, RoutedEventArgs e)
        {
            turn = turn + 1;
            txtTrun.Text = turn.ToString();
            m.personagem.VidaAtual = m.personagem.VidaAtual - (Utilidade.atk(p.Ataque,m.personagem.Elemento,p.Elemento));
            txtP2.Text = "Vida :" + m.personagem.VidaAtual + "/" + m.personagem.VidaTotal;
            if (m.personagem.VidaAtual < 0)
            {
                MessageBox.Show("Voce Ganhou");
                frmUsuario frm = new frmUsuario(u.IDUsuario);
                frm.Show();
                Close();
            }
            //registro no log            
            btnAtk.IsEnabled = false;
            btnInimigo.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
    }
}
