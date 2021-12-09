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
    public partial class Form2 : Form
    {
        string filePathForm = @"C:\Users\home\source\repos\Lab5LM\Form.txt";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePathForm) == false)
            {
                FileStream fs = File.Create(filePathForm);
                fs.Close();
                File.WriteAllText(filePathForm, "TestForm");
            }

            textBox2.Text = File.ReadAllText(filePathForm);
            this.Text = File.ReadAllText(filePathForm);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("\tЗміна назви форми\n");
            string FormName = textBox2.Text; ;
            try
            {
                this.Text = FormName;
                if (File.Exists(filePathForm) == false)
                {
                    FileStream fs = File.Create(filePathForm);
                    fs.Close();
                }

                File.WriteAllText(filePathForm, FormName);
            }
            catch
            {
                richTextBox1.AppendText("Error\n\n");
            }
            richTextBox1.AppendText(Lang.FormName + "\n\n");
            richTextBox1.AppendText(Lang.Restart + "\n\n");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("\tЗміна назви форми\n");
            string FormName = textBox2.Text; ;
            try
            {
                this.Text = FormName;
                Form1 newForm = new Form1();
                newForm.Text = FormName;
            }
            catch
            {
                richTextBox1.AppendText("Error\n\n");
            }
            richTextBox1.AppendText(Lang.FormName + "\n\n");
            richTextBox1.AppendText(Lang.Restart + "\n\n");
        }
    }
}
