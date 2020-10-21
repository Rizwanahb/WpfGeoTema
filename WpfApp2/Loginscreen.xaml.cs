using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using GeoTema.Model;
using GeoTema.VewModel_DataAccess;
using GeoTema.View;

namespace GeoTema
{
    /// <summary>
    /// Interaction logic for Loginscreen.xaml
    /// </summary>
    public partial class Loginscreen  : Window
    { 
 
        public Loginscreen()
        {
            InitializeComponent();
         

            
        }

            private void btnlogin_Click(Object sender,RoutedEventArgs e)
            {
            Bruger current = new Bruger
            {
                //loginselect metod er blevet kaldet for at hente bruger data fra Bruger tabellen
                Bruger_Type = Brugerlogin.loginselect(txtbrugernavn.Text, txtpwd.Password)              
                  
            };
            if (current.Bruger_Type != "")   //Hvis bruger findes så viser MainWindow
            {
                MainWindow main = new MainWindow(current);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fejl! Prøv igen.");
            }


           
        }

        private void txtpwd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
