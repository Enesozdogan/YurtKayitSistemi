﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace YurtKayitSistemi
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Kayit yeri";
            saveFileDialog1.Filter = "Metin Dosyasi|*.txt";
            saveFileDialog1.InitialDirectory = "C:\\Yurttxt";
            saveFileDialog1.ShowDialog();
            StreamWriter kaydet=new StreamWriter(saveFileDialog1.FileName);
            kaydet.WriteLine(richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Kaydedildi");
           
        }    
    }
}
