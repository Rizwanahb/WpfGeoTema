using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows;
using GeoTema.View;
using GeoTema.Model;
using GeoTema.VewModel_DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GeoTema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Bruger selected)
        {

            InitializeComponent();

            DataContext = this;
            if (selected.Bruger_Type == "Administrator")     //Admin har alle views rettigheder 
            {
                btnsuper.Visibility = Visibility.Hidden;
                btnstandard.Visibility = Visibility.Hidden;
                btnadmin.Visibility = Visibility.Visible;

            }
            else if (selected.Bruger_Type == "Superbruger") // super bruger har kun rettigheder superBrugerView 
            {
                btnsuper.Visibility = Visibility.Visible;
                btnstandard.Visibility = Visibility.Hidden;
                btnadmin.Visibility = Visibility.Hidden;
                Opret.IsEnabled = false;

            }
            else if (selected.Bruger_Type == "Standardbruger") // standard bruger har kun ret til  standard view
            {
                btnstandard.Visibility = Visibility.Visible;
                btnsuper.Visibility = Visibility.Hidden;
                btnadmin.Visibility = Visibility.Hidden;

                Tilføj.IsEnabled = false;
                Opret.IsEnabled = false;

            }
        }

       

        private static ObservableCollection<Bruger> _brugerliste = new ObservableCollection<Bruger>(Brugerlogin.GetUserList());

        public static ObservableCollection<Bruger> brugerliste          //property for data binding med Bruger data
        {
            get { return _brugerliste; }
            set { _brugerliste = value; }
        }

        private static ObservableCollection<Fødselsrate_Rang> _geodatalist = new ObservableCollection<Fødselsrate_Rang>(Geodata.GetFodselsrate());

        public static ObservableCollection<Fødselsrate_Rang> Geodatalist     //property for data binding med data
        {
            get { return _geodatalist; }
            set { _geodatalist = value; }
        }

        private void Vis_Clicked(object sender, MouseButtonEventArgs e)
        {
            stackwindow.Children.Clear();
            StandardBrugerView standard = new StandardBrugerView();
            //btnstandard.Visibility = Visibility.Hidden;            
            stackwindow.Children.Add(standard);
        }

        private void logud_Clicked(object sender, MouseButtonEventArgs e)
        {
            stackwindow.Children.Clear();           
            this.Close();
        }

        private void Account_Clicked(object sender, MouseButtonEventArgs e)
        {
            

        }
       

        private void Tilføj_Clicked(object sender, MouseButtonEventArgs e)
        {
            stackwindow.Children.Clear();
            SuperBrugerView super = new SuperBrugerView();
            stackwindow.Children.Add(super);
           
        }
    private void Opret_Clicked(object sender, MouseButtonEventArgs e)
        {
            stackwindow.Children.Clear();
            Adminview admin = new Adminview();
            stackwindow.Children.Add(admin);
        }
        //private void ChangePassword_Clicked(object sender, MouseButtonEventArgs e)
        //{

        //}
        //private void Logout_Clicked(object sender, MouseButtonEventArgs e)
        //{

        //}
        //private void PasswordSave_Clicked(object sender, MouseButtonEventArgs e)
        //{

        //}
        private void btnstandard_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void btnsuper_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnadmin_Click(object sender, RoutedEventArgs e)
        {
            Adminview admin = new Adminview();
            //btnadmin.Visibility = Visibility.Hidden;
            stackwindow.Children.Add(admin);
        }

    }
}


       











