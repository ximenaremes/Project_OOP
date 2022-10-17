using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    class CriteriuCategorie: ICriteriu
    {
        string categorie;
        public CriteriuCategorie(string categorie) {
            this.categorie = categorie;
        }
        public string Categorie { get => categorie; set => categorie = value; }

        public bool IsIndeplinit(ProdusAbstract elem) {
            if (elem.Categorie == categorie) {
                return true;
            }
            return false;
        }
    }
}
