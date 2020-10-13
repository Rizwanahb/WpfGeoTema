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
    public partial class StandardBrugerView : UserControl
    {
        public StandardBrugerView()
        {
            InitializeComponent();
            dataGrid_Vis.ItemsSource = Geodata.GetFodselsrate(); //henter og viser data
           
        }
      
    }


}






   