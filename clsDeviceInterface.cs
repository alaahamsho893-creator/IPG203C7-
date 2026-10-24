using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RepairSystem
{
     public interface clsDeviceInterface
    {
        string ShowInfo();        // بترجع معلومات الجهاز
        double CalcCost();        // بتحسب تكلفة التصليح
        string GetState();        // بترجع حالة الجهاز
        void PrintDetails();      // بتطبع التفاصيل
    }
}