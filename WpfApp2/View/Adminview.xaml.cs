using GeoTema.Model;
using GeoTema.VewModel_DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoTema.View
{
    /// <summary>
    /// Interaction logic for standardcontrol.xaml
    /// </summary>
    public partial class Adminview : UserControl
    {
        public Adminview()
        {
            InitializeComponent();
            dataGrid_VisBruger.ItemsSource = Brugerlogin.GetUserList();              //henter og viser bruger list

        }
        private void Refresh_Click(object sender, RoutedEventArgs e) {
            dataGrid_VisBruger.ItemsSource = Brugerlogin.GetUserList();              //henter og viser bruger list
        }

        private void Reset_Click(object sender, RoutedEventArgs e)   //Det er et eventhandler, when reset kanppen er blivet trykket, nulstiller password med 'PassWord'
        {
            try
            {
               
                Bruger current = (Bruger)dataGrid_VisBruger.SelectedItem; //vælge et item fra datagrid
                Brugerlogin.ResetPassword(current);                //kalder method fra at hente data fra database
                current.Bruger_Adgangskode = txtadgangskode.Text;                      //sætter nuværende password med 'PassWord'
                txtadgangskode.Text = current.Bruger_Adgangskode;
                dataGrid_VisBruger.Items.Refresh();                            //viser i listen
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Create_Click(object sender, RoutedEventArgs e)        //Når Create kanppen er blevet trykket,opretter et nyt bruger
        {
            try
            {


                Bruger br = new Bruger                      //oprette et nyt objekt og sætter værdier
                {
                    Bruger_Navn = txtbrugernavn.Text,
                    Bruger_Adgangskode = txtadgangskode.Text,
                    Bruger_Type = txtbrugertype.Text
                };
                int result = Brugerlogin.InsertBrugerData(br);       //er blevet kaldt 'InsertBrugerData' for at indsætte bruger data i database


                if (result == 1)
                {
                    MessageBox.Show("En række er blivet indtastet.");
                    dataGrid_VisBruger.Items.Add(Brugerlogin.ReturnBrugerID(br));                   
                    txtbrugernavn.Clear();
                    txtadgangskode.Clear();
                    txtbrugertype.Clear();

                }
                else
                    MessageBox.Show("Ingen række er blivet indtastet.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)         //Ved at trykke 'Update' knappen opdaterer data
        {
            Bruger current = (Bruger)dataGrid_VisBruger.SelectedItem; //vælge et item fra viste data grid lis tog tager item i Bruger objekt
          

            current.Bruger_Navn = txtbrugernavn.Text;                 //sætter værdier
            current.Bruger_Adgangskode = txtadgangskode.Text;
            current.Bruger_Type = txtbrugertype.Text;
    

            int result = Brugerlogin.UpdateBrugerData(current);           //er blevet kaldt 'UpdateBrugerData' for at opdatere data i databasen
            if (result == 1)
            {
                MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne opdatere data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
                if (ms == MessageBoxResult.Yes)                     //Hvis "yes" knappen bliver trykket, går ind 
                {
                    MessageBox.Show("Opdateret rækker er: " + result.ToString());
                }
                else { MessageBox.Show("Ingen data er blevet opdateret."); }
            }
            else
                MessageBox.Show("Der er ingen række opdateret. ");
            dataGrid_VisBruger.Items.Refresh();                                 //opdatere listen
        }

        private void Delete_Click(object sender, RoutedEventArgs e)            //Ved at trykke 'Delete' kanppen slette data 
        {
            int result = Brugerlogin.DeleteBrugerData((Bruger)dataGrid_VisBruger.SelectedItem);     //er blevet kaldt 'DeleteBrugerData' for at slette data i databasen
            if (result == 1)
            {

                MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne slette data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
                if (ms == MessageBoxResult.Yes)                     //Hvis "yes" knappen bliver trykket, går ind 
                {

                    MessageBox.Show("En række er belevt slettet");
                    MainWindow.brugerliste.Remove((Bruger)dataGrid_VisBruger.SelectedItem);         //det sletter item fra brugerlisten som er blevet vist i listview
                    txtbrugernavn.Clear();                 //sætter værdier
                    txtadgangskode.Clear();
                    txtbrugertype.Clear();
                }
                else { MessageBox.Show("Ingen data er blevet slettet."); }
            }
            else
                MessageBox.Show("Der er ingen række slettet. ");
            dataGrid_VisBruger.Items.Refresh();                      //opdatere listen
        }

    }
}

