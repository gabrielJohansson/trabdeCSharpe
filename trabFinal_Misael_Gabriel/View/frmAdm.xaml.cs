﻿using System;
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
    /// Interaction logic for frmAdm.xaml
    /// </summary>
    public partial class frmAdm : Window
    {
        Usuario u = new Usuario();
        public frmAdm(int id)
        {
            this.u.IDUsuario = id;
            //Metodo para linkar o id no obj da page
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            //voltar ao INICIO
            frmPageInicial frm = new frmPageInicial();
            frm.Show();
            Close();
        }

        private void Carregar(object sender, RoutedEventArgs e)
        {
            dtg.ItemsSource = UsuarioDAO.RetornarUsuarios();

        }

        private void btnCriarMissao_Click(object sender, RoutedEventArgs e)
        {
            //vai para a page de criaçao
            frmCadastroMissao frm = new frmCadastroMissao(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnAlterarMissao_Click(object sender, RoutedEventArgs e)
        {
            frmListMissaoAdm frm = new frmListMissaoAdm(u.IDUsuario);
            frm.Show();
            Close();
            //lista as missoes e deixa alterar o nome,gold,exp e o char nela
           
        }

        private void btnRegistros_Click(object sender, RoutedEventArgs e)
        {
            frmSelLogADM frm = new frmSelLogADM(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            frmLisPersonagemADM frm = new frmLisPersonagemADM(u.IDUsuario);
            frm.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }
    }
}
