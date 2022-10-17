using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace app1
{
    class CriteriuPret : ICriteriu
    {
        int pret;

        public CriteriuPret(int pret) {
            this.pret = pret;
        }

        public int Pret { get => pret; set => pret = value; }

        public bool IsIndeplinit(ProdusAbstract elem)
        {
            if (elem.Pret == pret)
            {
                return false;
            }
            return true;
        }
        
    }
}
