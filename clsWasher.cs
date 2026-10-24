using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace RepairSystem
{
    // الغسالة
    public class clsWasher : clsDeviceBase
    {
        private int _parts;   // عدد القطع

        public int Parts
        {
            get { return _parts; }
            set { _parts = value; }
        }

        public clsWasher(int s, string b, double c, int p) : base(s, b, c)
        {
            _parts = p;
        }

         public override double CalcCost()
        {
            return BaseCost + (_parts * 15);
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Washer -> " + ShowInfo() + " | Cost: " + CalcCost());
        }
    }
}
