using Microsoft.Data.SqlClient;
using System.Data;

namespace RKTechnologyTask.SQlConnect
{
    public class Connection
    {
        public static string Connectionstring = "Data Source=DESKTOP-8R556FM;Initial Catalog=DbRKTechnology;User Id=sa; Password=Game@123;TrustServerCertificate=True;";

        public SqlConnection Connect()
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection(Connectionstring);
                SqlConn.Close();
                SqlConn.Open();
                return SqlConn;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
           
        }
        public DataTable FillQry(string Qry)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Qry, Connect());
            da.Fill(dt);
            return dt;
        }
    }
}
