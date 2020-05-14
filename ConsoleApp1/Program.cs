using System;
using System.IO;
namespace ConsoleApplication1
{
    class Class1
    {
        static void Main()
        {
            FileStream f = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite);
            f.WriteByte(100);   // в начало файла записывается число 100 

            byte[] x = new byte[10];
            for (byte i = 0; i < 10; ++i)
            {
                x[i] = (byte)(10 - i);
                f.WriteByte(i);     // записывается 10 чисел от 0 до 9 
            }

            f.Write(x, 0, 5);   // записывается 5 элементов массива 

            byte[] у = new byte[20];
            f.Seek(0, SeekOrigin.Begin);    // текущий указатель - на начало 
            f.Read(у, 0, 20);   // чтение из файла в массив 
            foreach (byte elem in у) Console.Write(" " + elem);
            Console.WriteLine();
            f.Seek(5, SeekOrigin.Begin);    // текущий указатель - на 5-й элемент 
            int а = f.ReadByte(); // чтение 5-го элемента 
            Console.WriteLine(а);
            а = f.ReadByte();   // чтение 6-го элемента 
            Console.WriteLine(а);

            Console.WriteLine("Текущая позиция в потоке" + f.Position);
            f.Close();
        }
    }
}

