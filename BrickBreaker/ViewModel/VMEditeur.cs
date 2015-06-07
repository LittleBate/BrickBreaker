using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VMEditeur : AbstractViewModel
    {
        /// <summary>
        /// obtient le type de l'écran associé au ViewModelEditeur
        /// </summary>
        public VMBrickBreaker.Ecran Ecran
        {
            get
            {
                return VMBrickBreaker.Ecran.Editeur;
            }
        }
    }
}
