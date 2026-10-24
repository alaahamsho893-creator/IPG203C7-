using System;

namespace RepairSystem
{
    class Program
    {
        static clsRepairCenter center = new clsRepairCenter();

        

        static void Main(string[] args)
        {
            center.OnStateChanged += OnMsg;

            LoadSampleDevices();

            int choice = 1;

            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine(" ___-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                Console.WriteLine("1) Add Fridge");            // إضافة ثلاجة
                Console.WriteLine("2) Add Washer");            // إضافة غسالة
                Console.WriteLine("3) Add AC");                // إضافة مكيف
                Console.WriteLine("4) Add Oven");              // إضافة فرن
                Console.WriteLine("5) Add Microwave");         // إضافة مايكروويف
                Console.WriteLine("6) Show All Devices");      // عرض كل الأجهزة
                Console.WriteLine("7) Show Total Cost");       // عرض التكلفة الكلية
                Console.WriteLine("8) Change Device State");   // تغيير حالة جهاز
                Console.WriteLine("9) Count By State");        // عدّ الأجهزة حسب الحالة
                Console.WriteLine("10) Show Static Total");    // عرض العدد الكلي (الفئة الثابتة)
                Console.WriteLine("0) Exit");                   
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                Console.Write("Your choice: ");               

                string input = Console.ReadLine();
                bool ok = int.TryParse(input, out choice);

                if (ok == false)
                {
                    choice = -1; 
                }

                Console.WriteLine();

                // ننفذ حسب الاختيار
                if (choice == 1)
                {
                    AddFridge();
                }
                else if (choice == 2)
                {
                    AddWasher();
                }
                else if (choice == 3)
                {
                    AddAC();
                }
                else if (choice == 4)
                {
                    AddOven();
                }
                else if (choice == 5)
                {
                    AddMicrowave();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("---- All Devices ----");
                    center.PrintAll();
                }
                else if (choice == 7)
                {
                    Console.WriteLine("---- Total Cost ----");
                    Console.WriteLine("Total = " + center.TotalCost());
                }
                else if (choice == 8)
                {
                    ChangeStateMenu();
                }
                else if (choice == 9)
                {
                    CountMenu();
                }
                else if (choice == 10)
                {
                    Console.WriteLine("---- Static ----");
                    Console.WriteLine("Total devices (static) = " + clsCheck.TotalDevices);
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Bye!");
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again.");
                }

                // نوقف شوي عشان المستخدم يقرأ
                if (choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

         static void OnMsg(string m)
        {
            Console.WriteLine("[EVENT] " + m);
        }




        static void AddFridge()
        {
            Console.WriteLine("---- Add Fridge ----");

            int s = ReadInt("Serial: ");
            if (clsCheck.CheckSerial(s) == false)
            {
                Console.WriteLine("Bad serial!");
                return;
            }

            string b = ReadText("Brand: ");
            double c = ReadDouble("Base cost: ");
            double e = ReadDouble("Extra cost: ");

            clsFridge f = new clsFridge(s, b, c, e);
            center.AddDevice(f);
            Console.WriteLine("Fridge added.");
        }

        static void AddWasher()
        {
            Console.WriteLine("---- Add Washer ----");

            int s = ReadInt("Serial: ");
            if (clsCheck.CheckSerial(s) == false)
            {
                Console.WriteLine("Bad serial!");
                return;
            }

            string b = ReadText("Brand: ");
            double c = ReadDouble("Base cost: ");
            int p = ReadInt("Parts count: ");

            clsWasher w = new clsWasher(s, b, c, p);
            center.AddDevice(w);
            Console.WriteLine("Washer added.");
        }

        static void AddAC()
        {
            Console.WriteLine("---- Add AC ----");

            int s = ReadInt("Serial: ");
            if (clsCheck.CheckSerial(s) == false)
            {
                Console.WriteLine("Bad serial!");
                return;
            }

            string b = ReadText("Brand: ");
            double c = ReadDouble("Base cost: ");
            bool g = ReadBool("Gas fill? (1=yes, 0=no): ");

            clsAC a = new clsAC(s, b, c, g);
            center.AddDevice(a);
            Console.WriteLine("AC added.");
        }

        static void AddOven()
        {
            Console.WriteLine("---- Add Oven ----");

            int s = ReadInt("Serial: ");
            if (clsCheck.CheckSerial(s) == false)
            {
                Console.WriteLine("Bad serial!");
                return;
            }

            string b = ReadText("Brand: ");
            double c = ReadDouble("Base cost: ");
            double h = ReadDouble("Heater price: ");

            clsOven o = new clsOven(s, b, c, h);
            center.AddDevice(o);
            Console.WriteLine("Oven added.");
        }

        static void AddMicrowave()
        {
            Console.WriteLine("---- Add Microwave ----");

            int s = ReadInt("Serial: ");
            if (clsCheck.CheckSerial(s) == false)
            {
                Console.WriteLine("Bad serial!");
                return;
            }

            string b = ReadText("Brand: ");
            double c = ReadDouble("Base cost: ");
            bool m = ReadBool("Magnetron changed? (1=yes, 0=no): ");

            clsMicrowave mw = new clsMicrowave(s, b, c, m);
            center.AddDevice(mw);
            Console.WriteLine("Microwave added.");
        }

        // ============ دوال تغيير الحالة والعد ============

        static void ChangeStateMenu()
        {
            Console.WriteLine("---- Change State ----");

            int i = ReadInt("Device index (0-based): ");
            if (i < 0 || i >= clsCheck.TotalDevices)
            {
                Console.WriteLine("Bad index!");
                return;
            }

            Console.WriteLine("States: Waiting / InRepair / Done / Late");
            string st = ReadText("New state: ");

            center.ChangeState(center.GetDeviceAt(i), st);
            Console.WriteLine("State changed.");
        }

        static void CountMenu()
        {
            Console.WriteLine("---- Count By State ----");

            string st = ReadText("State: ");
            Console.WriteLine("Count = " + center.CountByState(st));
        }

        // ============ دوال مساعدة للقراءة ============

        static int ReadInt(string msg)
        {
            Console.Write(msg);
            string x = Console.ReadLine();
            int v = 0;
            int.TryParse(x, out v);
            return v;
        }

        static double ReadDouble(string msg)
        {
            Console.Write(msg);
            string x = Console.ReadLine();
            double v = 0;
            double.TryParse(x, out v);
            return v;
        }

        static string ReadText(string msg)
        {
            Console.Write(msg);
            string x = Console.ReadLine();
            if (x == null)
            {
                x = "";
            }
            return x;
        }

        static bool ReadBool(string msg)
        {
            Console.Write(msg);
            string x = Console.ReadLine();
            if (x == "1")
            {
                return true;
            }
            return false;
        }

        // ============ أجهزة جاهزة للبداية ============

        static void LoadSampleDevices()
        {
            clsFridge f = new clsFridge(101, "LG", 100, 30);
            center.AddDevice(f);

            clsWasher w = new clsWasher(102, "Samsung", 80, 3);
            center.AddDevice(w);

            clsAC a = new clsAC(103, "Carrier", 120, true);
            center.AddDevice(a);
        }
    }
}