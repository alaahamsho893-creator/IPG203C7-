using System;
using System.Collections.Generic;

namespace RepairSystem
{
    // الفئة الرئيسية يلي فيها القائمة + التفويض + الحدث
    public class clsRepairCenter
    {
        public delegate void StateChangedHandler(string msg);

        public event StateChangedHandler OnStateChanged;


         public clsDeviceBase GetDeviceAt(int i)
        {
            return _devices[i];
        }

        // قائمة الأجهزة 
        private List<clsDeviceBase> _devices = new List<clsDeviceBase>();

        // دالة تضيف جهاز
        public void AddDevice(clsDeviceBase d)
        {
            _devices.Add(d);
            clsCheck.AddDevice();
        }

        // دالة تطبع كل الأجهزة  
        public void PrintAll()
        {
            Console.WriteLine("---- All Devices ----");
            for (int i = 0; i < _devices.Count; i++)
            {
                _devices[i].PrintDetails();
            }
        }
         
        public double TotalCost()
        {
            double sum = 0;
            for (int i = 0; i < _devices.Count; i++)
            {
                sum = sum + _devices[i].CalcCost();
            }
            return sum;
        }

        // دالة تغير حالة جهاز وتطلق الحدث
        public void ChangeState(clsDeviceBase d, string newState)
        {
            d.State = newState;

            if (newState == "Done")
            {
                if (OnStateChanged != null)
                {
                    OnStateChanged("الجهاز " + d.Serial + " خلص تصليحو");
                }
            }
            else if (newState == "Late")
            {
                if (OnStateChanged != null)
                {
                    OnStateChanged("الجهاز " + d.Serial + " تأخر تسليمو");
                }
            }
        }

        // دالة ترجع عدد الأجهزة بحالة معينة
        public int CountByState(string st)
        {
            int c = 0;
            for (int i = 0; i < _devices.Count; i++)
            {
                if (_devices[i].GetState() == st)
                {
                    c = c + 1;
                }
            }
            return c;
        }
    }
}