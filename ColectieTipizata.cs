using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace app1
{
    class ColectieTipizata : System.Collections.CollectionBase {
        public ProdusAbstract this[int item]
        {
            get
            {
                return ((ProdusAbstract)List[item]);
            }
            set
            {
                List[item] = value;
            }
        }
        public int Adaugare(ProdusAbstract value)
        {
            return (List.Add(value));
        }
    }
}
