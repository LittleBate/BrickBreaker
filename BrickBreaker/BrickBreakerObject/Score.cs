using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerObject
{
    public struct Score
    {
        /// <summary>
        /// Définit ou obtient le titre du score.
        /// permet de savoir si le score correspond à un niveau ou un mode de jeu.
        /// On sait avec précision quel mode de jeu ou quel niveau est concerné par le score.
        /// </summary>
        public string TitreScore;

        /// <summary>
        /// Définit ou obtient le nombre de point.
        /// </summary>
        public int Points;

        /// <summary>
        /// Définit ou obtient le pseudo du joueur ayant obtenut ce score.
        /// </summary>
        public string Pseudo;

        /// <summary>
        /// Constructeur de score
        /// </summary>
        /// <param name="titre">titre du score</param>
        /// <param name="pseudo">pseudo du joueur qui a fait le score</param>
        /// <param name="score">score obtenut par le joueur</param>
        public Score(string titre, string pseudo, int score)
        {
            Pseudo = pseudo;
            Points = score;
            TitreScore = titre;
        }
    }
}
