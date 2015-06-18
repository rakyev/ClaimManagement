using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class DataAccess
    {
        public DataAccess() { }

        public static DataSet SelectRecipeFilterData()
        {
            SqlConnection conn = new SqlConnection("server=mysever;data source=MYDB; integrateed security=SMTP");
            SqlCommand cmd = new SqlCommand("SelectMyData", conn);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;

        }

        public static int InsertStuff(string firstName, string lastName, DateTime BirthDate)
        {
            SqlConnection conn = new SqlConnection("server=mysever;data source=MYDB; integrateed security=SMTP");

            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertPerson", conn);
                cmd.Parameters.Add("@firstName", SqlDbType.Text).Value = firstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;

                int personID = (int)cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("UpdateBirthDate", conn);
                cmd2.Parameters.Add("@birthDate", SqlDbType.DateTime);
                cmd2.Parameters.Add("@userID", SqlDbType.Int, personID);
                cmd.BeginExecuteNonQuery();

                return personID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }

}