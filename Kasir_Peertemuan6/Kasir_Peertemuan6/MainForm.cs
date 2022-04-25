/*
 * Created by SharpDevelop.
 * User: ASUS
 * Date: 4/19/2022
 * Time: 3:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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

namespace Kasir_Peertemuan6
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        readonly Koneksi Konn = new Koneksi();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			TampilBarang();
			Bersihkan();
		
			}
			
			void TampilBarang()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from TBL_BARANG", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_BARANG");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_BARANG";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
		}
			void Bersihkan()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "0";
			textBox4.Text = "0";
			textBox5.Text = "0";
			textBox6.Text = "";
		}
			
			/*
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from TBL_BARANG", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_BARANG");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_BARANG";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        */
private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

} 
private void MainForm_Load(object sender, EventArgs e)
        {
     }
		void Label2Click(object sender, EventArgs e)
		{
		}
		void Label4Click(object sender, EventArgs e)
		{
	
		} 
		
		/*Tombol Simpan*/
		void Button1Click(object sender, EventArgs e)
		{
			/*Memeriksa apakah isi kolom kosong*/
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" ||textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu kolom-kolom yang tersedia");
			}
			/*Simpan Data*/
			else
			{
				SqlConnection conn = Konn.GetConn();
				try
				{
					cmd = new SqlCommand("INSERT INTO TBL_BARANG VALUES ('" + textBox1.Text + "','" +textBox2.Text + "','" + textBox3.Text +"','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Insert Data Berhasil!");
					TampilBarang();
					Bersihkan();
				}
				catch(Exception X)
				{
					MessageBox.Show("Tidak dapat menyimpan data!");
				}
			}
		}
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
				textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
				textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
				textBox3.Text = row.Cells["HargaJual"].Value.ToString();
				textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
				textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
				textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
			}
			catch (Exception e1)
			{
				MessageBox.Show(e1.ToString());
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			/*Memeriksa apakah isi kolom kosong*/
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" ||textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu kolom-kolom yang tersedia");
			}
			/*Ubah Data*/
			else
			{
				SqlConnection conn = Konn.GetConn();
				try
				{
					cmd = new SqlCommand("UPDATE TBL_BARANG SET NamaBarang='" +textBox2.Text + "',HargaJual='" + textBox3.Text +"',HargaBeli='" + textBox4.Text + "',JumlahBarang='" + textBox5.Text + "',SatuanBarang='" + textBox6.Text + "' WHERE KodeBarang='"+textBox1.Text+"'" , conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Update Data Berhasil!");
					TampilBarang();
					Bersihkan();
				}
				catch(Exception X)
				{
					MessageBox.Show("Tidak dapat menyimpan data!");
				}
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(MessageBox.Show(textBox2.Text+", Yakin ingin menghapus data ini?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				/*HAPUS DATA*/
				SqlConnection conn = Konn.GetConn();
				{
					cmd = new SqlCommand("DELETE FROM TBL_BARANG where KodeBarang='" + textBox1.Text + "'", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Hapus Data Berhasil!");
					TampilBarang();
					Bersihkan();
				}
			}
		}
     }
}

