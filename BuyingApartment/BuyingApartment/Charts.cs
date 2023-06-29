using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BuyingApartment
{
    public partial class Charts : Form
    {
        private FormData _data => ProjectContext.Instance.FormData;
        private List<Strategy> _strategies = new List<Strategy>();

        public Charts()
        {
            InitializeComponent();

            Calculate();
        }

        public void Calculate()
        {
            chart1.Series.Clear();
            var delta = 100f / (_data.Count - 1);
            for (int i = 0; i < _data.Count; i++)
            {
                _strategies.Add(new Strategy(i*delta));
                chart1.Series.Add(GetSerias($"{i * delta}%"));
            }
            int month = 0;
            while (month < 240)
            {
                for (int i = 0; i < _data.Count; i++)
                {
                    chart1.Series[i].Points.AddXY(month, _strategies[i].Sum);
                    _strategies[i].Update();
                }
                month++;
            }

            _strategies.Sort();
            _strategies.Reverse();

            label1.Text = $"Месяц {month}" + Environment.NewLine; 
            foreach (var strategy in _strategies)
            {
                label1.Text += strategy.ToString() + Environment.NewLine;
            }
        }

        private Series GetSerias(string name)
        {
            var serias = new Series();
            serias.ChartType = SeriesChartType.Line;
            serias.Name = name;
            serias.BorderWidth = 2;
            serias.Points.Clear();
            return serias;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
