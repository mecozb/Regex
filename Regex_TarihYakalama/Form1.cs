using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regex_TarihYakalama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 5;
            progressBar1.Value = 0;
           // Application.EnableVisualStyles();
            progressBar1.ForeColor = Color.Green;
        }

        Regex sLetter = new Regex(@"[a-z]");
        Regex uLetter = new Regex(@"[A-Z]");
        Regex number = new Regex(@"[0-9]");
        Regex signs = new Regex(@"[\.]|[\?]|[\\]|[\*]|[\;]|[\,]|[\:]|[-_!']");


        private void button1_Click(object sender, EventArgs e)
        {
            // Regular Expression için bir desen (pattern) tanımlıyoruz :

            string tarihDeseni = @"((0[1-9])|([12][0-9])|(3[01]))(-)((0?[1-9])|(1[0-2]))(-)([12][0-9][0-9][0-9])";

            string telefonDeseni = @"(0?5[0-9][0-9])(-)([0-9][0-9][0-9])(-)([0-9][0-9])(-)([0-9][0-9])";

            string TCKN_Deseni = @"[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][02468]";


            // Regular Expressionumuzu tanımlıyoruz :
           

            Regex regexTarih = new Regex(tarihDeseni);
            Regex regexTelefon = new Regex(telefonDeseni);
            Regex regexTCKN = new Regex(TCKN_Deseni);
            Regex regexPassword = new Regex(@"([a-zA-Z0-9p{P}P{L}]{8,14})");
            // Tarih arayacağımız metni konsoldan alıyoruz :

            string info = "Tarih: " + textBox1.Text + "\n" + "Tel No: " + textBox2.Text + "\n" + "TCKN: " + textBox3.Text;

            // Metin içerisindeki tarihleri (birden fazla olabilir) Collection nesnesine atıyoruz :

            if(regexTarih.IsMatch(textBox1.Text) && regexTelefon.IsMatch(textBox2.Text) && regexTCKN.IsMatch(textBox3.Text) )
            {
                if (regexPassword.IsMatch(textBox4.Text))
                    MessageBox.Show(info);
                else
                    MessageBox.Show("Parola geçersiz karakterler içeriyor.");

            }
            else
            {
                MessageBox.Show("Tarih formatı,telefon formatı veya TCKN hatalı.Lütfen 'GG-AA-YYYY' '05XX-XXX-XX-XX' şeklinde deneyiniz.");
            }


        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (sLetter.IsMatch(textBox4.Text)) { count++; }
            if (uLetter.IsMatch(textBox4.Text)) { count++; }
            if (number.IsMatch(textBox4.Text)) { count++; }
            if (signs.IsMatch(textBox4.Text)) { count+=2; }

            if(count < 3)
            {
                label5.Text = "Zayıf";
                progressBar1.ForeColor = Color.Red;
                progressBar1.Value = count;
            }
            else if (count == 3)
            {
                label5.Text = "Orta";
                progressBar1.ForeColor = Color.Yellow;
                progressBar1.Value = count;
            }
            else if (count > 3)
            {
                label5.Text = "Güçlü";
                progressBar1.ForeColor = Color.Green;
                progressBar1.Value = count;
            }

        }
    }
}
