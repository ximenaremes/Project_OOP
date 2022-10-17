using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;
using System.Xml;

namespace app1
{
    class ProduseMgr : ProduseAbstractMgr
    {
        public List<Produs> InitListafromXML()
        {
            List<Produs> elem = new List<Produs>();
            int NrElemente = 0;

            XmlDocument doc = new XmlDocument(); //initializam lista dintr-un fisier XML
            doc.Load("D:\\IETI\\Programare\\POO C#\\POS\\app1\\Produse.xml");//incarcam fisierul       
            XmlNodeList lista_noduri = doc.SelectNodes("/produse/Produs"); //selectam nodurile
            foreach (XmlNode nod in lista_noduri)
            {
                //itereaza si selecteaza cimpurile fiecarui nod si
                //informatia continuta in cadrul proprietatii InnerText
                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                string producator = nod["Producator"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                //adaugam in lista produse
                elem.Add(new Produs(NrElemente + 1, nume, codIntern, producator, pret, categorie));
                NrElemente++;
            }
            return elem;

        }


  
      /*  public void WriteProduse()
        {

            Console.WriteLine("\n\nDatele produselor sunt:");
            foreach (Produs s in elemente)
                Console.WriteLine(s.Descriere());

        }*/



    }
}
