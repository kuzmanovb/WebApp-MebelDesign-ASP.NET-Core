using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var proba = new FileStream(@"..\..\..\Text.txt", FileMode.Open);
            //var proba2 = new FileStream(@"..\..\..\OutputText.txt",FileMode.Open ,FileAccess.ReadWrite);



            //using (proba)
            //{
            //    proba.Write(bytes,0, bytes.Length);
            //}


            var proba = File.ReadAllLines(@"..\..\..\Text.txt");

            File.WriteAllLines(@"..\..\..\OutputText.txt", proba);
            
            
            
            
            
            //var readText = new StreamReader(@"..\..\..\Text.txt");

            //using (readText)
            //{

            //    var curentLine = readText.ReadLine();

            //    using var writeText = new StreamWriter(@"..\..\..\OutputText.txt");
            //    var count = 1;

            //    while (curentLine != null)
            //    {
            //        writeText.WriteLine($"{count}. {curentLine}");
            //        count++;
            //        curentLine = readText.ReadLine();
            //    }

            //}

        }
    }
}
