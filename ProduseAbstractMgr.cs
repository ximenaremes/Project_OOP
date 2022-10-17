using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;
using System.Collections;
using System.Xml.Linq;


namespace app1
{
    abstract public class ProduseAbstractMgr
    {
        // public ListaGen<ProdusAbstract> elemente = new ListaGen<ProdusAbstract>();
        // protected int nrElemente;
        public List<ProdusAbstract> packages = new List<ProdusAbstract>();
        public int NrPachete = 0;


        //functie de afisare a elementelor din pachet
        public void Write2Console()
        {
            foreach (Pachet p in packages)
                Console.WriteLine(p.Descriere());

        }
        public void Filtrare()
        {
            FiltrareCriteriu filtrareCriteriu = new FiltrareCriteriu();
            CriteriuCategorie criteriuCategorie = new CriteriuCategorie("Telefoane");
            CriteriuPret criteriuPret = new CriteriuPret(3500);


            Console.WriteLine("\n Elementele filtrate dupa categorie sunt : ");
            foreach (ProdusAbstract p in filtrareCriteriu.Filtrare(packages, criteriuCategorie))
                Console.WriteLine(p.Descriere());

            Console.WriteLine("\n Elementele filtrate dupa pret sunt : ");
            foreach (ProdusAbstract p in filtrareCriteriu.Filtrare(packages, criteriuPret))
                Console.WriteLine(p.Descriere());




        }


    }
}
