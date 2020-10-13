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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoTema.VewModel_DataAccess;
using GeoTema.Model;



namespace GeoTema.View
{
    /// <summary>
    /// Interaction logic for StandardBrugerView.xaml
    /// </summary>
    public partial class SuperBrugerView : UserControl
    {
  

        public SuperBrugerView()
        {
            InitializeComponent();
            dataGrid_Vis.ItemsSource = Geodata.GetFodselsrate(); //henter og viser data



        }
        private void Create_Click(object sender, RoutedEventArgs e)  ////Når Create kanppen er blevet trykket,opretter ny data
        {

            try
            {


                Land l = new Land           //lavet objekt af Land Klasse og sætte værdier
                {
                    Land_Navn = txtLandNavn.Text
                };
                Verdensdel v = new Verdensdel        //lavet objekt af Verdensdel Klasse og sætte værdier
                {
                    Verdensdel_Navn = txtVerdensdelNavn.Text
                };
                Rang r = new Rang              //lavet objekt af RangTable Klasse og sætte værdier
                {
                    Rang_Nummer = Int32.Parse(txtRang.Text),
                    Fødselsrate = Decimal.Parse(txtFødselsrate.Text)
                };


               

                var landid = Geodata.ReturnLandID(l);           //henter seneste indsat datas ID fra Land og indsætter det i et Land objekt 
                var verdenid = Geodata.ReturnVerdensdelID(v);      //henter seneste indsat datas ID fra Verdensdel og indsætter det i et  Verdensdel objekt
                var land = Geodata.InsertLand(l);                   //henter seneste indsat datas Navn fra Land  og indsætter det i et Land objekt
                var verden = Geodata.InsertVerdensdel(v);           //henter seneste indsat datas Navn fra Verdensdel  og indsætter det i et Verdensdel objekt
                var rang = Geodata.InsertRang(r, l);                //henter seneste indsat datas Rang fra Rang  og indsætter det i et Rang objekt
             

                if (rang == null)
                {
                    MessageBox.Show("Rang has been used for another land. Try another rang");
                    return;
                }

                Geodata.InsertLand_Verdensdel(land, verden);            //indsætte Land og Verdensdel i Land_Verdensdel

                Fødselsrate_Rang fr = new Fødselsrate_Rang            //oprette et Fødselsrate_Rang og sætter værdier
                {

                    LandId = landid.Land_ID,
                    VerdenId = verdenid.V_ID,
                    Land_Navn = land.Land_Navn,
                    Verdensdel_Navn = verden.Verdensdel_Navn,
                    Rang = rang.Rang_Nummer,
                    Fødselsrate = rang.Fødselsrate
                };

                List<Fødselsrate_Rang> myList = new List<Fødselsrate_Rang>(MainWindow.Geodatalist);         //oprette new list som Fødselsrate_RangTable
                if (myList.FirstOrDefault(x => x.LandId == land.Land_ID && x.VerdenId == verden.V_ID) == null) //tjekker om data eksisterer udfra dens ID
                {

                    MainWindow.Geodatalist.Add((fr));                         //Hvis der er ikke er lignende ID, så bliver den tilføjet
                    //MainWindow.Geografiklist.Add(GeografikDataAccess.ReturnGeoID(fr));
                }


                else
                {
                    MessageBox.Show("Der er allerede de her data i tabellen.");         // ellers bliver den ikke tilføjet
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)     //når 'Update' 
        {
            //Fødselsrate_Rang item = (Fødselsrate_Rang)Geodatalist.SelectedItem;   //vælge et item fra viste liste og tage det item i et Fødselsrate_RangTable objekt



            //item.Land_Navn = txtLandNavn.Text;                 //Indsætter værdier
            //item.Verdensdel_Navn = txtVerdensdelNavn.Text;
            //item.Rang = int.Parse(txtRang.Text);
            //item.Fødselsrate = Decimal.Parse(txtFødselsrate.Text);
            //int result = Geodata.UpdateGeodata(item);                 //er blevet kaldt 'UpdateGeografikData' for at opdatere data i databasen
            //if (result >= 1)
            //{

            //    MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne opdatere data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
            //    if (ms == MessageBoxResult.Yes)//Hvis "yes" knappen bliver trykket, går ind
            //    {

            //        MessageBox.Show("Opdateret rækker er: " + result.ToString());
            //    }
            //    else { MessageBox.Show("Ingen data er blevet opdateret."); }
            //}
            //else
            //    MessageBox.Show("Der er ingen række opdateret. ");
            //Geodatalist.Items.Refresh();                              //opdaterer listen
        }

        private void Delete_Click(object sender, RoutedEventArgs e)      //Ved at trykke 'Delete' kanppen slette data 
        {
            //int result = Geodata.DeleteGeodata((Fødselsrate_Rang)Geodatalist.SelectedItem);            //er blevet kaldt 'DeleteGeografikrData' for at slette data i databasen
            //if (result >= 1)
            //{
            //    if (result == 1)
            //    {

            //        MessageBoxResult ms = MessageBox.Show("Er du sikker på at du vil gerne slette data?", "Confirmation", MessageBoxButton.YesNo); //laver et messagebox med tre knapper og sætter det i result variable
            //        if (ms == MessageBoxResult.Yes)//Hvis "yes" knappen bliver trykket, går ind
            //        {
            //            MessageBox.Show("En række er belevt slettet");
            //            MainWindow.Geodatalist.Remove((Fødselsrate_Rang)Geodatalist.SelectedItem);           //det sletter item fra data listen som er blevet vist i listview
            //            txtLandNavn.Clear();
            //            txtVerdensdelNavn.Clear();
            //            txtRang.Clear();
            //            txtFødselsrate.Clear();
            //        }
            //        else { MessageBox.Show("Ingen data er blevet slettet."); }
            //    }
            //    else
            //        MessageBox.Show("Der er ingen række slettet. ");
            //    Geodatalist.Items.Refresh();              //Opdaterer Listen
            }
        }

      
    }

