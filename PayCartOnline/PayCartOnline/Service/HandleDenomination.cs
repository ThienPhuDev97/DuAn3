using PayCartOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PayCartOnline.Service
{
    public class HandleDenomination
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DuAn"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DuAn"].ConnectionString);

        private const string GetAllDenomination = "GetAllDenomination";
        private const string InsertDenomination = "InsertDenomination";
        private const string UpdateDenomination = "UpdateDenomination";
        private const string DeleteDenomination = "DeleteDenomination";
        private const string FindDenominationById = "FindDenominationById";

        public List<Denomination> ShowDenomination()
        {
            SqlCommand com = new SqlCommand(GetAllDenomination, con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            List<Denomination> data = new List<Denomination>();
            foreach (DataRow item in ds.Rows)
            {
                Denomination record = new Denomination();
                record.ID = item["ID_Denomination"] != null ? Int32.Parse(item["ID_Denomination"].ToString()) : 0;
                record.Price = item["Price"] != null ? Int32.Parse(item["Price"].ToString()) : 0;
                record.Status = !string.IsNullOrEmpty(item["Status"].ToString()) ? (Int32.Parse(item["Status"].ToString()) == 1 ? "On" : "Off") : "";

                data.Add(record);
            }
            return data;
        }
        public void AddDenominations(int price, int status)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = InsertDenomination;
                command.Parameters.Add(new SqlParameter("@Price", price));
                command.Parameters.Add(new SqlParameter("@Status", status));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UpdateDenominations(int id, int price,int status)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = UpdateDenomination;
                command.Parameters.Add(new SqlParameter("@ID", id));
                command.Parameters.Add(new SqlParameter("@Price", price));
                command.Parameters.Add(new SqlParameter("@Status", status));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteDenominations(int id)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = DeleteDenomination;
                command.Parameters.Add(new SqlParameter("@ID", id));
                
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Denomination FinDenomination(int id)
        {
            SqlCommand com = new SqlCommand(FindDenominationById, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", System.Data.SqlDbType.Int).Value = id == 0 ? DBNull.Value : (object)id;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Denomination record = new Denomination();
            foreach (DataRow item in ds.Rows)
            {
                
                record.ID = item["ID_Denomination"] != null ? Int32.Parse(item["ID_Denomination"].ToString()) : 0;
                record.Price = item["Price"] != null ? Int32.Parse(item["Price"].ToString()) : 0;
                record.Status = !string.IsNullOrEmpty(item["Status"].ToString()) ? (Int32.Parse(item["Status"].ToString()) == 1 ? "On" : "Off") : "";

             
            }
            return record;
        }
    }
}