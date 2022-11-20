using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Security.Cryptography;  // la till nyss
using System.Data;

namespace inlämning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // var Handler = new MySqlHandler();
            Console.WriteLine("hello wörld!");



            //menu menu = new menu();

            MySQLHandler mySQLHandler = new MySQLHandler();
            person p = new person();

            mySQLHandler.UniqueUserAndPW(p,p);
            mySQLHandler.SKANDI();
            mySQLHandler.Norden();
            mySQLHandler.countrys();
            mySQLHandler.Vlandet();
            mySQLHandler.Luser();
            mySQLHandler.begynnelse();

            Console.ReadKey();
         
            


            // för MySQL använd nugger: MySql.Data
            //för SQLite använd uget : Microsoft.Data.Sqllite
            // för SQL-Server använd nuget : Microsoft.Data.SqlClient

            //Hur många olika länder finns representerade 
            //Är alla username och password unika?
            //Hur många är från norden respektive skandinavien?
            //Vilket är det vanligaste landet?
            //Lista de 10 första användarna
            //Visa alla användare vars för och efternamn har samma begynnelsebokstav tex Adem Ademsson

            // kanske ha using före var?

            //öppna kopllingen


            /*
            while (reader.Read())    // för rada upp listan
            {
                Console.WriteLine($"{reader["id"]}: {reader["first_name"]}");

            }
            cnn.Close();

            var dt = new DataTable();
            var adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);
            cnn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["id"]}: {row["first_name"]}");
                }
            }
            */

            //SELECT id From aesqlassignment1 WHERE country = 'sweden';
            //SELECT id From aesqlassignment1 WHERE country = 'denmark';
            //SELECT id From aesqlassignment1 WHERE country = 'norway';
            //SELECT id From aesqlassignment1 WHERE country = 'finland';
            //SELECT id From aesqlassignment1 WHERE country = 'iceland'; // länder från norden

            // SELECT id From aesqlassignment1 WHERE country = 'sweden';
            // SELECT id From aesqlassignment1 WHERE country = 'denmark';
            //SELECT id From aesqlassignment1 WHERE country = 'norway';  // kod för personer i skandinavium

            // SELECT DISTINCT country FROM `adems`.`aesqlassignment1`;   //  länder kod



            // Select password From aesqlassignment1; sen en ifsats för jämföra lösen?




        }
}
}
