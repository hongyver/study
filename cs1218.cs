using System;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(DateTime.Now);

		string ConnectionString =
			ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
		//@"Data Source =.\SQLEXPRESS; Initial Catalog=TestDB;User ID=sa;Password=asdf12!@";
		//@"Data Source =.\SQLEXPRESS; Initial Catalog=TestDB;Persist Security Info=True;";

		using(SqlConnection SqlCon = new SqlConnection())
		{
			SqlCon.ConnectionString = ConnectionString;
			SqlCon.Open();

//			SqlCommand cmd = new SqlCommand();
//			cmd.Connection = SqlCon;
//			cmd.CommandText = "insert into MemberInfo(Name, Birth, Email, Family) values ('Fox', '1970-01-25', 'fox@gmail.com', 5)";
//			int affectedCount = cmd.ExecuteNonQuery();
//
//			Console.WriteLine(affectedCount);
			
			int count;

			count = MSSQL_select(SqlCon);
			Console.WriteLine(count);
			//

			count = MSSQL_select2(SqlCon);
			Console.WriteLine(count);


			SqlCon.Close();
		}
		
	}

	static int MSSQL_select(SqlConnection sqlcon)
	{
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = sqlcon;
		cmd.CommandText = "select * from MemberInfo";
		object obj = cmd.ExecuteScalar();

		//int count = (int) obj;

		return 0;

	}

	static int MSSQL_select2(SqlConnection sqlcon)
	{
		int count = 0;
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = sqlcon;
		cmd.CommandText = "select * from MemberInfo";
		
		SqlDataReader rdb = cmd.ExecuteReader();
		while(rdb.Read())
		{				string name = rdb.GetString(0);
			DateTime birth = rdb.GetDateTime(1);
			string email = rdb.GetString(2);
			byte family = rdb.GetByte(3);
			Console.WriteLine("{0} {1} {2} {3}", name, birth, email, family);

			count++;
		}

		return count;
	}
};