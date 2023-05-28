using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BLT_CSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String chuoiketnoi = @"Data Source=DESKTOP-T80TUOI\SQLEXPRESS;Initial Catalog=BAITAPLON_CSDL;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulie;
     


        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            
        }
        public void hienthi()
        {

            ketnoi.Open();
            sql = @"Select mssv, hoten, gioitinh, sdt, diachi from SINH_VIEN";
            thuchien=new SqlCommand(sql, ketnoi);
            docdulie = thuchien.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(docdulie);
            dataGridView1.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void themsinhvien()

        {
            ketnoi.Open();
            string mssv = textBox1.Text;
            string hoten = textBox2.Text;
            string gioitinh = txt_gioitinh.Text;
            string diachi = txt_diachi.Text;
            string sdt = txt_sdt.Text;

            string sql1 = @"insert into SINH_VIEN values ('" + mssv + "' , N'" + hoten + "' , N'" + gioitinh + "' , " + sdt + "  ,  N'" + diachi + "')";
            MessageBox.Show(sql1);
            MessageBox.Show("THÊM THÀNH CÔNG!!");
            
            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();

            txtmssv.Text =  null;
            txthoten.Text = null;
            txt_gioitinh = null;
            txt_diachi = null;
            txt_sdt = null;

            ketnoi.Close();
        }


            



        private void button3_Click(object sender, EventArgs e)
        {
            themsinhvien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
