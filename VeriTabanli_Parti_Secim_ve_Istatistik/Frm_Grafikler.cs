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
    public partial class Frm_Grafikler : Form
    {
        public Frm_Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=Db_Secim;Integrated Security=True");
        private void Frm_Grafikler_Load(object sender, EventArgs e)
        {
            //İlçe adlarını Combo Box a çekme.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ilce_Adi from TBL_Ilce", baglanti);
            SqlDataReader data_reader = komut.ExecuteReader();
            while (data_reader.Read())
            {
                comboBox1.Items.Add(data_reader[0]);
            }
            baglanti.Close();

            //Grafiğe toplam Sonuçları getirme.
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Sum(A_Partisi),Sum(B_Partisi),Sum(C_Partisi)," +
                "Sum(D_Partisi),Sum(E_Partisi) from TBL_Ilce", baglanti);
            SqlDataReader data_reader2 = komut2.ExecuteReader();
            while (data_reader2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", data_reader2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", data_reader2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", data_reader2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", data_reader2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", data_reader2[4]);
            }
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TBL_Ilce where Ilce_Adi = @P1", baglanti);
            komut3.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader data_reader3 = komut3.ExecuteReader();
            while (data_reader3.Read())
            {
                progressBar1.Value = int.Parse(data_reader3[2].ToString());
                progressBar2.Value = int.Parse(data_reader3[3].ToString());
                progressBar3.Value = int.Parse(data_reader3[4].ToString());
                progressBar4.Value = int.Parse(data_reader3[5].ToString());
                progressBar5.Value = int.Parse(data_reader3[6].ToString());

                lbl_A.Text = data_reader3[2].ToString();
                lbl_B.Text = data_reader3[3].ToString();
                lbl_C.Text = data_reader3[4].ToString();
                lbl_D.Text = data_reader3[5].ToString();
                lbl_E.Text = data_reader3[6].ToString();
            }
            baglanti.Close();


        }
    }
}
