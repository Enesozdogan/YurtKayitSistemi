using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class RaporGiderler : Form
    {
        public RaporGiderler()
        {
            InitializeComponent();
        }

        private void RaporGiderler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet12.Giderler' table. You can move, or remove it, as needed.
            this.giderlerTableAdapter.Fill(this.yurtOtomasyonDataSet12.Giderler);

            this.reportViewer1.RefreshReport();
        }
    }
}
