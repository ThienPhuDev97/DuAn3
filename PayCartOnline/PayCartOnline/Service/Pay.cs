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
    public class Pay
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DuAn"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DuAn"].ConnectionString);
        private const string InsertOrder = "InsertOrder";
        public void AddOrder(VnPayResponse vnPayResponse, CheckUser user, InforOrder order)
        {
            var connection = new SqlConnection(connectionString);
            string mobile = order.phone.ToString();
            DateTime date = DateTime.Parse(vnPayResponse.vnp_PayDate.ToString());
            try
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = InsertOrder;

                command.Parameters.Add(new SqlParameter("@USER_ID", user.ID_User));
                command.Parameters.Add(new SqlParameter("@TYPEPAY",1));
                command.Parameters.Add(new SqlParameter("@CARDTYPE", order.CardType));
                command.Parameters.Add(new SqlParameter("@DENOMINATION_ID", order.denomination));
                command.Parameters.Add(new SqlParameter("@PHONE", mobile));
                command.Parameters.Add(new SqlParameter("@BRAND", order.network));
                command.Parameters.Add(new SqlParameter("@QUANTITY", 1));
                command.Parameters.Add(new SqlParameter("@TOTAL",vnPayResponse.vnp_Amount));
                command.Parameters.Add(new SqlParameter("@DISCOUNT",1));
                command.Parameters.Add(new SqlParameter("@STATUS","Pending"));
                command.Parameters.Add(new SqlParameter("@BANKCODE",vnPayResponse.vnp_BankCode));
                command.Parameters.Add(new SqlParameter("@CREATED_AT",date));
                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception e)
            {
                //fix not ho em nhe , dang bi loi convert datetime nua thoi may th kia em fix het rôi
                Console.WriteLine(e.Message);
            }
        }
    }
}