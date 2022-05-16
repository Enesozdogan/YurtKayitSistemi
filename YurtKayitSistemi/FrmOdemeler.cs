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

namespace YurtKayitSistemi
{
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
       

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen=dataGridView1.SelectedCells[0].RowIndex;
            id=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad=dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan=dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtAd.Text=ad;
            TxtSoyad.Text=soyad;
            TxtKalanBorc.Text=kalan;
            TxtOgrid.Text = id;
        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {

            try
            {
                int odenen, kalan, yeniborc;
                odenen = Convert.ToInt16(TxtOdenen.Text);
                kalan = Convert.ToInt16(TxtKalanBorc.Text);
                yeniborc = kalan - odenen;
                TxtKalanBorc.Text = yeniborc.ToString();
                SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p1", TxtKalanBorc.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                
                this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);
                //kasaya gelir ekle
                SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@k1", TxtOdenenAy.Text);
                komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            catch (Exception)
            {
                MessageBox.Show("hata:");
                
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
