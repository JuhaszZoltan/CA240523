using System.Net.Http.Headers;
using System.Text;

namespace CA240523
{
    internal class Program
    {
        static void Main()
        {
            List<Kategoria> kategoriak = new();

            using StreamReader sr = new(@"..\..\..\src\titanic.txt", Encoding.UTF8);
            while (!sr.EndOfStream) kategoriak.Add(new(sr.ReadLine()));

            //foreach (var kategoria in kategoriak)
            //{
            //    Console.WriteLine(kategoria);
            //    Console.WriteLine("----------------");
            //}

            Console.WriteLine($"2. feladat: {kategoriak.Count} db");

            int ousz = 0;
            foreach (var k in kategoriak) ousz += k.Utasok;
            Console.WriteLine($"3. feladat: {ousz} fő");

            Console.Write("4. feladat: kulcsszo: ");
            string kulcsszo = Console.ReadLine();

            int index = 0;
            while (index < kategoriak.Count && !kategoriak[index].Nev.Contains(kulcsszo))
                index++;

            if (index < kategoriak.Count)
            {
                Console.WriteLine("\tvan talalat!");
                Console.WriteLine("5. feladat:");
                foreach (var k in kategoriak)
                {
                    if (k.Nev.Contains(kulcsszo))
                        Console.WriteLine($"\t{k.Nev} {k.Utasok} fő");
                }
            }
            else Console.WriteLine("\tnincs találat");

            List<string> meghaladta = new();
            foreach (var k in kategoriak)
                if (k.Eltuntek > k.Utasok * .6f)
                    meghaladta.Add(k.Nev);
            Console.WriteLine("6. feladat:");
            foreach (var kn in meghaladta) Console.WriteLine($"\t{kn}");

            int maxi = 0;
            for (int i = 1; i < kategoriak.Count; i++)
            {
                if (kategoriak[i].Tulelok > kategoriak[maxi].Tulelok)
                {
                    maxi = i;
                }
            }
            Console.WriteLine($"7. feladat: {kategoriak[maxi].Nev}");
        }

        static void FileIras()
        {
            StreamWriter sw = new(
                path: @"c:\\users\juhaszz\desktop\elso.txt",
                append: false,
                encoding: Encoding.UTF8);

            Console.Write("hogy hivnak?: ");
            string nev = Console.ReadLine();

            sw.WriteLine($"Hello, {nev}!");
            sw.WriteLine($"Pi={Math.PI:0.0000}");

            sw.Close();

            Console.WriteLine("file kész!");
        }
        static void FileOlvasas()
        {
            StreamReader sr = new(@"c://users/juhaszz/desktop/elso.txt", Encoding.UTF8);

            float pi = -1;

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                if (sor.ToLower().StartsWith("pi="))
                {
                    string[] v = sor.Split('=');
                    pi = float.Parse(v[1]);
                }
            }

            sr.Close();

            Console.Write("kör sugarának hossza (cm): ");
            int r = int.Parse(Console.ReadLine());

            Console.WriteLine($"kerulete: {2 * r * pi} cm");
            Console.WriteLine($"terulete: {r * r * pi} cm^2");
        }
    }
}
