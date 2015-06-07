using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VMMenu : AbstractViewModel
    {
        /// <summary>
        /// obtient le type de l'écran associé au ViewModelMenu
        /// </summary>
        public VMBrickBreaker.Ecran Ecran
        {
            get
            {
                return VMBrickBreaker.Ecran.Menu;
            }
        }

        /// <summary>
        /// Modifie l'écran courant de l'application en fonction de l'écran passé en paramètre
        /// </summary>
        /// <param name="ecran">Nouvel écran actif</param>
        public void ChangementEcran(VMBrickBreaker.Ecran ecran)
        {
            VMBrickBreaker.GetInstance().EcranCourant = ecran;
        }
    }
}
