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
        }

        //private void Reset_Click(object sender, RoutedEventArgs e)   //Det er et eventhandler, when reset kanppen er blivet trykket, nulstiller password med 'PassWord'
        //{
        //    try
        //    {
        //        Bruger current = (Bruger)BrugerList.SelectedItem; //vælge et item fra viste liste
        //        BrugerDataAccess.ResetPass(current);                //kalder method fra at hente data fra database
        //        current.Password = "PassWord";                      //sætter nuværende password med 'PassWord'
        //        txtPassword.Text = current.Password;
        //        BrugerList.Items.Refresh();                            //viser i listen
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }


        //}

        //private void Create_Click(object sender, RoutedEventArgs e)        //Når Create kanppen er blevet trykket,opretter et nyt bruger
        //{
        //    try
        //    {


        //        Bruger br = new Bruger                      //oprette et nyt objekt og sætter værdier
        //        {
        //            Bruger_Navn = txtBruger_Navn.Text,
        //            Password = txtPassword.Text,
        //            Bruger_Type = txtBruger_Type.Text
        //        };
        //        int result = BrugerDataAccess.InsertBrugerData(br);       //er blevet kaldt 'InsertBrugerData' for at indsætte bruger data i database


        //        if (result == 1)
        //        {
        //            MessageBox.Show("En række er blivet indtastet.");
        //            MainWindow.brugerliste.Add(BrugerDataAccess.ReturnBrugerID(br));
        //            txtBruger_Navn.Clear();
        //            txtPassword.Clear();
        //            txtBruger_Type.Clear();

        //        }
        //        else
        //            MessageBox.Show("Ingen række er blivet indtastet.");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //private void Update_Click(object sender, RoutedEventArgs e)         //Ved at trykke 'Update' kanppen opdaterer data
        //{
        //    Bruger item = (Bruger)BrugerList.SelectedItem;              //vælge et item fra viste liste og tage det item i et Bruger objekt

        //    item.Bruger_Navn = txtBruger_Navn.Text;                 //sætter værdier
        //    item.Password = txtPassword.Text;
        //    item.Bruger_Type = txtBruger_Type.Text;

        //    int result = BrugerDataAccess.UpdateBrugerData(item);           //er blevet kaldt 'UpdateBrugerData' for at opdatere data i databasen
        //    if (result == 1)
        //    {
        //        MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne opdatere data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
        //        if (ms == MessageBoxResult.Yes)                     //Hvis "yes" knappen bliver trykket, går ind 
        //        {
        //            MessageBox.Show("Opdateret rækker er: " + result.ToString());
        //        }
        //        else { MessageBox.Show("Ingen data er blevet opdateret."); }
        //    }
        //    else
        //        MessageBox.Show("Der er ingen række opdateret. ");
        //    BrugerList.Items.Refresh();                                 //opdatere listen
        //}

        //private void Delete_Click(object sender, RoutedEventArgs e)            //Ved at trykke 'Delete' kanppen slette data 
        //{
        //    int result = BrugerDataAccess.DeleteBrugerData((Bruger)BrugerList.SelectedItem);     //er blevet kaldt 'DeleteBrugerData' for at slette data i databasen
        //    if (result == 1)
        //    {

        //        MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne slette data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
        //        if (ms == MessageBoxResult.Yes)                     //Hvis "yes" knappen bliver trykket, går ind 
        //        {

        //            MessageBox.Show("En række er belevt slettet");
        //            MainWindow.brugerliste.Remove((Bruger)BrugerList.SelectedItem);         //det sletter item fra brugerlisten som er blevet vist i listview
        //            txtBruger_Navn.Clear();
        //            txtPassword.Clear();
        //            txtBruger_Type.Clear();
        //        }
        //        else { MessageBox.Show("Ingen data er blevet slettet."); }
        //    }
        //    else
        //        MessageBox.Show("Der er ingen række slettet. ");
        //    BrugerList.Items.Refresh();                         //opdatere listen
        //}

    }
}

  