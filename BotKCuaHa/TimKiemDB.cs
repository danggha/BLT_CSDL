using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotKCuaHa
{
    public class TimKiemDB
    {
        string ketnoi = @"Data Source=DESKTOP-T80TUOI\SQLEXPRESS;Initial Catalog=BAITAPLON_CSDL;Integrated Security=True";
        public string timSV(string v)
        {
            string query = "TimKiemSinhVien";
            SqlConnection con = new SqlConnection(ketnoi);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@tenSV", System.Data.SqlDbType.NVarChar, 50).Value = v;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string kq = (string) cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
    }
}
