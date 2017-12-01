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
    /// Interaction logic for frmListPersonagemU.xaml
    /// </summary>
    public partial class frmListPersonagemU : Window
    {
        Usuario u = new Usuario();

        public frmListPersonagemU(int id)
        {
            this.u.IDUsuario = id;
            //Metodo para linkar o id no obj da page
            u = UsuarioDAO.BuscarUsuarioPorId(u);
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            u.UltimaConexao = DateTime.Now;
            UsuarioDAO.AlterarUsuario(u);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //carrega o datagrid com seus chars          
            dtg.ItemsSource = PersogemDAO.RetornarPersonagensUser(u.IDUsuario);
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            frmUsuario frm = new frmUsuario(u.IDUsuario);
            frm.Show();
            Close();
        }

        
        Personagem p = new Personagem();

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult resultado = MessageBox.Show("Deseja Deletar Mesmo?", "Apagar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                
                //remover personagem vai ser a troca de idusuario para um user definido.
                //esse uservai ser como um cemiterio de personagens
                //para n dar conflito com os logs
                 if(PersogemDAO.RemoverPersonagem(p))
                  {
                      MessageBox.Show("Sucesso");
                      dtg.ItemsSource = null;
                      dtg.ItemsSource = PersogemDAO.RetornarPersonagensUser(u.IDUsuario);

                    Personagem p = new Personagem();
                       txtNome.Text = "";
                  }
                  
            }
        }

        private void dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //pega o obj da row
            
            p = (Personagem)dtg.SelectedItem;
            txtNome.Text= p.Nome;
        }
    }
}
