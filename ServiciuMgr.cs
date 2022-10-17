using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;
using System.Xml;

namespace app1
{
    class ServiciuMgr : ProduseAbstractMgr
    {
        public List<Serviciu>InitListafromXML()
        {
            List<Serviciu> elem = new List<Serviciu>();
            int NrElemente = 0;

            XmlDocument doc = new XmlDocument(); //initializam lista din fisier XML

            //incarcarea fisierului

            doc.Load("D:\\IETI\\Programare\\POO C#\\POS\\app1\\Servicii.xml"); //calea spre fisier

            XmlNodeList lista_noduri = doc.SelectNodes("/sercivii/Serviciu"); //selecteaza nodurile
            foreach (XmlNode nod in lista_noduri)
            {
                //itereaza si selecteaza simpurile fiecarui nod si
                //informatia continuta in cadrul proprietatii InnerText

                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                string producator = nod["Producator"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;
                //adauga in lista produse

                elem.Add(new Serviciu(NrElemente + 1, nume, codIntern, pret, categorie));
                NrElemente++;
            }
            return elem;

        }



    }
    }
