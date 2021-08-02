using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        class Oil
        {
            public string Name { get; set; }
            public double Price { get; set; }

        }
        Oil A95 = new Oil { Name = "Ai-95", Price = 1.45 };
        Oil A92 = new Oil { Name = "Ai-92", Price = 1 };

        public Form1()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            ComboBoxOil.Items.Add(A92);
            ComboBoxOil.Items.Add(A95);
            ComboBoxOil.DisplayMember = "Name";
            lblGasolinePrice.Text = "";
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
        }
        private void ComboBoxOil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = (ComboBoxOil.SelectedItem as Oil)?.Price.ToString();
        }

        private void RadiobtnPerLiter_CheckedChanged(object sender, EventArgs e)
        {
            var btn = RadiobtnPerLiter;
            if (btn.Checked)
            {
                guna2PictureBox3.Image = Properties.Resources.icons8_cash_app_48;
                label3.Text = "AZN";
                txtPerLiter.Enabled = true;
                btn.Location = new Point(btn.Location.X + 20, btn.Location.Y);
                lblGasolinePrice.Text = "";
            }
            else
            {
                txtPerLiter.Enabled = false;
                txtPerLiter.Text = "";
                btn.Location = new Point(btn.Location.X - 20, btn.Location.Y);
            }
        }

        private void RadioButtonForPrice_CheckedChanged(object sender, EventArgs e)
        {
            var btn = RadioButtonForPrice;
            if (btn.Checked)
            {
                guna2PictureBox3.Image = Properties.Resources.icons8_gas_station_50;
                label3.Text = "Liter";
                txtForPrice.Enabled = true;
                btn.Location = new Point(btn.Location.X + 20, btn.Location.Y);
                lblGasolinePrice.Text = "";
            }
            else
            {
                txtForPrice.Enabled = false;
                txtForPrice.Text = "";
                btn.Location = new Point(btn.Location.X - 20, btn.Location.Y);
            }
        }

        private void txtPerLiter_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(txtPerLiter.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    txtPerLiter.Text = txtPerLiter.Text.Replace('.', ',');
                    txtPerLiter.SelectionStart = txtPerLiter.Text.Length;
                    var temp = Convert.ToDouble(txtPerLiter.Text) * Convert.ToDouble(txtPrice.Text);
                    var num1 = (int)temp;
                    var num2 = (int)((temp - num1) * 100);
                    lblGasolinePrice.Text = $"{num1},{num2}";
                }
                else
                {
                    lblGasolinePrice.Text = $"";
                }
            }
            catch
            {
                lblGasolinePrice.Text = "";
                txtPerLiter.Text = txtPerLiter.Text.Substring(0, txtPerLiter.Text.Length - 1); ;
            }
        }

        private void txtForPrice_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(txtForPrice.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                {

                    txtForPrice.Text = txtForPrice.Text.Replace('.', ',');
                    txtForPrice.SelectionStart = txtForPrice.Text.Length;
                    var temp = Convert.ToDouble(txtForPrice.Text) / Convert.ToDouble(txtPrice.Text);
                    int num1 = (int)temp;
                    int num2 = (int)((temp - num1) * 100);
                    lblGasolinePrice.Text = $"{num1},{num2}";
                }
                else
                {
                    lblGasolinePrice.Text = "";
                }
            }
            catch
            {
                lblGasolinePrice.Text = "";
                txtForPrice.Text = txtForPrice.Text.Substring(0, txtForPrice.Text.Length - 1); ;
            }
        }
        void TxtTextChanged(ref Guna.UI2.WinForms.Guna2TextBox Text1, ref Guna.UI2.WinForms.Guna2TextBox Text2, double price)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Text1.Text))
                {
                    var temp = Convert.ToInt32(Text1.Text);
                    Text2.Text = $"{temp * price}";
                    SumMarketPrice();
                }
                else
                    Text2.Text = $"{price}";
                SumMarketPrice();
            }
            catch
            {
                Text1.Text = Text1.Text.Substring(0, Text1.Text.Length - 1); ;
                Text1.SelectionStart = Text1.Text.Length;
            }
        }
        void SumMarketPrice()
        {
            double Sum = 0;

            if (txtQuanityHotDog.Enabled)
                Sum += Convert.ToDouble(txtHotdogPrice.Text);
            if (txtQuanityHamburger.Enabled)
                Sum += Convert.ToDouble(txtHamburgerPrice.Text);
            if (txtQuanityFries.Enabled)
                Sum += Convert.ToDouble(txtFriesPrice.Text);
            if (txtQuanityCola.Enabled)
                Sum += Convert.ToDouble(txtColaPrice.Text);
            txtMarketPrice.Text = $"{Sum.ToString()}";
        }
        void GoCheck(ref Guna.UI2.WinForms.Guna2TextBox Text1, ref Guna.UI2.WinForms.Guna2CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                Text1.Enabled = true;
                SumMarketPrice();
            }
            else
            {
                Text1.Enabled = false;
                Text1.Text = "1";
                SumMarketPrice();
            }
        }
        private void ChechBoxHotDog_CheckedChanged(object sender, EventArgs e)
        {
            GoCheck(ref txtQuanityHotDog, ref ChechBoxHotDog);
        }

        private void txtQuanityHotDog_TextChanged(object sender, EventArgs e)
        {
            TxtTextChanged(ref txtQuanityHotDog, ref txtHotdogPrice, 3.5);
        }
        private void CheckBoxHamburger_CheckedChanged(object sender, EventArgs e)
        {
            GoCheck(ref txtQuanityHamburger, ref CheckBoxHamburger);
        }

        private void txtQuanityHamburger_TextChanged(object sender, EventArgs e)
        {
            TxtTextChanged(ref txtQuanityHamburger, ref txtHamburgerPrice, 5.3);
        }

        private void CheckBoxFries_CheckedChanged(object sender, EventArgs e)
        {
            GoCheck(ref txtQuanityFries, ref CheckBoxFries);
        }

        private void txtQuanityFries_TextChanged(object sender, EventArgs e)
        {
            TxtTextChanged(ref txtQuanityFries, ref txtFriesPrice, 4.1);
        }
        private void CheckBoxCola_CheckedChanged(object sender, EventArgs e)
        {
            GoCheck(ref txtQuanityCola, ref CheckBoxCola);
        }

        private void txtQuanityCola_TextChanged(object sender, EventArgs e)
        {
            TxtTextChanged(ref txtQuanityCola, ref txtColaPrice, 1.0);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double Sum = 0;
            if (RadioButtonForPrice.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtForPrice.Text))
                    Sum += Convert.ToDouble(txtForPrice.Text);
            }
            else
                if (!string.IsNullOrWhiteSpace(lblGasolinePrice.Text))
                Sum += Convert.ToDouble(lblGasolinePrice.Text);
            if (!string.IsNullOrWhiteSpace(txtMarketPrice.Text))
                Sum += Convert.ToDouble(txtMarketPrice.Text);
            txtAllPrice.Text = $"{Sum}";
        }
    }
}
