using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace RepairSystem
{
    // فئة ثابتة للتحقق من البيانات
    public static class clsCheck
    {
         private static int _totalDevices = 0;

        public static int TotalDevices
        {
            get { return _totalDevices; }
        }

        // دالة تزيد العداد
        public static void AddDevice()
        {
            _totalDevices = _totalDevices + 1;
        }

         public static bool CheckSerial(int s)
        {
            if (s > 0)
            {
                return true;
            }
            return false;
        }

         public static bool CheckDate(DateTime d)
        {
            if (d <= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        // التحقق من الاسم  مش فاضي 
        public static bool CheckText(string t)
        {
            if (t != null && t.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}