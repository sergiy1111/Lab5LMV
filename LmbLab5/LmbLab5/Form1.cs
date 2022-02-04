using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LmbLab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
            this.Text = Properties.Settings.Default.FormName;
            textBox1.Text = Convert.ToString(Properties.Settings.Default.ValueX);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePathInfo = @"D:\GitCon\Lab5LMV\LmbLab5\Info.txt";
            if (File.Exists(filePathInfo) == false)
            {
                FileStream fs = File.Create(filePathInfo);
                fs.Close();
            }
            string Text = richTextBox1.Text;

            File.WriteAllText(filePathInfo, Text);
            richTextBox1.AppendText("\t" + Res.Save + "\n");
            richTextBox1.AppendText(Res.SavedCalc + " " + filePathInfo + "\n\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            richTextBox1.AppendText("\t" + Res.Calc + "\n");
            richTextBox1.AppendText("Sqrt(" + x + "): " + Math.Sqrt(x) + "\n\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            richTextBox1.AppendText("\t" + Res.Calc + "\n");
            richTextBox1.AppendText("Sin(" + x + "): " + Math.Sin(x) + "\n\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            richTextBox1.AppendText("\t" + Res.Calc + "\n");
            richTextBox1.AppendText("Cos(" + x + "): " + Math.Cos(x) + "\n\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            richTextBox1.AppendText("\t" + Res.Calc + "\n");
            richTextBox1.AppendText("Sqrt(" + x + "): " + Math.Sqrt(x) + "\n");
            richTextBox1.AppendText("Sin(" + x + "): " + Math.Sin(x) + "\n");
            richTextBox1.AppendText("Cos(" + x + "): " + Math.Cos(x) + "\n\n");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.X = this.DesktopLocation.X;
            Properties.Settings.Default.Y = this.DesktopLocation.Y;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Properties.Settings.Default.X, Properties.Settings.Default.Y);
        }
    }
}