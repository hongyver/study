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

		string name = "Cooper1";
		DateTime birth = new DateTime(1991,2,7);
		string email = "Copper1@hotmail.com";
		int family = 5;

		string constr = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

		using(SqlConnection sqlcon = new SqlConnection())
		{
			sqlcon.ConnectionString = constr;
			sqlcon.Open();

			SqlCommand cmd = new SqlCommand();
			
			cmd.Connection = sqlcon;
			//string cmdstr = string.Format("insert into MemberInfo(Name, Birth, Email, Family) values ('{0}', '{1}', '{2}', '{3}')",	name, birth.ToShortDateString(), email, family);
			//cmd.CommandText = cmdstr;
			// 매개변수화된 쿼리

			SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar,20);
			paramName.Value = name;

			SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
			paramBirth.Value = birth;

			SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
			paramEmail.Value = email;

			SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
			paramFamily.Value = family;

			cmd.Parameters.Add(paramName);
			cmd.Parameters.Add(paramBirth);
			cmd.Parameters.Add(paramEmail);
			cmd.Parameters.Add(paramFamily);

			cmd.CommandText = "insert into MemberInfo(Name, Birth, Email, Family) values (@Name, @Birth, @Email, @Family)";

			cmd.ExecuteNonQuery();

			sqlcon.Close();

		}
	}
};