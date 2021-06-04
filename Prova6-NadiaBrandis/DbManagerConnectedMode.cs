using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Prova6_NadiaBrandis
{
    class DbManagerConnectedMode
    {
        List<Agente> Agenti = new List<Agente>();
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                        "Initial Catalog = ProvaAgenti;" + "integrated Security=true;";

        public static List<Agente> GetAgenti()
        {
            List<Agente> agenti = new List<Agente>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand
            {
                
                Connection = connection,
                
                CommandType = System.Data.CommandType.Text,
                
                CommandText = "select * from dbo.Agente"
            };
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var matricola = reader[0];
                var nome = reader[1];
                var cognome = reader[2];
                var codiceFiscale = reader[3];
                var areaGeografica = reader[4];
                int annoInizio = (int)reader[5];
               
                
                Agente agente = new Agente((string)nome, (string)cognome, (string)codiceFiscale, (string)areaGeografica, (int)annoInizio);
                agenti.Add(agente);
                Console.WriteLine($"Nome: {nome} -Cognome: {cognome} -Anni di servizio: {2021-annoInizio}");
                Console.WriteLine("");
            }
            connection.Close();
            return agenti;
        }

        public static void GetAgentiPerAnno(int anni)
        {
            {
                SqlConnection connection1 = new SqlConnection(connectionString);
                connection1.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection1;

                command.CommandType = System.Data.CommandType.Text;
                //select * from dbo.Agente where (2021-AnnoInizioAttivita)>25
                command.CommandText = "select * from dbo.Agente where (2021-AnnoInizioAttivita)>@AnniServizio";
                command.Parameters.AddWithValue("@AnniServizio", anni);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var matricola = reader[0];
                    var nome = reader[1];
                    var cognome = reader[2];
                    Console.WriteLine($"Matricola: {matricola} -Nome: {nome} -Cognome: {cognome}");
                }
                connection1.Close();
            }
        }

        public static void GetAgentiPerArea(string area)
        {
            {
                SqlConnection connection1 = new SqlConnection(connectionString);
                connection1.Open();
                SqlCommand command = new SqlCommand();
                
                command.Connection = connection1;
                
                command.CommandType = System.Data.CommandType.Text;
                
                command.CommandText = "select * from dbo.Agente where AreaGeografica=@AreaGeografica";
                command.Parameters.AddWithValue("@AreaGeografica", area);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var matricola = reader[0];
                    var nome = reader[1];
                    var cognome= reader[2];
                    Console.WriteLine($"Matricola: {matricola} -Nome: {nome} -Cognome: {cognome}");
                }
                connection1.Close();
            }
        }

        public static void AggiungiAgente(string nome, string cognome, string codiceFiscale, string a, int annoInizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
               
                command.Connection = connection;
                
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agente values (@Nome, @Cognome, @CodiceFiscale,@AreaGeografica,@AnnoInizioAttivita)";
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Cognome", cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                command.Parameters.AddWithValue("@AreaGeografica", a);
                command.Parameters.AddWithValue("@AnnoInizioAttivita", annoInizio);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
