using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam_Asmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string skelime;
        string[,] kelimeler = new string[8, 3] { { "ASA", "TEL", "YER" }, { "KOMİ", "ARKA", "KARE" }, { "DENİZ", "GÖLET", "YOKUŞ" }, { "ŞALTER", "TERLİK", "HATIRA" }, { "TELEFON", "OYUNCAK", "ASKILIK" }, { "KARAKTER", "ŞARAPNEL", "PITIRCIK" }, { "BABAYİĞİT", "FAGOSİTOZ", "JEOTERMAL" }, { "TERBİYESİZ", "ABDESTHANE", "RADYOAKTİF" } };

        private void Form1_Load(object sender, EventArgs e)
        {
            panel9.Visible = false;
            p5.Location = new Point((p4.Location.X-(p5.Width/2)),p4.Location.Y+p4.Height);
            p6.Location = new Point(p5.Location.X,((p6.Location.Y-(p5.Height/3))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel9.Visible = true;  
            Random rndm = new Random();
            skelime = kelimeler[(Convert.ToInt32(numericUpDown1.Value) - 3), rndm.Next(0, 3)];
            int harfuzunluk = 1;
            int konum = 0;

            for (int i = 0; i < skelime.Length; i++)
            {
                Label harf = new Label();
                harf.Font = new Font(harf.Font.FontFamily,36,harf.Font.Style);
                harf.Location = new Point(konum,0);
                harf.Height = 55;
                harf.Width = 50;
                konum += 50;
                harfuzunluk = 50;
                harf.Text = skelime[i].ToString();
                panel4.Controls.Add(harf);
                harf.Visible = false;
            }
            panel4.Width = 50 * skelime.Length;
            panel4.Location = new Point((panel2.Width-panel4.Width)/2,(panel2.Height-panel4.Height)/2);
        }

        bool hatadrm = true;
        bool mevcutharf = false;
        int hatasay = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            hatadrm = true;
            mevcutharf = false;
            foreach (Control harf in panel4.Controls)
            {
                if (harf.Text == textBox1.Text.ToUpper())
                {
                    if (harf.Visible==true)
                    {
                        mevcutharf = true;
                    }
                    harf.Visible = true;
                    hatadrm = false;
                }  
            }

            if (mevcutharf==true)
            {
                MessageBox.Show("Bu harf zaten açılmış durumda.");
            }

            if (hatadrm ==true)
            {
                hatasay++;
                foreach (Control parca in panel10.Controls)
                {
                    if (parca.Name == "p" + hatasay)
                    {
                        parca.Visible = true;
                    }
                }

                if (p6.Visible == true)
                {
                    MessageBox.Show("Maalesef,Kaybettiniz !");
                    Application.Restart();
                }
            }

            int aharf = 0;
            foreach (Control harfsay in panel4.Controls)
            {
                if (harfsay.Visible==true)
                {
                    aharf++;
                }

                if (skelime.Length==aharf)
                {
                    MessageBox.Show("Tebrikler,Kazandınız !");
                    Application.Restart();
                }
            }

            if (!skelime.Contains(textBox1.Text.ToUpper())&&!listBox1.Items.Contains(textBox1.Text.ToUpper()))
            {
                listBox1.Items.Add(textBox1.Text);
            }
            textBox1.Text = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>0)
            {
                string harf = textBox1.Text;
                textBox1.Text = harf.Substring(0, 1).ToUpper();
            }
        }
    }
}
