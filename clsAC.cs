using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace RepairSystem
{
    // المكيف
    public class clsAC : clsDeviceBase
    {
        private bool _gasFill;   // هل بدو تعبئة غاز

        public bool GasFill
        {
            get { return _gasFill; }
            set { _gasFill = value; }
        }

        public clsAC(int s, string b, double c, bool g) : base(s, b, c)
        {
            _gasFill = g;
        }

        // التكلفة = أساسي + (إذا غاز 50)
        public override double CalcCost()
        {
            double total = BaseCost;
            if (_gasFill == true)
            {
                total = total + 50;
            }
            return total;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("AC -> " + ShowInfo() + " | Cost: " + CalcCost());
        }
    }
}