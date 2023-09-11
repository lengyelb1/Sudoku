using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("feladvanyok.txt");
            List<Feladvany> feladvanyok = new List<Feladvany>();

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                feladvanyok.Add(new Feladvany(sor));
            }

            Console.WriteLine($"3. feladat: Beolvasva {feladvanyok.Count} feladvány");

            bool a = true;
            int be = 0;
            while (a) {
                Console.Write("4. feladat: kérem a feladvány méretét [4..9]: ");
                be = int.Parse(Console.ReadLine());
                if (be <=9 && be >= 4)
                {
                    a = false;
                }
            }
            Feladvany feladvany = new Feladvany("");
            foreach (Feladvany item in feladvanyok)
            {
                if (item.Meret == be)
                {
                    feladvany = item;
                    Console.WriteLine("5. feladat: A kiválasztott feladvány:");
                    Console.WriteLine(item.Kezdo);
                    break;
                }
            }
            Console.WriteLine($"6. feladat: A feladvány kitöltöttsége: {feladvany.Kitoltottseg()}%");

            Console.WriteLine("7. feladat: A feladvány kirajzolva:");
            feladvany.Kirajzol();

            List<string>kell = new List<string>();
            int db = 0;
            foreach (Feladvany item in feladvanyok)
            {
                if (item.Meret == be)
                {
                    kell.Add(item.Kezdo);
                    db++;
                }
            }
            
            StreamWriter sw = new StreamWriter($"sudoku{be}.txt");
            foreach (string item in kell)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            Console.WriteLine($"8. feladat: sudoku{be}.txt állomány {db} darabfeladvánnyal létrehozva");
            Console.ReadKey();
        } 
    }
}
