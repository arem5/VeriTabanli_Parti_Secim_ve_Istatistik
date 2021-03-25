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
namespace VeriTabanli_Parti_Secim_ve_Istatistik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=Db_Secim;Integrated Security=True");
        private void btn_OyGir_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_Ilce (Ilce_Adi,A_Partisi,B_Partisi,C_Partisi,D_Partisi,E_Partisi) values (@P1,@P2,@P3,@P4,@P5,@P6)");
            komut.Parameters.AddWithValue("@P1", txt_ilce.Text);
            komut.Parameters.AddWithValue("@P2", txt_A.Text);
            komut.Parameters.AddWithValue("@P3", txt_B.Text);
            komut.Parameters.AddWithValue("@P4", txt_C.Text);
            komut.Parameters.AddWithValue("@P5", txt_D.Text);
            komut.Parameters.AddWithValue("@P6", txt_E.Text);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            MessageBox.Show("Oy girişi gerçekleşti.");
            baglanti.Close();
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }

        }

        private void btn_Girafik_Click(object sender, EventArgs e)
        {
            Frm_Grafikler form_grafik = new Frm_Grafikler();
            form_grafik.Show();
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
