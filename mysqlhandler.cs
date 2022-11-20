using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace inlämning
{
    internal class MySQLHandler // kanske internal
    {

        //MySqlConnection cnn = new MySqlConnection(connectionString);
        //cnn = new MySqlConnection(connectionString);
        //cnn.Open();
        //string sql = "SELECT*From aesqlassignment1"; // bara kopierade marcuuuz
        //var cmd = new MySqlCommand(sql, cnn); // skall man ha "using" före var? 
        //var reader = cmd.ExecuteReader();

        //Är alla username och password unika?
        
        //Vilket är det vanligaste landet?
        //Lista de 10 första användarna på bokstaven L
        //Visa alla användare vars för och efternamn har samma begynnelsebokstav tex Adem Ademsson

        private string GetConnectionString()
        {
            string server = "localhost";
            string user = "root";
            string password = "soldaten45";
            string database = "adems";

            string connectionString = $"server={server};database={database};uid={user};pwd={password};";
            return connectionString;

        }

        public List<person> UniqueUserAndPW(person username, person password)   // ta bort "List<person>" och ersätt med void??
        {

            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT(username)), COUNT(DISTINCT(password)) FROM aesqlassignment1", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("The number of unique usernames is: " + reader.GetString("COUNT(DISTINCT(username))") + "\nThe number of unique passwords is: " + reader.GetString("COUNT(DISTINCT(password))") + ".");
            }
            return null;
           
            conn.Close();
        }

        //Hur många är från norden respektive skandinavien?

        public void SKANDI() // tog bort list<person>
        {
            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id) FROM aesqlassignment1 WHERE country IN('Sweden', 'Norway', 'Denmark')", conn); 
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("The number of people from scaninavia is:" + reader.GetString("COUNT(id)") + ".");
            }
          
            
            conn.Close();
            
        }


        public void Norden()
        {

            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id) FROM aesqlassignment1 WHERE country IN('Sweden', 'Norway', 'Denmark', 'Finland', 'Iceland')", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("The number of people from Nordic countrys : " + reader.GetString("COUNT(id)") + ".");
            }

            
            conn.Close();
        }


        //Hur många olika länder finns representerade 

        public void countrys()  
        {
            
            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            //                             kanske ha "count" mellan select och distcint? 
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT(country)) FROM aesqlassignment1", conn); 
           
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())    
            {
                Console.WriteLine("Number of countries are : " + reader.GetInt32("COUNT(DISTINCT(country))") + ".");

            }
            
             
           
            conn.Close();
        }


        //Vilket är det vanligaste landet?

        public void Vlandet()
        {

            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();


            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(country), country FROM aesqlassignment1 WHERE country = (SELECT MAX(country) FROM aesqlassignment1)", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())    // för rada upp listan
            {
                Console.WriteLine("Most common country is : " + reader.GetString("country") + ", which occurs " + reader.GetInt32("COUNT(country)") + " times.");

            }



            conn.Close();

        }


        //Lista de 10 första användarna på bokstaven L

        public void Luser()
        {

            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM aesqlassignment1 WHERE last_name LIKE 'L%' LIMIT 10", conn); // osäker om de e rätt
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())    
            {
                Console.WriteLine(reader.GetString("first_name") + " " + reader.GetString("last_name"));

            }


        }


        //Visa alla användare vars för och efternamn har samma begynnelsebokstav tex Adem Ademsson
        public void begynnelse()
        {

            var connectionString = GetConnectionString();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM aesqlassignment1 WHERE LEFT(first_name,1 ) = LEFT (last_name,1);", conn); // bör va rätt
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write("People who Firstname and Lastname starts with same letter: ");
                Console.WriteLine(reader.GetString("first_name") + " " + reader.GetString("last_name"));

            }


           
        }



        // string connString = "";


        MySqlConnection cnn = null; // tog  bort raden under..

       /* public void MySQLHandler(string connString)
        {
            cnn = new MySqlConnection(connString);
            cnn.Open();
        }*/

        public void ExecuteSQL(string sql)
        {
            //using kanske skall vara innan car cmd..
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }


        public DataTable Query(string sql)
        {
            var dt = new DataTable();

            var adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);
            return dt;

        }

        public void CreateTable(string connectionString)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);   
        }




        public void Close()
        {
            cnn.Close();
        }

        
    }
}
