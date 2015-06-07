using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    /// <summary>
    /// ViewModel de l'application BrickBreaker en général.
    /// Singleton
    /// </summary>
    public class VMBrickBreaker : AbstractViewModel
    {
        /// <summary>
        /// Instace unique de la classe VMBrickBreaker
        /// </summary>
        private static VMBrickBreaker instance;

        /// <summary>
        /// Constructeur par défaut et privé
        /// </summary>
        private VMBrickBreaker()
        {
            EcranCourant = Ecran.Menu;
            VMEditeur = new VMEditeur();
            VMMenu = new VMMenu();
            VMGame = new VMGame();
        }

        /// <summary>
        /// Obtient l'instance unique de la classe VMBrickBreaker
        /// </summary>
        /// <returns>L'instance unique de la classe</returns>
        public static VMBrickBreaker GetInstance()
        {
            if (instance == null)
                instance = new VMBrickBreaker();
            return instance;
        }

        /// <summary>
        /// Définit ou obtient le ViewModel de l'éditeur de niveau
        /// </summary>
        public VMEditeur VMEditeur
        {
            get;
            set;
        }

        /// <summary>
        /// Définit ou obtient le ViewModel de l'écran de jeu
        /// </summary>
        public VMGame VMGame
        {
            get;
            set;
        }

        /// <summary>
        /// Définit ou obtient le ViewModel de l'écran de menu
        /// </summary>
        public VMMenu VMMenu
        {
            get;
            set;
        }

        private Ecran _EcranCourant;
        /// <summary>
        /// Définit ou obtient l'écran actif de l'application
        /// </summary>
        public Ecran EcranCourant
        {
            get
            {
                return _EcranCourant;
            }
            set
            {
                if (value == _EcranCourant)
                    return;
                _EcranCourant = value;
                OnPropertyChanged("EcranCourant");
                VMEditeur.OnEcranChanged();
                VMMenu.OnEcranChanged();
                VMGame.OnEcranChanged();
            }
        }

        /// <summary>
        /// Enumération de tous les écrans qui peuvent être affiché dans l'application
        /// </summary>
        public enum Ecran
        {
            Menu,
            Jeu,
            Editeur
        }
    }
}
