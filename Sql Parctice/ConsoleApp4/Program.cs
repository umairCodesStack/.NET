using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;


namespace ConsoleApp4
{
    internal class Program
    {
        static void insertPatientItoDB(Patient p) 
        {
            string conecString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test_DB;Integrated Security=True;";
            SqlConnection con=new SqlConnection(conecString);
            try
            {
                con.Open();
                string query = $"insert into Patient(Name,Email,Disease) values('{p.Name}','{p.Email}','{p.Disease}')";
                SqlCommand cmd= new SqlCommand(query,con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                con.Close();
            }
        }
        static void displayPatientsFromDB() 
        {
            string conecString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test_DB;Integrated Security=True;";
            SqlConnection con=new SqlConnection( conecString );
            try 
            {
                con.Open();
                string query = $"Select * from Patient";
                SqlCommand cmd=new SqlCommand(query,con);
                SqlDataReader dr= cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    Console.WriteLine($"Patinet_ID:       {dr.GetValue(0)}  "); 
                    Console.WriteLine($"Patient_Name:     {dr.GetValue(1)}");
                    Console.WriteLine($"Patinet_Email:    {dr.GetValue(2)}");
                    Console.WriteLine($"Patient_Disease:  {dr.GetValue(3)}");
                    Console.WriteLine();
                
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }
            finally 
            {
                con.Close();
            }    
            
        }
        static void Main(string[] args)
        {
            Patient patient = new Patient 
            {
                Name="Fraz",
                Email="Fraz13@gmail.com",
                Disease="SJ_Syndrome"
            };

            //insertPatientItoDB( patient );
            displayPatientsFromDB();

        }
    }
}
