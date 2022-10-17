using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace app1
{
    class Program
    {
        static void Main(string[] args) {
           
            PacheteMgr mgrPachet = new PacheteMgr();

            List<Pachet> Packages = new List<Pachet>();
            int i;
                
                mgrPachet.ReadPachet();
                Console.WriteLine("--------- MENIU-----------");
                Console.WriteLine("\n 1.Afisarea fisierul XML ");
                Console.WriteLine("\n 2.Afisarea fisierului XML dupa deselarizare");
            do
            {
                Console.WriteLine("\nAlegeti o optiune : ");
                i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("\t\t\t\t\tAfisarea din fisierul XML:");
                        Console.WriteLine();
                        foreach (Pachet p in mgrPachet.packages)
                        {
                            p.AltaDescriere();
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        mgrPachet.save2XML("Pachete_serializate");
                        Packages = PacheteMgr.loadFromXML("Pachete_serializate"); //în Packages salvăm ceea ce ne returnează funcția loadFromXML
                        Console.WriteLine("\t\t\t\t\tAfisare in urma procesului de deserializare:");
                        Console.WriteLine();
                        foreach (Pachet p in Packages)
                        {
                            p.AltaDescriere();
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine();
                        }
                        break;

                    default:
                        Console.WriteLine("\n Optiune invalida!");
                        break;
                }
            } while (i != 0);
            Console.ReadKey();
        }
      
    }
}
