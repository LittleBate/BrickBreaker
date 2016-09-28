using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.ComponentModel;

namespace BrickBreakerObject
{
    public class Balles : ACasseBriqueObjet
    {
        public Balles(int diametre, int positionX, int positionY)
        {
            Diametre = diametre;
            PositionX = positionX;
            PositionY = positionY;
            SpeedX = 3;
            SpeedY = 3;
        }




        private int _Diametre;
        /// <summary>
        /// Définit ou obtient le diametre de la balle
        /// </summary>
        public int Diametre
        {
            get { return _Diametre; }
            set { _Diametre = value; }
        }

        public int SpeedY
        {
            get;
            set;
        }

        public int SpeedX
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient une liste de points qui forment le périmètre de la balle
        /// </summary>
        public IEnumerable<Point> Points
        {
            get
            {
                List<Point> points = new List<Point>();
                int rayon = Diametre / 2;
                Point point;
                for (int i = 0; i < 8; i++)
                {
                    point = new Point((int)Math.Round(PositionX + rayon * Math.Sin(i * 45)),
                        (Diametre + (int)Math.Round(PositionY - rayon * Math.Cos(i * 45))));
                    points.Add(point);
                }
                return points;
            }
        }


        public bool isInBrique(ACasseBriqueObjet brique, double largeurBrique, double hauteurBrique)
        {
            return Points.Where(p => p.X >= largeurBrique * brique.PositionX
                && p.X <= largeurBrique * (brique.PositionX + 1)
                && p.Y >= hauteurBrique * (19 - (brique.PositionY + 1))
                && p.Y <= hauteurBrique * (19 - brique.PositionY))
                .Count() > 0;
        }

        public bool isInBarre(Barre barre)
        {
            return Points.Where(p => p.X >= barre.PositionX
                && p.X <= barre.PositionX + barre.Longueur
                && p.Y <= barre.PositionY + 10
                && p.Y >= barre.PositionY)
                .Count() > 0;
        }
    }
}
