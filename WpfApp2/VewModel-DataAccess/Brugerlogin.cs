using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoTema.Model;

namespace GeoTema.VewModel_DataAccess
{
    public static class Brugerlogin
    {
        //initialisere connectionString variabel med database address af sql server;
        const string connectionString = @"Data Source = 10.0.4.104; Initial Catalog = GeoTema; User ID = sql_admin; Password=Passw0rd";

        public static string loginselect(string brugernavn, string password)
        {
            // DataTable dataTable = new DataTable();

            string UserType = "";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                // Sql query 'Select' er brugt for at Hente data fra Bruger Tabellen
                using (SqlCommand command = new SqlCommand("Select * from Bruger WHERE Bruger_Navn = @Bruger_Navn And Bruger_Adgangskode = @Bruger_Adgangskode", cnn))         
                {
                    command.Parameters.AddWithValue("@Bruger_Navn", brugernavn); //tilføj parameters
                    command.Parameters.AddWithValue("@Bruger_Adgangskode", password);

                   
                    // dataReader.Read();
                    cnn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    {
                        while (dataReader.Read())
                        {
                            UserType = dataReader.GetString(3);
                        }
                    }
                }
            }
            return UserType;
        }

        //Metode for at indtaste data i Bruger tabellen med sql query.
        public static int InsertBrugerData(Bruger br)   
        {
            
            int result = 0;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                String sql = "Insert into Bruger(Bruger_Navn,Bruger_Adgangskode, Bruger_Type) values(@Bruger_Navn,@Bruger_Adgangskode, @Bruger_Type)";           //Insætter ny data i bruger tabellen
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Bruger_Navn", br.Bruger_Navn);
                    command.Parameters.AddWithValue("@Bruger_Adgangskode", br.Bruger_Adgangskode);
                    command.Parameters.AddWithValue("@Bruger_Type", br.Bruger_Type);




                    cnn.Open();
                    result = command.ExecuteNonQuery();
                }

            }
            return result;
        }

        //Metode for at få alle bruger list
        public static List<Bruger> GetUserList()           
        {
            List<Bruger> list = new List<Bruger>();  //intialisere bruger list
            
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Bruger", cnn))            //SQL Querry for at Hente data fra Bruger tabellen
                {
                    // dataReader.Read();
                    cnn.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Bruger b = new Bruger
                            {
                                Bruger_ID = dataReader.GetInt32(0),
                                Bruger_Navn = dataReader.GetString(1),
                                Bruger_Adgangskode = dataReader.GetString(2),
                                Bruger_Type = dataReader.GetString(3)
                                //Oprettelse_Dato = dataReader.GetDateTime(3),
                                
                            };
                            list.Add(b);   //tilføj bruger oplysninger i list
                        }
                    }
                }
            }
            return list;    //returnere bruger listen
        }

        //Method for at opdatere infomation af Bruger tabellen
        public static void ResetPassword(Bruger reset)            
        {

            
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Update Bruger set Bruger_Adgangskode = @Bruger_Adgangskode where Bruger_ID=@Bruger_ID", cnn))          //Opdatere Password med "PassWord" for at nulstille koden
                {
                    cmd.Parameters.AddWithValue("@Bruger_Adgangskode", reset.Bruger_Adgangskode);
                    cmd.Parameters.AddWithValue("@Bruger_ID", reset.Bruger_ID);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        //Method for at opdatere Bruger tabellen
        public static int UpdateBrugerData(Bruger br)            
        {
            int result = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                // sql query for at opdatere Brugerdata
                string sql = "Update Bruger set Bruger_Navn = @Bruger_Navn, Bruger_Adgangskode=@Adgangskode, Bruger_Type=@Bruger_Type where Bruger_ID=@Bruger_ID";              
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {

                    command.Parameters.AddWithValue("@Bruger_Navn", br.Bruger_Navn);
                    command.Parameters.AddWithValue("@Adgangskode", br.Bruger_Adgangskode);
                    command.Parameters.AddWithValue("@Bruger_Type", br.Bruger_Type);
                    command.Parameters.AddWithValue("@Bruger_ID", br.Bruger_ID);


                    cnn.Open();
                    result = command.ExecuteNonQuery();
                }


            }

            return result;
        }

        // Metode for at slette data fra bruger tabel
        public static int DeleteBrugerData(Bruger br)               
        {
            int result = 0;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "Delete from Bruger where Bruger_ID=@Bruger_ID";               //sletter data fra bruger tabellen

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    command.Parameters.AddWithValue("@Bruger_ID", br.Bruger_ID);


                    cnn.Open();
                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }
        public static Bruger ReturnBrugerID(Bruger br)          //metode for at hente brugerID
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Bruger_ID FROM Bruger WHERE Bruger_Navn=@Bruger_Navn", connection))              //henter Bruger_ID fra Bruger Tabellen med BrugerNavn
                {
                    cmd.Parameters.AddWithValue("@Bruger_Navn", br.Bruger_Navn);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        br.Bruger_ID = reader.GetInt32(0);
                    }
                }
            }
            return br;
        }



    }

}

  