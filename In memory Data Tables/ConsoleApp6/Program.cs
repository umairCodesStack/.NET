using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
			DataTable dt = new DataTable();
			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("Name", typeof(string));
			DataRow r1 = dt.NewRow();
			r1["ID"] = 5;
			r1["Name"] = "Hassan";
			dt.Rows.Add(r1);
			
			string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDatabase;Integrated Security=True;";
			SqlConnection con = new SqlConnection(conString);
			//string insertQuery = $"Insert into Item(id,Name) values(@i,@n)";
			//SqlCommand insertCmd = new SqlCommand(insertQuery,con);
			SqlDataAdapter adapter = new SqlDataAdapter();
			adapter.InsertCommand = new SqlCommand("INSERT INTO Item (ID, Name) VALUES (@ID, @Name)", con);
			adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
			adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
			adapter.Update(dt);


		}
	}
}
//string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDatabase;Integrated Security=True;";
//SqlConnection con = new SqlConnection(conString);
//string selectQuery = $"Select * from Item";
//SqlCommand SelectCmd = new SqlCommand(selectQuery, con);
//SqlDataAdapter ad = new SqlDataAdapter();
//ad.SelectCommand = SelectCmd;
//ad.Fill(dt);
//foreach (DataRow dr in dt.Rows)
//{
//	Console.WriteLine(dr["ID"]);
//	Console.WriteLine(dr["Name"]);
//}