using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Net.Http.Headers;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // DATABASE
            Product product1 = new Product
            {
                ID = 1,
                Name = "PC",
                Description = "des"

            };
            string sqlConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDatabase;Integrated Security=True";
            SqlConnection conn= new SqlConnection(sqlConnectionString);
                                 //Writing//                  
            Console.Write("Enter The iD");
            string ID=Console.ReadLine();
            Console.Write("Enter the Name");  
            string Name=Console.ReadLine();
            Console.Write("Enter The Description");
            string Description=Console.ReadLine();
            string querey = "Insert into Products(ProductID,ProductName,)";
       
            
                            //Reading//
            //string querey = "Select * from Product";
            //SqlCommand sqlCmd = new SqlCommand(querey, conn);
            //conn.Open();
            //SqlDataReader reader = sqlCmd.ExecuteReader();
            //while (reader.Read()) 
            //{
            //    Console.WriteLine(reader.GetInt32(0));
            //    Console.WriteLine(reader.GetString(1));
            //    Console.WriteLine(reader.GetString(2));
            //}
                       //Readig//
            //Product product1 = new();
            //object Intializer syntax
             Product p=new Product { ID = 1 ,Description="some des"};

            Product product=new Product();
            product.ID= 1;
            product.Name= "Computer";
            product.Description = "Inter Core i5";
            product.catagorey.Id= 1;
            product.catagorey.Name = "PC";
           
            StreamWriter writer = new StreamWriter("file.txt",append:true);
            String jsonProduct=JsonSerializer.Serialize(product);

            StreamReader read = new StreamReader("file.txt");
            string data=read.ReadLine();
            Product product2=JsonSerializer.Deserialize<Product>(data);


        }
    }
}
