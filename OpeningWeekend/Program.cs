using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpeningWeekend
{
    class Program
    {
        static List<Film> Filmek = new List<Film>();
        static string fejlec = "";
        static void Beolvasas()
        {
            StreamReader olvas = new StreamReader("nyitohetvege.txt");
            fejlec = olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                string[] a = olvas.ReadLine().Split(';');
                Filmek.Add(new Film(a[0], a[1], DateTime.Parse(a[2]), a[3], int.Parse(a[4]), int.Parse(a[5])));
            }
            olvas.Close();
        }

        static void Harmadik()
        {
            Console.WriteLine($"3. feladat: Filmek száma az állományban: {Filmek.Count}");
        }

        static void Negyedik()
        {
            double osszeg = 0;
            foreach (var i in Filmek)
            {
                if (i.Forgalmazo.Equals("UIP"))
                {
                    osszeg += i.Bevetel;
                }
            }
            Console.WriteLine($"4. feladat: UIP Duna Film forgalmazó 1. hetes bevételének összege:" +
                $" {osszeg:N0} Ft");
        }

        static void Otodik()
        {
            Console.WriteLine("5. feladat: Legtöbb látogató az első héten:");
            int maxIndex = 0;
            int max = 0;
            for (int i = 0; i < Filmek.Count; i++)
            {
                if (max<Filmek[i].Latogato)
                {
                    max = Filmek[i].Latogato;
                    maxIndex = i;
                }
            }
            Console.WriteLine($"\tEredeti cím: {Filmek[maxIndex].EredetiCim}\n\tMagyar cím: {Filmek[maxIndex].MagyarCim}\n\tForgalmazo: {Filmek[maxIndex].Forgalmazo}\n\tBevétel az első héten: {Filmek[maxIndex].Bevetel:N0} Ft\n\tLátogatók: {Filmek[maxIndex].Latogato} fő");
        }

        static void Hatodik()
        {
            /*bool változó volt=false;
             * vegig a filmeken, ha eredeti és mcim jó akkor volt=true
             * ha volt akkor Volt || Nem volt ilyen film!*/
            bool volt = false;
            foreach (var i in Filmek)
            {
                if (WvelKezdodik(i.EredetiCim) && WvelKezdodik(i.MagyarCim))
                {
                    volt = true;
                }
            }
            if (volt)
            {
                Console.WriteLine("6. feladat: Volt ilyen film");
            }
            else
            {
                Console.WriteLine("6. feladat: Nem volt ilyen film");
            }
        }

        static bool WvelKezdodik(string cim)
        {
            cim = cim.ToUpper();
            string[] szavak = cim.Split(' ');
            /*végig a szavak tömbön
             * ha bármelyik szó nem "W"-->false
             * végigértünk a szavak tömbön akkor jó-- return true*/
            for (int i = 0; i < szavak.Length; i++)
            {
                if (!szavak[i].StartsWith("W"))
                {
                    return false;
                }
            }
            return true;
        }

        static void Hetedik()
        {
            Dictionary<string, int> ForgalmazokFilmei = new Dictionary<string, int>();
            foreach (var i in Filmek)
            {
                if (!ForgalmazokFilmei.ContainsKey(i.Forgalmazo))
                {
                    ForgalmazokFilmei.Add(i.Forgalmazo, 1);
                }
                else
                {
                    ForgalmazokFilmei[i.Forgalmazo]++;
                }               
            }
            StreamWriter iro = new StreamWriter("stat.csv");
            iro.WriteLine("forgalazo;filmekszama");
            foreach (var i in ForgalmazokFilmei)
            {
                if (i.Value > 1)
                {
                    iro.WriteLine(i.Key+";"+i.Value);
                }
            }
            iro.Close();
        }

        static void Nyolcadik()
        {
            //leghosszabb, InterCom
            //for (int i = 0; i < Filmek.Count; i++)
            //{
            //    List<int> napokSzama = new List<int>();
            //    for (int j = i + 1; j < Filmek.Count; j++)
            //    {
            //        if (Filmek[i].Forgalmazo.Equals("InterCom") && Filmek[j].Forgalmazo.Equals("InterCom"))
            //        {
            //            napokSzama.Add(Filmek[i].Bemutato.Day - Filmek[j].Bemutato.Day);
            //        }
            //    }
            //    Console.WriteLine($"8. feladat: A leghosszabb időszak két InterCom film között: {napokSzama.Max()}");
            //}

            bool elso = true;
            DateTime kezdes = new DateTime();
            DateTime vege = new DateTime();
            int maxNap = 0;
            foreach (var i in Filmek)
            {
                if (i.Forgalmazo.Equals("InterCom"))
                {
                    if (elso)
                    {
                        kezdes = i.Bemutato;
                        elso = false;
                    }
                    else
                    {
                        vege = i.Bemutato;
                        int nap = (vege - kezdes).Days;
                        if (maxNap < nap) 
                        {
                            maxNap = nap;
                        }
                        kezdes = vege;
                    }
                }
            }
            Console.WriteLine($"8. feladat: A leghosszabb időszak két InterCom film között: {maxNap} nap");
        }
        static void Main(string[] args)
        {
            Beolvasas();        
            Harmadik();
            Negyedik();
            Otodik();
            Hatodik();
            Hetedik();
            Nyolcadik();
            Console.ReadKey();
        }
    }
}
