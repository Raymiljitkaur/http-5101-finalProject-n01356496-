using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Diagnostics;
namespace HTTP_FINAL_PROJECT
{
    // HERE WE ARE FORMING A CONNECTION WITH THE DATABASE .
    public class PLANETSDB
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "planetsdb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString is something that we use to connect to a database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

           
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

           
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
             
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                
                MySqlDataReader resultset = cmd.ExecuteReader();


                
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
        // HERE IS THE FUNCTIONALITY TO ADD PLANET INTO THE DATABASE .
        public void Addplanet(planet new_planet)
        {
            

            string query = "insert into planets (planets_title,planets_body) values ('{0}','{1}')";
            query = String.Format(query, new_planet.GetPtitle(), new_planet.GetPbody());

            
            

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add planet Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        //HERE IS THE FUNCTIONALITY TO FIND A PLANET FROM THE DATABASE
        public planet Findplanet(int id)
        {
            Debug.WriteLine("method started");
            
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            
            planet result_planet = new planet();

           
            try
            {
               
                string query = "select * from planets where planets_id = " + id;
                Debug.WriteLine("Connection Initialized...");
               
                Connect.Open();
               
                MySqlCommand cmd = new MySqlCommand(query, Connect);
               
                MySqlDataReader resultset = cmd.ExecuteReader();

               
                List<planet> planets = new List<planet>();

               
                while (resultset.Read())
                {
                    
                    planet currentplanet = new planet();

                    
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        
                        switch (key)
                        {
                           
                            case "planets_title":
                                currentplanet.SetPtitle(value);
                                break;
                            case "planets_body":
                                currentplanet.SetPbody(value);
                                break;
                           
                        }

                    }
                    
                    planets.Add(currentplanet);
                }

                result_planet = planets[0]; 

            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Something went wrong in the find planet method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_planet;
        }
        // HERE WE ARE ADDING FUNCTONALITY TO DELLETE THE ENTERIES FROM DATABASE WHENEVER NEEDED.
        public void Delete_planet(int planetid)
        {
            
            string removeplanets = "delete from planets where planets_id = {0}";
            removeplanets = String.Format(removeplanets, planetid);



            MySqlConnection Connect = new MySqlConnection(ConnectionString);
           
            MySqlCommand cmd_removeplanets = new MySqlCommand(removeplanets, Connect);

            try
            {
               
                Connect.Open();
                
                cmd_removeplanets.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removeplanets);

            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Something went wrong in the delete planet Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        // THIS IS TO UPDATE NEW ENTERIES INTO THE DATABASE.
        public void Updateplanet(int planetid, planet new_planet)
        {
            
            string query = "update planets set planets_title='{0}', planets_body='{1}' where planets_id='{2}'";
            query = String.Format(query, new_planet.GetPtitle(), new_planet.GetPbody(),  planetid);
            

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
               
                Debug.WriteLine("Something went wrong in the Updateplanet Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

    }


}