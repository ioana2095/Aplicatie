using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication.Models;


namespace WebApplication.DTO
{
    public class User
    {

        static string cale = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection myCommand = new SqlConnection(cale);

        public void uniune()
        {
            myCommand.Open();
            string queryStr = "SELECT * FROM Role FULL OUTER JOIN User1 on User1(RoleId)=Role(RoleId) ";
            SqlCommand comend = new SqlCommand(queryStr);
            comend.Connection = myCommand;
            myCommand.Close();
           // comend.ExecuteNonQuery();
        }
  
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
        public string Logare(string UserName, string parola)
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
                    if (reader["UserName"].ToString().Equals(UserName) != false && reader["Parola"].ToString().Equals(parola) != false){
                        if (Convert.ToInt32(reader["RoleId"]) == 1)
                            return "ADMIN";
                        else
                            return "USER";
                     }

                }
                reader.Close();

            }
            catch
            {
                
            }
            return null;
        }
        public List<Vizualizare> Viz()
        {
            List<string> list = new List<string>();
            string comanda = "SELECT * FROM User1";
            List<Vizualizare> lista=new List<Vizualizare>();
            SqlCommand comm = new SqlCommand(comanda, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            int i=0;
            using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Insert(i,new Vizualizare
                                   {
                                       UserId = Convert.ToInt32(reader["UserId"]),
                                       UserName = reader["UserName"].ToString(),
                                       FirstName = reader["FirstName"].ToString(),
                                       LastName = reader["LastName"].ToString(),
                                       Email = reader["Email"].ToString(),
                                       NrTelefon = reader["NrTelefon"].ToString(),
                                       Password = reader["Parola"].ToString()
                                   }); 
                        
                        i++;
                    }
                }

        return lista;
           
        }

        public Editare Editare(Int32 UserId)
        {
            string comanda = "SELECT * FROM User1";
            SqlCommand comm = new SqlCommand(comanda, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["UserId"]) == UserId)
                        return new Editare
                                   {
                                       UserId=Convert.ToInt32(reader["UserId"]),
                                       UserName = reader["UserName"].ToString(),
                                       FirstName = reader["FirstName"].ToString(),
                                       LastName = reader["LastName"].ToString(),
                                       Email = reader["Email"].ToString(),
                                       NrTelefon = reader["NrTelefon"].ToString(),
                                       Password = reader["Parola"].ToString()
                                   };
                }
                return null;
            
        }
        public bool Editare(Int32 UserId, string UserName, string FirstName, string LastName, string Email, string NrTelefon, string parola)
        {
            myCommand.Open();
            SqlCommand comend = myCommand.CreateCommand();
            comend.CommandText = "UPDATE User1 SET UserName = @UsN, FirstName = @fn,LastName=@ln,Email=@em,NrTelefon=@nt,Parola=@pss WHERE UserId=@UserId ";
            comend.Parameters.AddWithValue("@UsN", UserName);
            comend.Parameters.AddWithValue("@fn", FirstName);
            comend.Parameters.AddWithValue("@ln", LastName);
            comend.Parameters.AddWithValue("@em", Email);
            comend.Parameters.AddWithValue("@nt", NrTelefon);
            comend.Parameters.AddWithValue("@pss", parola);
            comend.Parameters.AddWithValue("UserId", Convert.ToInt32(UserId)); 
            comend.Connection = myCommand;
            comend.ExecuteNonQuery();
            if (comend.CommandText != null)
                return true;
            return false;
        }
        public Editare Detalii(Int32 UserId)
        {
            string comanda = "SELECT * FROM User1";
            SqlCommand comm = new SqlCommand(comanda, myCommand);
            myCommand.Open();
            comm.Connection = myCommand;
            SqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["UserId"]) == UserId)
                    return new Editare
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        UserName = reader["UserName"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        NrTelefon = reader["NrTelefon"].ToString(),
                        Password = reader["Parola"].ToString()
                    };
            }
            return null;

        }
        public bool Delete(Int32 UserId)
        {
            myCommand.Open();
            string queryStr = "Delete From User1 where UserId='" + UserId + "'";
            SqlCommand comend = new SqlCommand(queryStr);
            comend.Connection = myCommand;
            comend.ExecuteNonQuery();
            if (queryStr != null)
                return true;
            return false;
        }
    }

}