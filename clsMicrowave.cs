using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace RepairSystem
{
    // المايكروويف      
    public class clsMicrowave : clsDeviceBase
    {
        private bool _magnetron;   // هل المغناطيس تغير

        public bool Magnetron
        {
            get { return _magnetron; }
            set { _magnetron = value; }
        }

        public clsMicrowave(int s, string b, double c, bool m) : base(s, b, c)
        {
            _magnetron = m;
        }

         public override double CalcCost()
        {
            double total = BaseCost;
            if (_magnetron == true)
            {
                total = total + 70;
            }
            return total;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Microwave -> " + ShowInfo() + " | Cost: " + CalcCost());
        }
    }
}
