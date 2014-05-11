using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;

namespace SoftKeyboard
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);


        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        static void Main(string[] args)
        {
            bool verbose = false;
            if (args.Length == 0 || args[0] == "/?" || args[0] == "?" || args[0] == "-?")
            {
                //System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string longName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string filename = longName.Substring(longName.LastIndexOf('\\')+1);
                Console.WriteLine("usage: "+filename+" <COMPORT> [-v]");
                Console.WriteLine("example: " + filename + " COM3");
                Console.WriteLine("Reference:");
                Console.WriteLine("\tCOMPORT:\t the COM port of your Arduino, can be found in the Arduino IDE under Tools > Serial Port");
                Console.WriteLine("\t-v:\t verbose, will output to Console all received data");
                Console.WriteLine("\n----\nThis is the PC side of the SoftKeyboard project for Arduino. You need to run the relevant code on your Arduino in order for this to have any effect. You can find the Arduino project on github here: https://github.com/MeLight/soft-keyboard.git");
                return;
            }

            if (args.Length > 1 && args[1] == "-v")
                verbose = true;

            SerialPort port = new SerialPort(args[0], 9600);
            try
            {
                port.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Coudn't open SerialPort on " + args[0]);
                Console.WriteLine("Exception as follows: " + e.ToString());
                return;
            }
            
            while (true)
            {
                string message = port.ReadLine().Trim();
                char[] delims = { ' ' };
                string[] data = message.Split(delims);
                if (data[0] == "sk")
                {
                    if (verbose)
                        Console.WriteLine(message);
                    int command = int.Parse(data[1]);
                    byte keyCode = (byte)int.Parse(data[2]);
                    if (command == 1 || command == 3)
                    {
                        keybd_event(keyCode, (byte)MapVirtualKeyEx(keyCode, 0, IntPtr.Zero), KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
                    }

                    if (command == 2 || command == 3)
                    {
                        keybd_event(keyCode, (byte)MapVirtualKeyEx(keyCode, 0, IntPtr.Zero), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
                    }
                }
            }
        }
    }
}
