using System;

namespace DSP840
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите COM-порт, например COM4:");
            var serialPortName = Console.ReadLine();
            var dsp840 = new DSP840Client(serialPortName);
            dsp840.Open();
            dsp840.SetRussia();
            dsp840.ClearScreen();
            dsp840.Write("Иванов Иван Иванович\n234 р. 00 коп.");
            dsp840.Close();

            Console.Beep();
            Console.ReadLine();
        }
    }
}
