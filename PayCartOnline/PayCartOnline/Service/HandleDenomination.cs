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

                data.Add(record);
            }
            return data;
        }
        public void AddDenominations(Denomination denomination)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = InsertDenomination;
                command.Parameters.Add(new SqlParameter("@Price", denomination.Price));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UpdateDenominations(Denomination denomination, int? id)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = UpdateDenomination;
                command.Parameters.Add(new SqlParameter("@ID", denomination.ID));
                command.Parameters.Add(new SqlParameter("@Price", denomination.Price));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteDenominations(Denomination denomination, int? id)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = DeleteDenomination;
                command.Parameters.Add(new SqlParameter("@ID", denomination.ID));
                command.Parameters.Add(new SqlParameter("@Price", denomination.Price));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}