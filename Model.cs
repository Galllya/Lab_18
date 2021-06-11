using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    public class Model
    {
        double oneNext, twoNext;
        double Time = 0;
        double T, IS;
        int k, N;
        public double Lambda, Mu;
        double Rho;
        public int NumberOfOperators;

        Dictionary<int,double> Freq = new Dictionary<int, double>();
        Dictionary<int, double> Stat;

        public void Data(double l,double m,int n,double t,int noo)
        {
            IS = StatInity(noo);

            Lambda = l;
            Mu = m;
            Rho = l / m;
            N = n;
            T = t;
            k = 0;
            NumberOfOperators = noo;
          
            

        }

        public Dictionary<int,double> Statistics()
        {
            Stat = Freq;
            foreach(int i in Stat.Keys.ToList())
            {
                if (i < NumberOfOperators)
                {
                    Stat[i] = (Math.Pow(Rho, i) / Factorial(i)) * IS;
                }
                else
                {
                    Stat[i] = (Math.Pow(Rho, i) / (Factorial(i) * Math.Pow(NumberOfOperators, i - NumberOfOperators))) * IS;
                }
            }
            return Stat;
        }

        public Dictionary<int,double> Probability(AgentOperator ao, AgentQueuePerson aqp)
        {
            while(k<N)
            {
                while(Time<T)
                {
                    twoNext = ao.GetNextEvent();
                    oneNext = aqp.GetNextEvent();
                    if(oneNext<twoNext)
                    {
                        aqp.ProcessEvent(ao);
                        Time += oneNext;
                    }
                    else
                    {
                        ao.ProcessEvent(aqp);
                        Time += twoNext;
                    }
                }
                k++;
                Time = 0;
                try
                {
                    Freq.Add(ao.BUS + aqp.NumberOfPerson1, 0);
                }
                catch
                {
                    
                }
     
                Freq[ao.BUS + aqp.NumberOfPerson1]++;
               
            }

            foreach(int i in Freq.Keys.ToList())
            {
                Freq[i] /= N;
            }

            return Freq;
        }

       
        private int Factorial(int i)
        {
            int temp = 1;
            for (int j = 1; j <= i; j++) { temp *= j;}   
            return temp;
        }

        private double StatInity(int noo)
        {
            double temp = 0;
            for (int i = 0; i < noo; i++)
            {
                temp += Math.Pow(Rho, i) / Factorial(i);
            }
            double temp1 = Math.Pow(Rho, (noo + 1)) / Factorial(noo) * (noo - Rho);
            double iss = Math.Pow((temp + temp1), -1);
            return iss;
        }

    }
}
