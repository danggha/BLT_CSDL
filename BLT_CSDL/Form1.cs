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
        DataTable dt;
        string masv;





        public void hienthi()
        {

            ketnoi.Open();
            sql = @"Select mssv, hoten, gioitinh, sdt, diachi from SINH_VIEN";
            thuchien=new SqlCommand(sql, ketnoi);
            docdulie = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulie);
           
        }
        public void hienthi2()
        {

            ketnoi.Open();
            sql = @"Select maphong, sophong, loaiphong, toanha from PHONG";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulie = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulie);

        }
        public void hienthi3()
        {

            ketnoi.Open();
            sql = @"Select makhoa, tenkhoa from KHOA";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulie = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulie);

        }
        public void hienthi4()
        {

            ketnoi.Open();
            sql = @"Select malop, tenlop from LOP";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulie = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulie);

        }



        public void xoa()
        {
            text_mssv.Clear();
            text_hotensv.Clear();
            text_gtsv.Clear();
            text_dcsv.Clear();
            text_sdtsv.Clear();

        }
        public void xoa2()
        {
            txt_maphong.Clear();
           txt_sophong.Clear();
           txt_loaiphong.Clear();
            txt_toanha.Clear();
           

        }
        private void themsinhvien()

        {
            ketnoi.Open();
            string mssv = text_mssv.Text;
            string hoten = text_hotensv.Text;
            string gioitinh = text_gtsv.Text;
            string diachi = text_dcsv.Text;
            string sdt = text_sdtsv.Text;

            string sql1 = @"insert into SINH_VIEN values ('" + mssv + "' , N'" + hoten + "' , N'" + gioitinh + "' , " + sdt + "  ,  N'" + diachi + "')";
            MessageBox.Show(sql1);
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();
        }


        private void cmd_view_Click(object sender, EventArgs e)
        {
            hienthi();
            dataGridView1.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hienthi2();
            dataGridView2.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void cmd_xoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string sql1 = @"DELETE FROM SINH_VIEN
            WHERE mssv = '"+ masv + "'";

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();


            hienthi();
            dataGridView1.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                masv = Convert.ToString(row.Cells["mssv"].Value);
                MessageBox.Show(masv);
                
            
        }

        private void cmd_thên_Click(object sender, EventArgs e)
        {
            themsinhvien();
        }

        private void cmd_sửa_Click(object sender, EventArgs e)
        {
            

            
                ketnoi.Open();
                string mssv = text_mssv.Text;
                string hoten = text_hotensv.Text;
                string gioitinh = text_gtsv.Text;
                string diachi = text_dcsv.Text;
                string sdt = text_sdtsv.Text;

                string sql1 = @"update SINH_VIEN SET mssv ='" + mssv + "' ,hoten = N'" + hoten + "' , gioitinh = N'" + gioitinh + "' , sdt = " + sdt + "  , diachi =  N'" + diachi + "'  where  mssv = '"+ masv+"' ";
                MessageBox.Show(sql1);
                MessageBox.Show("THÊM THÀNH CÔNG!!");

                thuchien = new SqlCommand(sql1, ketnoi);
                thuchien.ExecuteNonQuery();

                xoa();
                ketnoi.Close();
            
        }
       
        private void cmd_xoaphong_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string sql1 = @"DELETE FROM PHONG
            WHERE maphong = '" + PHONG + "'";

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();


            hienthi2();
            dataGridView2.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void cmd_viewlop_Click(object sender, EventArgs e)
        {
            hienthi4();
            dataGridView4.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void cmd_viewkhoa_Click(object sender, EventArgs e)
        {
            hienthi3();
            dataGridView3.DataSource = dt;
            docdulie.Close();
            ketnoi.Close();
        }

        private void cmd_themphong_Click(object sender, EventArgs e)
        {
            themphong();
        }
        public void themphong()
        {
            ketnoi.Open();
            string maphong = txt_maphong.Text;
            string sophong = txt_sophong.Text;
            string loaiphong = txt_loaiphong.Text;
            string toanha = txt_toanha.Text;
            

            string sql1 = @"insert into PHONG values ('" + maphong + "' , N'" + sophong + "' , N'" + loaiphong + "' , '" + toanha + "  ')";
            MessageBox.Show(sql1);
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();
        }

        private void cmd_themlop_Click(object sender, EventArgs e)
        {
                   themlop();
        }
        public void themlop()
        {
            ketnoi.Open();
            string malop = txt_malop.Text;
            string tenlop = txt_tenlop.Text;
            

            string sql1 = @"insert into LOP values ('" + malop + "' , N'" + tenlop + "'  )";
            MessageBox.Show(sql1);
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();
        }

        private void cmd_themkhoa_Click(object sender, EventArgs e)
        {
            themkhoa();
        }
        public void themkhoa()
        {
            ketnoi.Open();
            string makhoa = txt_makhoa.Text;
            string tenkhoa = txt_tenkhoa.Text;


            string sql1 = @"insert into  values ('" + makhoa + "' , N'" + tenkhoa + "'  )";
            MessageBox.Show(sql1);
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql1, ketnoi);
            thuchien.ExecuteNonQuery();

            xoa();
            ketnoi.Close();
        }

    }
}
