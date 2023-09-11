using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Feladvany
{
    public string Kezdo { get; private set; }
    public int Meret { get; private set; }

    public Feladvany(string sor)
    {
        Kezdo = sor;
        Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
    }

    public void Kirajzol()
    {
        for (int i = 0; i < Kezdo.Length; i++)
        {
            if (Kezdo[i] == '0')
            {
                Console.Write(".");
            }
            else
            {
                Console.Write(Kezdo[i]);
            }
            if (i % Meret == Meret - 1)
            {
                Console.WriteLine();
            }
        }
    }

    public double Kitoltottseg()
    {
        string sor = Kezdo;
        int db = sor.Split('0').Length - 1;

        double eredm = (double)db / (double)Meret;
        return eredm*10;
    }
}
