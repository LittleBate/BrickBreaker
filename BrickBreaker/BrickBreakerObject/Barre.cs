using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerObject
{
    public class Barre : ACasseBriqueObjet
    {
        public Barre(int positionX, int positionY, int longueur)
        {
            PositionX = positionX;
            PositionY = positionY;
            Longueur = longueur;
        }

        private int _Longueur;
        /// <summary>
        /// Définit ou obtient la longueur de la barre
        /// </summary>
        public int Longueur
        {
            get { return _Longueur; }
            set { _Longueur = value; }
        }

    }
}
