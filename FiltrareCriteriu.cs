using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace app1
{
    class FiltrareCriteriu : IFiltrare
    {
       
        public IEnumerable<ProdusAbstract> Filtrare(List<ProdusAbstract> elemente, ICriteriu criteriul_de_filtrare)
        {
            //throw new NotImplementedException();

            IEnumerable<ProdusAbstract> interogare_linq = from elem in elemente
                                                          where criteriul_de_filtrare.IsIndeplinit(elem)
                                                          select elem;

            return interogare_linq;
            // criteriul_de_filtrare.IsIndeplinit(elem)

        }
    }
}
