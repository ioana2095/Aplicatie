using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication.DTO
{
    public class User
    {

        static string cale = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection myCommand = new SqlConnection(cale);
  
        public bool Introducere(string UserName, string FirstName, string LastName, string Email, string NrTelefon, string parola)
        {
           
            myCommand.Open();
            string queryStr = "Insert into User1(UserName,FirstName,LastName,Email,NrTelefon,[Parola]) values ('" 
            + UserName + "','" + FirstName + "','" + LastName + "','" + Email + "','" + NrTelefon + "','" + parola + "')";
            SqlCommand comend = new SqlCommand(queryStr);
            comend.Connection = myCommand;
            comend.ExecuteNonQuery();
            if (queryStr != null)
                return true;
            return false;
           
        }
        public bool Logare(string UserName, string parola)
        {
            string comanda = "SELECT * FROM User1";
            SqlCommand comm = new SqlCommand(comanda,myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
            try
            {
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["UserName"].ToString().Equals(UserName) != false && reader["Parola"].ToString().Equals(parola) != false)
                        return true;

                }
                reader.Close();

            }
            catch
            {
                
            }
            return false;
        }
        public bool LogAdmin(string UserName, string parola)
        {
            if (UserName.Equals("Administrator") != false && parola.Equals("12FG89tr") != false)
                return true;
            return false;
        }
        public List<string> Viz()
        {
            List<string> list = new List<string>();
            string comanda = "SELECT * FROM User1";
            SqlCommand comm = new SqlCommand(comanda, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader = comm.ExecuteReader(); ;
            DataTable schemaTable = reader.GetSchemaTable();
            int i=0;
            foreach (DataRow row in schemaTable.Rows)
            {
                string s = row.ToString();
                list.Insert(i, s);
                i++;
            }
            return list;

        }
        
    }

}