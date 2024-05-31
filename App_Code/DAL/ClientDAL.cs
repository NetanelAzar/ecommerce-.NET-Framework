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
					ClientID = int.Parse(Dt.Rows[i]["ClientID"] + ""),
					ClientName = Dt.Rows[i]["ClientName"] + "",
					ClientLastname = Dt.Rows[i]["ClientLastname"] + "",
					Address = Dt.Rows[i]["Address"] + "",
					CityCode = Dt.Rows[i]["CityCode"] + "",
					ClientPhone = Dt.Rows[i]["ClientPhone"] + "",
					ClientMail = Dt.Rows[i]["ClientMail"] + "",
					ClientPassword = Dt.Rows[i]["ClientPassword"] + "",
					Status = int.Parse(Dt.Rows[i]["Status"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"] + "")
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
					ClientID = int.Parse(Dt.Rows[0]["ClientID"] + ""),
					ClientName = Dt.Rows[0]["ClientName"] + "",
					ClientLastname = Dt.Rows[0]["ClientLastname"] + "",
					Address = Dt.Rows[0]["Address"] + "",
					CityCode = Dt.Rows[0]["CityCode"] + "",
					ClientPhone = Dt.Rows[0]["ClientPhone"] + "",
					ClientMail = Dt.Rows[0]["ClientMail"] + "",
					ClientPassword = Dt.Rows[0]["ClientPassword"] + "",
					Status = int.Parse(Dt.Rows[0]["Status"] + ""),
					AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"] + "")
				};
			}

			Db.Close();
			return Tmp;
		}

		public static void Save(Client client)
		{
			DbContext Db = new DbContext();
			string Sql;

			if (client.ClientID == 0)
			{
				// INSERT לקוח חדש
				Sql = $"INSERT INTO T_Client (ClientName, ClientLastname, Address, CityCode, ClientPhone, ClientMail, ClientPassword, Status) " +
					  $"VALUES ('{client.ClientName}', '{client.ClientLastname}', '{client.Address}', '{client.CityCode}', '{client.ClientPhone}', '{client.ClientMail}', '{client.ClientPassword}', {client.Status})";
			}
			else
			{
				// עדכון לקוח
				Sql = $"UPDATE T_Client SET " +
					  $"ClientName = '{client.ClientName}', " +
					  $"ClientLastname = '{client.ClientLastname}', " +
					  $"Address = '{client.Address}', " +
					  $"CityCode = '{client.CityCode}', " +
					  $"ClientPhone = '{client.ClientPhone}', " +
					  $"ClientMail = '{client.ClientMail}', " +
					  $"ClientPassword = '{client.ClientPassword}', " +
					  $"Status = {client.Status}, " +
					  $"WHERE ClientID = {client.ClientID}";
			}

			Db.Execute(Sql); // ביצוע השאילתה על בסיס הנתונים
			Db.Close(); // סגירת הגישה לבסיס הנתונים
		}

	}
}