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
    public class Handle
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DuAn"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DuAn"].ConnectionString);

        private const string GetAllDenomination = "GetAllDenomination";
        private const string CheckUser = "CheckUser";

        /// <summary>
        /// get data all table denomination
        /// </summary>
        /// <returns></returns>

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
                record.ID = item["ID"] != null ? Int32.Parse(item["ID"].ToString()) : 0;
                record.Price = item["Price"] != null ? Int32.Parse(item["Price"].ToString()) : 0;
               
                data.Add(record);
            }

            return data;

        }

        /// <summary>
        /// check user access
        /// </summary>
        /// <returns> string name role</returns>
        public string CheckUserLogin(string phone)
        {
            SqlCommand com = new SqlCommand(CheckUser, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@Phone", phone));
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            string isCheck = "";
            foreach (DataRow item in ds.Rows)
            {


                isCheck = string.IsNullOrEmpty(item["Name"].ToString()) ? isCheck : item["Name"].ToString();

            }

            return isCheck;

        }
    }
}