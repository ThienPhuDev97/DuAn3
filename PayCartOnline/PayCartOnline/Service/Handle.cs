using PayCartOnline.Models;
using PayCartOnline.Models.VNPAY;
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
        private const string GetAllAccount = "GetAllAccount";
        private const string GetAccById = "GetAccById";
        private const string CheckPhone = "CheckPhone";
        private const string AllRole = "AllRole";
        private const string UpdateAccount = "UpdateAccount";
        private const string InsertAcc = "Test";
        private const string Register = "Register";
        private const string InsertOrder = "InsertOrder";




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
                record.ID = item["ID_Denomination"] != null ? Int32.Parse(item["ID_Denomination"].ToString()) : 0;
                record.Price = item["Price"] != null ? Int32.Parse(item["Price"].ToString()) : 0;
               
                data.Add(record);
            }

            return data;

        }

        /// <summary>
        /// check user access
        /// </summary>
        /// <returns> string name role</returns>
        public CheckUser CheckUserLogin(string phone,string pwd)
        {
            SqlCommand com = new SqlCommand(CheckUser, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@Phone", phone));
            com.Parameters.Add(new SqlParameter("@Pass", pwd));
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            
            CheckUser user = new CheckUser();
            foreach (DataRow item in ds.Rows)
            {

                user.Phone = string.IsNullOrEmpty(item["Phone"].ToString()) ? null : item["Phone"].ToString();
                user.Role = string.IsNullOrEmpty(item["Name"].ToString()) ? null : item["Name"].ToString();
                user.UserName = string.IsNullOrEmpty(item["UserName"].ToString()) ? null : item["UserName"].ToString();
            }

            return user;

        }

        public List<CheckUser> GetAllAcount()
        {
            SqlCommand com = new SqlCommand(GetAllAccount, con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            List<CheckUser> data = new List<CheckUser>();
            foreach (DataRow item in ds.Rows)
            {
                CheckUser record = new CheckUser();
                record.Phone = string.IsNullOrEmpty(item["Phone"].ToString()) ? null : item["Phone"].ToString();
                record.Role = string.IsNullOrEmpty(item["Name"].ToString()) ? null : item["Name"].ToString();
                record.UserName = string.IsNullOrEmpty(item["UserName"].ToString()) ? null : item["UserName"].ToString();
                record.Pwd = string.IsNullOrEmpty(item["Password"].ToString()) ? null : item["Password"].ToString();
                record.ID_User = item["ID"].ToString() == null ? 0 : Int32.Parse(item["ID"].ToString());
                record.Status = string.IsNullOrEmpty(item["Status"].ToString()) ? null : item["Status"].ToString();
                data.Add(record);
            }

            return data;

        }

        public CheckUser FindAccByID(int id)
        {
            SqlCommand com = new SqlCommand(GetAccById, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID_User", id));
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DataRow dr = ds.NewRow();
            if (ds.Rows.Count > 0)
                dr = ds.Rows[0];
            
                CheckUser record = new CheckUser();
                record.Phone = string.IsNullOrEmpty(dr["Phone"].ToString()) ? null : dr["Phone"].ToString();
                record.Role = string.IsNullOrEmpty(dr["Name"].ToString()) ? null : dr["Name"].ToString();
                record.UserName = string.IsNullOrEmpty(dr["UserName"].ToString()) ? null : dr["UserName"].ToString();
                record.Pwd = string.IsNullOrEmpty(dr["Password"].ToString()) ? null : dr["Password"].ToString();
                record.ID_User = dr["ID"].ToString() == null ? 0 : Int32.Parse(dr["ID"].ToString());
                record.Status = string.IsNullOrEmpty(dr["Status"].ToString()) ? null : dr["Status"].ToString();
                
            

            return record;

        }

        public List<string> ListPhone()
        {
            SqlCommand com = new SqlCommand(GetAllAccount, con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            List<string> data = new List<string>();
            foreach (DataRow item in ds.Rows)
            {
                CheckUser record = new CheckUser();
                data.Add(item["Phone"].ToString() == null ? null : item["Phone"].ToString());
                
                
            }
            return data;

        }

        public List<Roles> ListRole()
        {
            SqlCommand com = new SqlCommand(AllRole, con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);
            List<Roles> data = new List<Roles>();
            foreach (DataRow item in ds.Rows)
            {
                Roles record = new Roles();
                record.ID=(item["ID_Role"].ToString() == null ? 0 : Int32.Parse(item["ID_Role"].ToString()));
                record.Name = (item["Name"].ToString() == null ? null : item["Name"].ToString());
                data.Add(record);
            }
            return data;

        }

        public void UpdateUser(CheckUser user)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = UpdateAccount;
                command.Parameters.Add(new SqlParameter("@ID_user", user.ID_User));
                command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                command.Parameters.Add(new SqlParameter("@Pass", user.Pwd));
                command.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                command.Parameters.Add(new SqlParameter("@Status", user.Status));
                command.Parameters.Add(new SqlParameter("@Role", user.Role));
                int ID = command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddAcc(CheckUser user)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = InsertAcc;
                
                command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                command.Parameters.Add(new SqlParameter("@Pass", user.Pwd));
                command.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                command.Parameters.Add(new SqlParameter("@Status", user.Status));
                command.Parameters.Add(new SqlParameter("@Role_Id", user.Role));
                command.Parameters.Add(new SqlParameter("@Create_At", user.Create_At));
                int ID = command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddOrder(VnPayResponse vnPayResponse )
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = InsertOrder;

                //command.Parameters.Add(new SqlParameter("@USER_ID", vnPayResponse.));
                //command.Parameters.Add(new SqlParameter("@TypePay", vnPayResponse.ty));
                //command.Parameters.Add(new SqlParameter("@Denomination_ID", menhgia));
                //command.Parameters.Add(new SqlParameter("@Status", user.Status));
                //command.Parameters.Add(new SqlParameter("@Role_Id", user.Role));
                //command.Parameters.Add(new SqlParameter("@Create_At", user.Create_At));
                int ID = command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RegisterAcc(string phone,string pwd,DateTime date)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Register;

                command.Parameters.Add(new SqlParameter("@Phone", phone));
                command.Parameters.Add(new SqlParameter("@Pass", pwd));
                command.Parameters.Add(new SqlParameter("@Create_At", date));
                int ID = command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}