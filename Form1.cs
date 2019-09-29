using System;
using System.Windows.Forms;
// расчет тока 3х фазного двигателя
namespace TestMoto01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double VuborCifr(string str1)
        {
            string str = str1;
            string str2 = "";
            foreach (char ch in str.ToCharArray())
            {
                if ((Char.IsNumber(ch)) || (Char.IsPunctuation(ch)))
                {
                    if (ch == '.') { } // пропускаем точку при вводе ватт 
                    else str2 += ch.ToString();
                }
            }
            return Convert.ToDouble(str2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double wat, NominTok, pyskToki, tempVolt = 380, cosφ = 0.85, KPD = 75;
            if (radioButton3.Checked) tempVolt = 380;
            else if (radioButton1.Checked) tempVolt = 127;
            else if (radioButton2.Checked) tempVolt = 220;
            else if (radioButton4.Checked) tempVolt = 660;

            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                wat = VuborCifr(textBox1.Text);
                cosφ = VuborCifr(textBox2.Text);
                KPD = VuborCifr(textBox3.Text);
                textBox2.Text = cosφ.ToString();
                textBox3.Text = KPD.ToString();
                //  Iном = P /√3Ucosφη=   P /1.73Ucosφη= P/42073.6  //по умолчанию// кпд 80 переводим в 0.8
                NominTok = (wat * 100000) / (1.73 * tempVolt * cosφ * KPD);
                NominTok = Math.Ceiling(NominTok);
                pyskToki = 6 * NominTok;
                textBox1.Text = wat.ToString();
                label3.Text = NominTok.ToString() + " A";
                label7.Text = pyskToki.ToString() + " A";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "0.85";
            textBox3.Text = "75";
        }
    }
}
