using System;
using System.Windows.Forms;

namespace BuyingApartment
{
    public partial class Form1 : Form
    {
        private Charts _chartForm;
        private FormData _data => ProjectContext.Instance.FormData;

        public Form1()
        {
            InitializeComponent();

            ProjectContext.Initialize();

            numericUpDown1.Value = 6000000;
            numericUpDown2.Value = 20000;
            numericUpDown3.Value = 50000;
            numericUpDown4.Value = 10.9m;
            numericUpDown5.Value = 6.8m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _chartForm?.Close();
            _chartForm = new Charts();
            _chartForm.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _data.ApartmentCost = (float)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _data.RentingCost = (float)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            _data.Income = (float)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            _data.MortgageRate = (float)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            _data.DepositRate = (float)numericUpDown5.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
