using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace DAL
{
	public class ClientDAL
	{


		public static List<Client> GetAll()
		{
			DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
			string Sql = "Select * from T_Client"; // הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת הנתונים
			List<Client> LstClient = new List<Client>();

			for (int i = 0; i < Dt.Rows.Count; i++)
			{
				Client Cl = new Client()
				{
					ClientID = int.Parse(Dt.Rows[i]["ClientID"].ToString()),
					ClientName = Dt.Rows[i]["ClientName"].ToString(),
					ClientLastname = Dt.Rows[i]["ClientLastname"].ToString(),
					Address = Dt.Rows[i]["Address"].ToString(),
					CityCode = Dt.Rows[i]["CityCode"].ToString(),
					ClientPhone = Dt.Rows[i]["ClientPhone"].ToString(),
					ClientMail = Dt.Rows[i]["ClientMail"].ToString(),
					ClientPassword = Dt.Rows[i]["ClientPassword"].ToString(),
					Picname = Dt.Rows[i]["Picname"].ToString(),
					Status = int.Parse(Dt.Rows[i]["Status"].ToString()),
					AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString())
				};

				LstClient.Add(Cl);
			}

			Db.Close();
			return LstClient;
		}

		public static Client GetById(int Id)
		{
			DbContext Db = new DbContext(); // יצירת אובייקט מסוג גישה לבסיס הנתונים
			string Sql = $"Select * from T_Client where ClientID={Id}"; // הגדרת משפט השאילתה
			DataTable Dt = Db.Execute(Sql); // הפעלת השאילתה וקבלת התוצאות לתוך טבלת הנתונים
			Client Tmp = null;

			if (Dt.Rows.Count > 0)
			{
				Tmp = new Client()
				{
					ClientID = int.Parse(Dt.Rows[0]["ClientID"].ToString()),
					ClientName = Dt.Rows[0]["ClientName"].ToString(),
					ClientLastname = Dt.Rows[0]["ClientLastname"].ToString(),
					Address = Dt.Rows[0]["Address"].ToString(),
					CityCode = Dt.Rows[0]["CityCode"].ToString(),
					ClientPhone = Dt.Rows[0]["ClientPhone"].ToString(),
					ClientMail = Dt.Rows[0]["ClientMail"].ToString(),
					ClientPassword = Dt.Rows[0]["ClientPassword"].ToString(),
					Picname = Dt.Rows[0]["Picname"].ToString(),
					Status = int.Parse(Dt.Rows[0]["Status"].ToString()),
					AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString())
				};
			}

			Db.Close();
			return Tmp;
		}

		public static void Save(Client client)
		{
			DbContext Db = new DbContext();
			string Sql;

			if (client.ClientID < 0)
			{
				Sql = $"INSERT INTO T_Client (ClientName, ClientLastname, Address, CityCode, ClientPhone, ClientMail, ClientPassword, Picname, Status) " +
		        $"VALUES (N'{client.ClientName}', N'{client.ClientLastname}', N'{client.Address}', N'{client.CityCode}', N'{client.ClientPhone}', N'{client.ClientMail}', N'{client.ClientPassword}', N'{client.Picname}', {client.Status})";

			}
			else
			{
				// עדכון לקוח
				Sql = $"UPDATE T_Client SET " +
					  $"ClientName = N'{client.ClientName}', " +
					  $"ClientLastname = N'{client.ClientLastname}', " +
					  $"Address = N'{client.Address}', " +
					  $"CityCode = N'{client.CityCode}', " +
					  $"ClientPhone = N'{client.ClientPhone}', " +
					  $"ClientMail = N'{client.ClientMail}', " +
					  $"ClientPassword = N'{client.ClientPassword}', " +
					  $"Picname = N'{client.Picname}', " +
					  $"Status = {client.Status} " +
					  $"WHERE ClientID = {client.ClientID}";
			}

			Db.Execute(Sql); // ביצוע השאילתה על בסיס הנתונים
			Db.Close(); // סגירת הגישה לבסיס הנתונים
		}

	}
}