using Lab5LM.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5LM
{
    public partial class Form1 : Form
    {
        string filePathText = @"C:\Users\home\source\repos\Lab5LM\Text.txt";
        string filePathData = @"C:\Users\home\source\repos\Lab5LM\Data.txt";
        string filePathInfo = @"C:\Users\home\source\repos\Lab5LM\Info.txt";
        string filePathForm = @"C:\Users\home\source\repos\Lab5LM\Form.txt";
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture =
                    System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) 
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\t" + Lang.FindSqrt +"\n");
            double x = -1;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                richTextBox1.AppendText(Language.Lang.EmpyTextBox + "\n\n");
            }
            if(x != -1)
            {
                richTextBox1.AppendText(Lang.SqrtNumber + " " + x + " = " + Math.Sqrt(x) + "\n\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\t" + Lang.FingSin + "\n");
            double x = -1;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                richTextBox1.AppendText(Lang.EmpyTextBox + "\n\n");
            }
            if (x != -1)
            {
                richTextBox1.AppendText("Sin(" + x + ") = " + Math.Sin(x) + "\n\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\t" + Lang.FindCos + "\n");
            double x = -1;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                richTextBox1.AppendText(Lang.EmpyTextBox + "\n\n");
            }
            if (x != -1)
            {
                richTextBox1.AppendText("Cos(" + x + ") = " + Math.Cos(x) + "\n\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\t" + Lang.FingAll + "\n");
            double x = -1;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                richTextBox1.AppendText(Lang.EmpyTextBox + "\n\n");
            }
            if (x != -1)
            {
                richTextBox1.AppendText(Lang.SqrtNumber + " " + x + " = " + Math.Sqrt(x) + "\n");
                richTextBox1.AppendText("Sin(" + x + ") = " + Math.Sin(x) + "\n");
                richTextBox1.AppendText("Cos(" + x + ") = " + Math.Cos(x) + "\n\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]
            {
                System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language),
                System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language)
            };
            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }

            if (File.Exists(filePathText) == false)
            {
                FileStream fs = File.Create(filePathText);
                fs.Close();
                File.WriteAllText(filePathText, "TestText");
            }

            if (File.Exists(filePathData) == false)
            {
                FileStream fs = File.Create(filePathData);
                fs.Close();
                File.WriteAllText(filePathData, "5");
            }
            if (File.Exists(filePathForm) == false)
            {
                FileStream fs = File.Create(filePathForm);
                fs.Close();
                File.WriteAllText(filePathForm, "TestForm");
            }

            string data = File.ReadAllText(filePathData);
            textBox1.Text = File.ReadAllText(filePathData);
            this.Text = File.ReadAllText(filePathForm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\t"+ Lang.Saving + "\n");
            double x = -1;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                richTextBox1.AppendText(Lang.EmpyTextBox + "\n\n");
            }

            if (File.Exists(filePathData) == false)
            {
                FileStream fs = File.Create(filePathData);
                fs.Close();
            }

            File.WriteAllText(filePathData, Convert.ToString(x));

            richTextBox1.AppendText(Lang.Saved + "\n\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePathInfo) == false)
            {
                FileStream fs = File.Create(filePathInfo);
                fs.Close();
            }
            string Text = richTextBox1.Text;

            File.WriteAllText(filePathInfo, Text);
            richTextBox1.AppendText("\t" + Lang.SavingCal +"\n");
            richTextBox1.AppendText(Lang.SavedCal + "\n");
            richTextBox1.AppendText(Lang.Path + ": "+filePathInfo + "\n\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
        public void ChangeRequiredProperties(string newTitle)
        {
            this.Text = newTitle;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }

}
