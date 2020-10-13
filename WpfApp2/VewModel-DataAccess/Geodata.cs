using GeoTema.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoTema.View;

namespace GeoTema.VewModel_DataAccess
{
    public static class Geodata
    {
        
        const string connectionString = @"Data Source=10.0.4.104;Initial Catalog=GeoTema;User ID=sql_admin;Password=Passw0rd";       //et string for at forbinde med database af sqlserver
        public static List<Fødselsrate_Rang> GetFodselsrate()   //Method for at få en list af film fra database
        {
           

            List<Fødselsrate_Rang> Grouplist = new List<Fødselsrate_Rang>(); //oprette ny list som Fødselsrate_RangTable

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string sql;
                //sql query har brugt inner join for at hente data fra forskellige tabeller
                sql = "SELECT Land.Land_ID,Land. Land,Verdensdel.V_ID, Verdensdel.Verdensdel_navn,Rang, Rang.Fødselsrate FROM Land " +                  
                "INNER JOIN Indeks ON Land.Land_ID=Indeks.Land_ID INNER Join Verdensdel ON Verdensdel.V_ID= Indeks.V_ID INNER JOIN Rang ON Rang.Land_ID = Land.Land_ID";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {

                    cnn.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Fødselsrate_Rang fr = new Fødselsrate_Rang();         //oprette et objekt af Fødselsrate_Rang klasse
                        fr.LandId = Int32.Parse(dataReader[0].ToString());          //hente første coloners data
                        fr.Land_Navn = dataReader[1].ToString();                    //hente anden coloners data



                        fr.VerdenId = Convert.ToInt32(dataReader[2].ToString());            //hente tredje kolonners data
                        fr.Verdensdel_Navn = dataReader[3].ToString();                  //hente fjerde kolonners data
                        fr.Rang = Int32.Parse(dataReader[4].ToString());                //hente femte kolonners data                
                        fr.Fødselsrate = Decimal.Parse(dataReader[5].ToString());              //hente sjette kolonners data

                        Grouplist.Add(fr);              //tilføjer hvert enkelt objekt ind til listen

                    }
                }
            }                                

            return Grouplist;               // returnere listen
        }


        public static Land InsertLand(Land l)   //Method for at indtaste Land data i database
        {            
            int result = 0;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = "select Land_ID from Land where Land=@Land";            // SQL query at find Land ID vha. Landnavn indtastning
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Land", l.Land_Navn);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        l.Land_ID = reader.GetInt32(0);
                    }
                    reader.Close();

                }

                if (l.Land_ID > 0)          //Tjekker LandID. Hvis den findes i tabellen så bliver den ikke indsat
                {
                    return l;               //Returnere Lande Objektet.
                }
                else if (l.Land_ID == 0)            // hvis den ikke findes i forvejen, så bliver den indsat i tabellen.
                {
                    string sql1 = "Insert into Land(Land) values(@Land)";             //Insætter nyt LandNavn i tabellen
                    using (SqlCommand command = new SqlCommand(sql1, cnn))
                    {
                        command.Parameters.AddWithValue("@Land_Navn", l.Land_Navn);


                        result = command.ExecuteNonQuery();
                    }
                    string sql2 = "select Land_ID from Land where Land=@Land_Navn";           // Henter den seneste LandNavn's ID.
                    using (SqlCommand command = new SqlCommand(sql2, cnn))
                    {
                        command.Parameters.AddWithValue("@Land_Navn", l.Land_Navn);



                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            l.Land_ID = reader.GetInt32(0);
                        }

                        reader.Close();
                    }
                }

            }
            return l;           //returnere LandObjektet.
        }

        public static Verdensdel InsertVerdensdel(Verdensdel v)   //Method for at indsætte data i Verdensdel tabel i database.
        {


            int result = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = "select Verdensdel_ID from  Verdensdel where Verdensdel_Navn=@Verdensdel_Navn";         // SQL querry for samle ID fra indsat Landnavn
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Verdensdel_Navn", v.Verdensdel_Navn);



                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        v.V_ID = reader.GetInt32(0);
                    }
                    reader.Close();

                }

                if (v.V_ID > 0)                 //Tjekker Verdensdel's ID om den findes i tabellen så bliver den ikke indsat
                {
                    return v;                           // returnere Verdensdel Objektet.
                }
                else if (v.V_ID == 0)           // hvis den ikke findes i forvejen, så bliver den indsat i tabellen.
                {


                    string sql1 = "Insert into Verdensdel(Verdensdel_Navn) values(@Verdensdel_Navn)";           //Insætter nyt VerdensdelNavn i tabellen
                    using (SqlCommand command = new SqlCommand(sql1, cnn))
                    {
                        command.Parameters.AddWithValue("@Verdensdel_Navn", v.Verdensdel_Navn);

                        //cnn.Open();
                        result = command.ExecuteNonQuery();
                    }
                    string sql2 = "select Verdensdel_ID from  Verdensdel where Verdensdel_Navn=@Verdensdel_Navn";           // Henter den seneste LandNavn's ID.
                    using (SqlCommand command = new SqlCommand(sql2, cnn))
                    {
                        command.Parameters.AddWithValue("@Verdensdel_Navn", v.Verdensdel_Navn);


                        //cnn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            v.V_ID = reader.GetInt32(0);
                        }
                        reader.Close();

                    }


                }

            }
            return v;           //returnere LandObjektet.
        }
        public static int InsertLand_Verdensdel(Land l, Verdensdel v)   //Method for at indtaste data i database
        {


            int result = 0;
            int lvid = 0;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {


                cnn.Open();
                string sql = "select Indeks_ID from Indeks where V_ID=@V_ID and land_ID=@Land_ID";          // Henter LandVerdesndel ID
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@V_ID ", v.V_ID);
                    command.Parameters.AddWithValue("@Land_ID ", l.Land_ID);


                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lvid = reader.GetInt32(0);
                    }
                    reader.Close();

                }

                if (lvid > 0)                   //tjekker om ID findes i forvejen eller ej. Hvis den gør så indsætter den ikke noget
                {
                    return result;
                }
                else if (lvid == 0)              //hvis den ikke findes så indsætter den ID
                {

                    string sql1 = "Insert into Indeks(Land_ID, V_ID) values(@Land_ID, @V_ID)";           // indsætter ny LandID og ny verdensdelID i Land_Verdensdel tabellen
                    using (SqlCommand command = new SqlCommand(sql1, cnn))
                    {
                        command.Parameters.AddWithValue("@Land_ID", l.Land_ID);
                        command.Parameters.AddWithValue("@V_ID", v.V_ID);

                        result = command.ExecuteNonQuery();
                    }
                }

            }
            return result;
        }

        //public static Indeks GetIndeks(Indeks lv)          //Metode for at hente ID fra Land_Verdensdel tabellen
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sql2 = "Select Indeks_ID from  Indeks where Land_ID =@land_id";          //henter Landverdensdel ID med LandID
        //        using (SqlCommand command = new SqlCommand(sql2, connection))
        //        {
        //            command.Parameters.AddWithValue("@Land_ID", lv.Land_ID);


        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                lv.Land_ID = reader.GetInt32(1);
        //            }

        //            reader.Close();
        //        }


        //    }
        //    return lv;
        //}
        public static Rang InsertRang(Rang r, Land l)   //Method for at indtaste data i Rang tabellen
        {
            int result = 0;
            int rangLandId = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = "select Land_ID,Rang_ID from Rang where Rang=@Rang";          //henter Land_ID og Rang_ID fra Rang tabellen
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Rang", r.Rang_Nummer);



                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rangLandId = reader.GetInt32(0);
                        r.Rang_ID = reader.GetInt32(1);
                    }
                    reader.Close();

                }

                if (r.Rang_ID > 0 && l.Land_ID == rangLandId)               // hvis Rang_ID og Land_ID findes så bliver den ikke indsat
                {
                    return r;
                }
                else if (r.Rang_ID > 0)                                     // hvis Rang_ID findes så sker der ikke noget
                {
                    return null;
                }
                else if (r.Rang_ID == 0)                                    // hvis Rang_ID ikke findes så bliver dne indsat
                {
                    string sql1 = "Insert into Rang(Land_ID, Rang,Fødselsrate) values(@Land_ID,@Rang,,@Fødselsrate)";               //indsætter data i Rang tabellen
                    using (SqlCommand command = new SqlCommand(sql1, cnn))
                    {
                        command.Parameters.AddWithValue("@Land_ID", l.Land_ID);
                        command.Parameters.AddWithValue("@Rang",r.Rang_Nummer);
                        //command.Parameters.AddWithValue("@Statistik_id", 1);
                        command.Parameters.AddWithValue("@Fødselsrate", r.Fødselsrate);
                        //cnn.Open();
                        result = command.ExecuteNonQuery();
                    }
                    string sql2 = "select Rang_ID from  Rang where Rang=@Rang";             // henter Rang_ID som lige er blevet indsat
                    using (SqlCommand command = new SqlCommand(sql2, cnn))
                    {
                        command.Parameters.AddWithValue("@Rang", r.Rang_Nummer);


                        //cnn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            r.Rang_ID = reader.GetInt32(0);
                        }
                        reader.Close();

                    }

                    cnn.Close();
                }

            }
            return r;
        }
        public static int UpdateGeodata(Fødselsrate_Rang fr)            //Method for at opdatere infomation af data
        {
            int result = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "Update Land set Land = @Land_Navn where Land_ID=@Land_ID";               // opdaterer den eksisterende Landnavn med den seneste.
                cnn.Open();
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Land_ID", fr.LandId);
                    command.Parameters.AddWithValue("@Land_Navn", fr.Land_Navn);



                    result = command.ExecuteNonQuery();
                }

                string sql1 = "Update Verdensdel set Verdensdel_Navn = @Verdensdel_Navn where V_ID=@V_ID";            // opdaterer den eksisterende Verdensdelnavn med den seneste.
                using (SqlCommand command = new SqlCommand(sql1, cnn))
                {
                    command.Parameters.AddWithValue("@V_ID", fr.VerdenId);
                    command.Parameters.AddWithValue("@Verdensdel_Navn", fr.Verdensdel_Navn);



                    result = command.ExecuteNonQuery();
                }
                string sql2 = "Update Rang set Rang= @Rang where Land_ID=@Land_ID";                                         // opdaterer den eksisterende Rang med den seneste.
                using (SqlCommand command = new SqlCommand(sql2, cnn))
                {
                    command.Parameters.AddWithValue("@Rang", fr.Rang);
                    command.Parameters.AddWithValue("@Land_ID", fr.LandId);
                    command.Parameters.AddWithValue("@Data",fr.Fødselsrate );



                    result = command.ExecuteNonQuery();
                }

            }

            return result;
        }


        public static int DeleteGeodata(Fødselsrate_Rang fr)             //Metode for at slette data
        {
            int result = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string sql = "Delete from Indeks where Land_ID=@Land_ID";                  //sletter data fra LandVerdesndel Tabellen

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Land_ID", fr.LandId);
                    result = command.ExecuteNonQuery();
                }
               
                string sql2 = "Delete from Rang where Land_ID=@Land_ID";                    // Sletter data fra Rang Tabellen

                using (SqlCommand command = new SqlCommand(sql2, cnn))
                {
                    command.Parameters.AddWithValue("@Land_id", fr.LandId);

                    result = command.ExecuteNonQuery();
                }
                string sql3 = "Delete from Land where Land_ID=@Land_ID";                    // Sletter data fra Land tabellen
                using (SqlCommand command = new SqlCommand(sql3, cnn))
                {
                    command.Parameters.AddWithValue("@Land_ID", fr.LandId);

                    result = command.ExecuteNonQuery();
                }

            }

            return result;
        }
        public static Land ReturnLandID(Land l)                                             //metode for at hente data fra Land tabellen
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Land_ID FROM dbo.Land WHERE Land=@Land", connection))          //henter LandID fra Land tabellen
                {
                    cmd.Parameters.AddWithValue("@Land", l.Land_Navn);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        l.Land_ID = reader.GetInt32(0);
                    }
                }
            }
            return l;
        }
        public static Verdensdel ReturnVerdensdelID(Verdensdel v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Verdensdel_ID FROM dbo.Verdensdel WHERE Verdensdel_Navn=@Verdensdel_Navn", connection))              // henter VerdensdelID fra Verdensdel Tabellen
                {
                    cmd.Parameters.AddWithValue("@Verdensdel_Navn", v.Verdensdel_Navn);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        v.V_ID = reader.GetInt32(0);
                    }
                }
            }
            return v;
        }
        public static int ReturnRangID(Land l)
        {
            int Rangid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Rang_ID FROM dbo.Rang WHERE Land_ID=@Land_ID", connection))              // henter Rang_ID fra Rang tabellen med LandID
                {
                    cmd.Parameters.AddWithValue("@Land_ID", l.Land_ID);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Rangid = reader.GetInt32(0);
                    }
                }
            }
            return Rangid;
        }
    }
}



