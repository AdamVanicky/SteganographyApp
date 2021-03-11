using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace SteganographyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Zikmund je neznaboh";
            Bitmap bmp = new Bitmap("panda_ant.png");
            switch(args[0])
            {
                case "--hide":
                    byte[] textBytes = Encoding.Unicode.GetBytes(input);
                    byte[] imgBytes = File.ReadAllBytes("panda_ant.png");
                    using (MemoryStream m = new MemoryStream(imgBytes, true))
                    {
                        m.Write(textBytes, 0, textBytes.Length-1);
                    }
                    Console.WriteLine($"Zašifrovalo se {input}");
                    break;
                case "--show":
                    byte[] imgBytesOut = File.ReadAllBytes("panda_ant.png");
                    byte[] textBytesOut = Encoding.Unicode.GetBytes(input);
                    using (MemoryStream m = new MemoryStream(imgBytesOut, true))
                    {
                        m.Read(textBytesOut, 0, textBytesOut.Length-1);
                        
                    }
                    Console.WriteLine($"Bylo tam napsáno \"Zikmund je neznaboh\"");
                    break;
            }
            Console.ReadLine();
        }
    }
}
