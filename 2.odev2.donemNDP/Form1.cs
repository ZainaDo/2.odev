/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          PROGRAMLAMAYA GİRİŞİ DERSİ
**	
**				ÖDEV NUMARASI…...:  2
**				ÖĞRENCİ ADI...: Zaina Aldous 
**				ÖĞRENCİ NUMARASI.: G221210594
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

namespace _2.odev2.donemNDP
{
    public partial class Form1 : Form
    {
       
        Color kalemRengi = Color.Black ;
        int kalimKalinligi = 1;
        Color fircaRengi = Color.Black ;
        Color zemin = Color.Red;
        Graphics cizim; 

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Cizimi yapilacak olan nesne secimi iz
            combBoxElemen1.Items.Add("Nokta-Dörtgen ");
            combBoxElemen1.Items.Add("Nokta-çember ");
            combBoxElemen1.Items.Add("Dikdörtgen-dikdörtgen ");
            combBoxElemen1.Items.Add("Dikdörtge-çember  ");
            combBoxElemen1.Items.Add("Çember-çember ");
            combBoxElemen1.Items.Add("Nokta-Küre ");
            combBoxElemen1.Items.Add("Nokta-dikdörtgen prizma");
            combBoxElemen1.Items.Add("Nokta-Silindir  ");
            combBoxElemen1.Items.Add("Silindir-Silindir");
            combBoxElemen1.Items.Add("Küre-Küre");
            combBoxElemen1.Items.Add("Küre-Silindir");
            combBoxElemen1.Items.Add("Yüzey-küre ");
            combBoxElemen1.Items.Add("Yüzey-dikdörtgen prizma ");
            combBoxElemen1.Items.Add("Yüzey-Silindir");
            combBoxElemen1.Items.Add("Küre-dikdörtgen prizma");
            combBoxElemen1.Items.Add("dikdörtgen prizma-dikdörtgen prizma");
           


            combBoxElemen1.SelectedIndex = 0;
            for(int i=1; i<10; i++)
            {
                listBox1.Items.Add(i.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cizim = panel2.CreateGraphics();
            // cizim clear (zemin);
           
            if (combBoxElemen1.Text == "Dikdortgen ")
            {
                cizim.DrawRectangle(new Pen(kalemRengi, kalimKalinligi), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            }
            
            else if (combBoxElemen1.Text == " Elips")
            {
                cizim.DrawEllipse(new Pen(kalemRengi, kalimKalinligi), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            }
            else
            {
                cizim.FillRectangle(new SolidBrush(fircaRengi), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            }
               
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cdlg = new ColorDialog(); 
            if(cdlg .ShowDialog () == DialogResult.OK )
            {
                kalemRengi = cdlg.Color; 

            }
        }

        private void combBoxElemen1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (combBoxElemen1 .Text == "Dolu Dikdortgen ")
            {
                
                groupBox3.Visible = true;
                groupBox2.Visible = false;
               
            }
            else
            {
                
                groupBox2.Visible = true; 

            }
            zemin = Color.White; 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kalimKalinligi = Convert.ToInt32(listBox1.SelectedItem);
            //textBox5.text = kalemKalinligi.Tostring ; 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cdlg = new ColorDialog();
            if (cdlg.ShowDialog() == DialogResult.OK)
            {
                fircaRengi = cdlg.Color;
            }
        }

       

        
    }
}
