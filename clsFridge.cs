using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 
namespace RepairSystem
{
    // الثلاجة
    public class clsFridge : clsDeviceBase
    {
        private double _extra;   // مصاري زيادة للتبريد

        public double Extra
        {
            get { return _extra; }
            set { _extra = value; }
        }

        // كونستراكتور
        public clsFridge(int s, string b, double c, double e) : base(s, b, c)
        {
            _extra = e;
        }

        // حساب التكلفة بطريقة الثلاجة
        public override double CalcCost()
        {
            return BaseCost + _extra + 20;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Fridge -> " + ShowInfo() + " | Cost: " + CalcCost());
        }
    }
}