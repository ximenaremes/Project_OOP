using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace app1
{
    class PacheteMgr : ProduseAbstractMgr
    {
        public void InitListafromXML()
        {
            XmlDocument doc = new XmlDocument(); //initializam lista dintr-un fisier XML
            doc.Load("D:\\IETI\\Programare\\POO C#\\POS\\app1\\Pachet.xml");//incarcam fisierul      
            XmlNodeList lista_noduri = doc.SelectNodes("/pachete/Pachet"); //selectam nodurile
            foreach (XmlNode nod in lista_noduri)
            {
                //itereaza si selecteaza cimpurile fiecarui nod si
                //informatia continuta in cadrul proprietatii InnerText
                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                //adauga in lista pachetele
                packages.Add(new Pachet(NrPachete + 1, nume, codIntern, pret, categorie));
                NrPachete++;
            }
        }

        public void ReadPachet()
        {
            InitListafromXML();
            ProduseMgr Produse = new ProduseMgr();
            ServiciuMgr Servicii = new ServiciuMgr();

            List<Produs> prod = Produse.InitListafromXML();
            List<Serviciu> serv = Servicii.InitListafromXML();

            foreach (Pachet pachet in packages)
            {
                foreach (Produs item in prod)
                {
                    if (item.canAddToPackage(pachet))
                    {
                        pachet.Add_elemente(item);
                    }
                }

                foreach (Serviciu item in serv)
                {
                    if (item.canAddToPackage(pachet))
                    {
                        pachet.Add_elemente(item);
                    }
                }
            }
           
        }
        public void SortarePret() {
            IEnumerable<ProdusAbstract> interogare =
                from pachet in packages
                orderby pachet.Pret descending
                select pachet;
            Console.WriteLine("Pachetele ordonate in functie de pret sunt: ");

            foreach (Pachet pachet in interogare) {
                Console.WriteLine("Pretul pachetului " + pachet.Id + " este " + pachet.totalPret + " lei  ");
            }

        }
        //metoda pentru serializarea XML
        public void save2XML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[3];
            prodAbstractTypes[0] = typeof(Serviciu); //de tip serviciu
            prodAbstractTypes[1] = typeof(Produs);   //de tip produs
            prodAbstractTypes[2] = typeof(Pachet);  //de tip pachet
            XmlSerializer xs = new XmlSerializer(typeof(List<Pachet>), prodAbstractTypes); //clasa  XmlSerializer realizeaza serializarea si deserializarea obiectelor
            StreamWriter sw = new StreamWriter(fileName + ".xml"); //clasa StreamWriter realizeaza scrierea datelor
            xs.Serialize(sw, this.packages);
            sw.Close();
        }

        //metoda pentru deserializare XML
        public static List<Pachet> loadFromXML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[3];
            prodAbstractTypes[0] = typeof(Serviciu); //de tip serviciu
            prodAbstractTypes[1] = typeof(Produs);   //de tip produs
            prodAbstractTypes[2] = typeof(Pachet);  //de tip pachet
            XmlSerializer xs = new XmlSerializer(typeof(List<Pachet>), prodAbstractTypes); //clasa  XmlSerializer realizeaza serializarea si deserializarea obiectelor
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);//clasa care deschide si inchide fisierele
            XmlReader reader = new XmlTextReader(fs); //ofera acces la citirea datelor dintr-un fisier XML
            List<Pachet> ListaElemente = (List<Pachet>)xs.Deserialize(reader);
            fs.Close();
            return ListaElemente;
        }




    }
}
