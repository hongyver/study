using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(DateTime.Now);

		string ConnectionString =
			ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

		using(SqlConnection sqlcon = new SqlConnection())
		{
			sqlcon.ConnectionString = ConnectionString;
			sqlcon.Open();

			DataColumn nameCol = new DataColumn("Name", typeof(string));
			DataColumn birthCol = new DataColumn("Birth", typeof(DateTime));
			DataColumn emailCol = new DataColumn("Email", typeof(string));
			DataColumn familyCol = new DataColumn("Family", typeof(byte));

			DataTable table = new DataTable("MemberInfo1");

			table.Columns.Add(nameCol);
			table.Columns.Add(birthCol);
			table.Columns.Add(emailCol);
			table.Columns.Add(familyCol);

			table.Rows.Add("Anderson", new DateTime(1950, 5, 20), "anderson@mail.com", 2);
			table.Rows.Add("Jason", new DateTime(1967, 12, 3), "jason@mail.com", 0);
			table.Rows.Add("Mark", new DateTime(1998, 3, 2), "anderson@mail.com", 1);
			table.Rows.Add("Jenniffer", new DateTime(1985, 5, 6), "jennifer@mail.com", 0);

			DataRow[] members = table.Select("Family >= 1");
			foreach( DataRow row in members)
			{
				Console.WriteLine("{0} {1} {2} {3}", row["Name"], row["Birth"], row["Email"], row["Family"]);
			}
			table.Rows[3]["Name"] = "Jenny";
			table.Rows.Remove(table.Rows[3]);

			DataSet ds = new DataSet();
			ds.Tables.Add(table);

			sqlcon.Close();
		}
	}
};