using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace RepairSystem
{
    // الفرن   
    public class clsOven : clsDeviceBase
    {
        private double _heaterPrice;   // سعر السخان

        public double HeaterPrice
        {
            get { return _heaterPrice; }
            set { _heaterPrice = value; }
        }

        public clsOven(int s, string b, double c, double h) : base(s, b, c)
        {
            _heaterPrice = h;
        }

        public override double CalcCost()
        {
            return BaseCost + _heaterPrice + 10;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Oven -> " + ShowInfo() + " | Cost: " + CalcCost());
        }
    }
}
