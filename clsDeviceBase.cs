using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 
namespace RepairSystem
{
    // فئة مجردة بتطبق الواجهة وفيها خصائص مشتركة
    public abstract class clsDeviceBase : clsDeviceInterface
    {
         private int _serial;
        private string _brand;
        private string _state;
        private double _baseCost;

        // خصائص  
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public double BaseCost
        {
            get { return _baseCost; }
            set { _baseCost = value; }
        }

         public int Serial
        {
            get { return _serial; }
        }

        // كونستراكتور
        public clsDeviceBase(int s, string b, double c)
        {
            _serial = s;
            _brand = b;
            _baseCost = c;
            _state = "Waiting";
        }

        // دالة مجردة لازم كل جهاز يعيد تعريفها
        public abstract double CalcCost();

        // دوال مشتركة
        public virtual string ShowInfo()
        {
            return "Serial: " + _serial + " | Brand: " + _brand + " | State: " + _state;
        }

        public virtual string GetState()
        {
            return _state;
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine(ShowInfo());
        }
    }
}