using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.SportAchivments". При необходимости она может быть перемещена или удалена.
            this.sportAchivmentsTableAdapter.Fill(this.database1DataSet.SportAchivments);
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            ChartValues<int> sportValues = new ChartValues<int>();
            List<string> dates = new List<string>();
            foreach (var sportRow in database1DataSet.SportAchivments)
            {
                sportValues.Add(sportRow.Achivment);
                dates.Add(sportRow.Date.ToShortDateString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });

            LineSeries sportLine = new LineSeries();

            sportLine.Title = "Пользователь 1";
            sportLine.Values = sportValues;
            series.Add(sportLine);
            cartesianChart1.Series = series;
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show(chartPoint.X + " " + chartPoint.Y);
        }
    }
}
