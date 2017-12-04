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
        static LogCombate lg = new LogCombate();
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
           // MessageBox.Show(u.Nome+"," +p.Nome+","+m.Name+","+m.personagem.Nome+","+m.personagem.Modelo);
        }
        int turn = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lg.missao = m;
            lg.personagem = p;
            lg.Data = DateTime.Now;
            lg = LogCombateDAO.CadastrarLogCombate(lg);
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

      
        private void btnInimigo_Click(object sender, RoutedEventArgs e)
        {

            turn =turn+1;
            txtTrun.Text = turn.ToString();
            int dano = Utilidade.atk(m.personagem.Ataque, p.Elemento, m.personagem.Elemento);
            p.VidaAtual = p.VidaAtual - (Utilidade.atk(m.personagem.Ataque, p.Elemento,m.personagem.Elemento));
            txtP1.Text = "Vida :" + p.VidaAtual + "/" + p.VidaTotal;


            DetalheLog dlg = new DetalheLog();
            dlg.log = lg; 
            dlg.Turno = turn;
            dlg.Acao = m.personagem.Nome + " Atacou " + p.Nome + " por " + dano + " de dano";
            DetalheLogDAO.CadastrarLogDet(dlg);
            //fazer o registro no log

            if (p.VidaAtual<0)
            {
                DetalheLog dl = new DetalheLog();
                dl.log = lg;
                dl.Turno = turn;
                dl.Acao = p.Nome + " Perdeu ";
                DetalheLogDAO.CadastrarLogDet(dl);

                u.UltimaConexao = DateTime.Now;
                UsuarioDAO.AlterarUsuario(u);
                p.UltimaConexao = DateTime.Now;
                p.VidaAtual = 0;
                PersogemDAO.AlterarPersonagem(p);

                MessageBox.Show("Voce Perdeu");
                frmUsuario frm = new frmUsuario(u.IDUsuario);
                frm.Show();
                Close();
            }
            

            btnAtk.IsEnabled = true;
        }

        private void btnDesistir_Click(object sender, RoutedEventArgs e)
        {
            DetalheLog dl = new DetalheLog();
            dl.log= lg;
            dl.Turno = turn;
            dl.Acao = p.Nome + " Desistiu ";
            DetalheLogDAO.CadastrarLogDet(dl);


            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);


            p.UltimaConexao = DateTime.Now;
            p.VidaAtual = p.VidaAtual - 100;
            PersogemDAO.AlterarPersonagem(p);
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
            //registra a vida perdida
        }

        private void btnAtk_Click(object sender, RoutedEventArgs e)
        {
            turn = turn + 1;
            txtTrun.Text = turn.ToString();
            int dano = Utilidade.atk(m.personagem.Ataque, p.Elemento, m.personagem.Elemento);
            m.personagem.VidaAtual = m.personagem.VidaAtual - (Utilidade.atk(p.Ataque,m.personagem.Elemento,p.Elemento));
            txtP2.Text = "Vida :" + m.personagem.VidaAtual + "/" + m.personagem.VidaTotal;

            DetalheLog dlg = new DetalheLog();
            dlg.log = lg;
            dlg.Turno = turn;
            dlg.Acao = p.Nome + " Atacou " + m.personagem.Nome + " por " + dano + " de dano";
            DetalheLogDAO.CadastrarLogDet(dlg);
            if (m.personagem.VidaAtual < 0)
            {
                DetalheLog dl = new DetalheLog();
                dl.log= lg;
                dl.Turno = turn;
                dl.Acao = p.Nome + " Ganhou ";
                DetalheLogDAO.CadastrarLogDet(dl);

                u.UltimaConexao = DateTime.Now;
                UsuarioDAO.AlterarUsuario(u);
                p.UltimaConexao = DateTime.Now;
                p.VidaAtual = p.VidaTotal;
                u.Gold = u.Gold + m.GoldConcedido;
                p.Experiencia = p.Experiencia + m.ExperienciaConcedida;
                p = Utilidade.LevelUp(p);
                if(p.Missao<m.IDMissao)
                {
                    p.Missao = m.IDMissao;
                }
                PersogemDAO.AlterarPersonagem(p);

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
