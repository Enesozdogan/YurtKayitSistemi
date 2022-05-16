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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bolum eklendi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Bolum eklenemedi");
                
            }
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bolum silindi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Bolum silinemedi");
                
            }
            
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtBolumAd.Text=bolumad;
            TxtBolumid.Text = id;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {

            try
            {
               
                SqlCommand komut2 = new SqlCommand("update Bolumler Set Bolumad=@p1 where Bolumid=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtBolumid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bolum duzenlendi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Bolum duzenlenemedi");
                
            }
        }
    }
}
