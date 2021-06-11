using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab18
{
    
    public partial class Form1 : Form
    {
        Model model = new Model();
        double l, ny, T;
        int N, Oper;
        Dictionary<int, double> Stat;
        Dictionary<int, double> Freq;
        AgentQueuePerson two;
        AgentOperator one;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            l = (double)numericUpDown3.Value;
            ny = (double)numericUpDown4.Value;
            N = (int)numericUpDown1.Value;
            T = (double)numericUpDown2.Value;
            Oper = (int)numericUpDown5.Value;
            model.Data(l, ny, N, T,Oper);

            two = new AgentQueuePerson(model.Lambda);
            one = new AgentOperator(model.Mu, model.NumberOfOperators);

            Freq = model.Probability(one, two);
            Stat = model.Statistics();

            foreach(int i in Freq.Keys)
            {
                chart1.Series[0].Points.AddXY(i, Freq[i]);
                chart2.Series[0].Points.AddXY(i, Stat[i]);
            }

            foreach(int i in Stat.Keys)
            {
                chart2.Series[0].Points.AddXY(i, Stat[i]);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
