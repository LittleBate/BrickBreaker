using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreakerObject;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;

namespace ViewModel
{
    public class VMGame : AbstractViewModel
    {
        public const int NB_LIGNE_GRILLE = 20;
        public const int NB_COLONNE_GRILLE = 20;

        public double largeurBrique
        {
            get
            {
                return LargeurCanvas / NB_COLONNE_GRILLE;
            }
        }

        public double hauteurBrique
        {
            get
            {
                return HauteurCanvas / NB_LIGNE_GRILLE;
            }
        }

        private Thread thread;

        public double LargeurCanvas
        {
            get;
            set;
        }

        public double HauteurCanvas
        {
            get;
            set;
        }

        public VMGame()
        {
            NiveauCourant = Test.TestNiveau();
        }

        private bool GameOn = false;

        /// <summary>
        /// Définit ou Obtient le niveau courant du jeu.
        /// </summary>
        public Niveau NiveauCourant
        {
            get;
            set;
        }

        /// <summary>
        /// obtient le type de l'écran associé au ViewModelGame
        /// </summary>
        public VMBrickBreaker.Ecran Ecran
        {
            get
            {
                return VMBrickBreaker.Ecran.Jeu;
            }
        }

        public void GameStarted()
        {

            if (GameOn == false)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(10);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            GameOn = true;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            thread = new Thread(ActualiserPosition);
            thread.Start();
        }

        private void ActualiserPosition()
        {
            MiseAJourPosition();
            TestCollisionMur();
            TestCollisionBarre();
            TestCollisionBriques();
        }

        private void TestCollisionBarre()
        {
            if (NiveauCourant.Balle.isInBarre(NiveauCourant.Barre))
                ChangerDirectionBalle(1, -1);
        }

        private void TestCollisionBriques()
        {
            List<ACasseBriqueObjet> briquesTouche = NiveauCourant.Briques
                .Where(b => NiveauCourant.Balle.isInBrique(b, largeurBrique, hauteurBrique))
                .ToList();

            if (briquesTouche.Count > 0)
            {
                foreach (var item in briquesTouche)
                {
                    NiveauCourant.CasserBrique(item);
                }
                ChangerDirectionBalle(1, -1);
            }
        }



        private void TestCollisionMur()
        {
            if (NiveauCourant.Balle.PositionX - NiveauCourant.Balle.Diametre / 2 <= 0
                || NiveauCourant.Balle.PositionX + NiveauCourant.Balle.Diametre / 2 >= LargeurCanvas)
            {
                ChangerDirectionBalle(-1, 1);
            }
            if (NiveauCourant.Balle.PositionY + NiveauCourant.Balle.Diametre / 2 >= HauteurCanvas)
            {
                ChangerDirectionBalle(1, -1);
            }
            else
            {

            }
        }

        private void ChangerDirectionBalle(int directionAxeX, int directionAxeY)
        {
            NiveauCourant.Balle.SpeedX = NiveauCourant.Balle.SpeedX * directionAxeX;
            NiveauCourant.Balle.SpeedY = NiveauCourant.Balle.SpeedY * directionAxeY;
        }

        private void MiseAJourPosition()
        {
            NiveauCourant.Balle.PositionX += NiveauCourant.Balle.SpeedX;
            NiveauCourant.Balle.PositionY += NiveauCourant.Balle.SpeedY;
        }

        public void GameOff()
        {
            GameOn = false;
        }



        public void MoveBarre(double positionX)
        {
            NiveauCourant.Barre.PositionX = Convert.ToInt32(positionX - NiveauCourant.Barre.Longueur / 2);
            if (!GameOn)
                NiveauCourant.Balle.PositionX = NiveauCourant.Barre.PositionX + (NiveauCourant.Barre.Longueur - NiveauCourant.Balle.Diametre) / 2;

        }
    }
}
