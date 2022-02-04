using System;
using System.Windows.Forms;

namespace LmbLab5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            { 
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
            this.Text = Properties.Settings.Default.FormName;
            textBox1.Text = Convert.ToString(Properties.Settings.Default.ValueX);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.FormName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Res.LangChange_ + " " +  Res.Changes2, Res.LangSave, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]
            {
                System.Globalization.CultureInfo.GetCultureInfo("uk-UA"),
                System.Globalization.CultureInfo.GetCultureInfo("en-US")
            };
            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }
            this.Name = Properties.Settings.Default.FormName;
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
            Properties.Settings.Default.ValueX = textBox1.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show(Res.Changes, Res.Save);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FormName= textBox2.Text;
            Properties.Settings.Default.Save();
            string name = Properties.Settings.Default.FormName;
            this.Text = name;
            MessageBox.Show(Res.Changes, Res.Save);
        }
    }
}