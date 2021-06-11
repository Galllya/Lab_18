using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    public class AgentOperator
    {
        Random rnd = new Random();

        double Mu;
        public int BUS, NUM;

        public AgentOperator(double m,int noo)
        {
            Mu = m;
            NUM = noo;
        }

        public int BUS1 { get => BUS; set => BUS = value; }
        public int NUM1 { get => NUM;}

        public double GetNextEvent()
        {
            if(BUS>0)
            {
                double A = rnd.NextDouble();
                double temp = A * BUS;
                return (-Math.Log(temp) / Mu);
            }
            else { return Double.PositiveInfinity; }
        }

        public void ProcessEvent(AgentQueuePerson aqp)
        {
            if(aqp.NumberOfPerson1 == 0)
            {
                BUS--;
            }
            else
            {
                aqp.NumberOfPerson1--;
            }
        }
    }
}
