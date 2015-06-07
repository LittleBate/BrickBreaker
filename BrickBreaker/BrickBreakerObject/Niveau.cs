using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BrickBreakerObject
{
    public class Niveau : INotifyPropertyChanged
    {
        public Niveau(IEnumerable<Brique> briques)
        {
            _Briques.AddRange(briques); 
        }

        public Balles Balle
        {
            get;
            set;
        }

        public Barre Barre
        {
            get;
            set;
        }

        private List<Score> _Scores = new List<Score>();
        /// <summary>
        /// Obtient la liste des scores de ce niveau
        /// </summary>
        public ReadOnlyCollection<Score> Scores
        {
            get
            {
                return new ReadOnlyCollection<Score>(_Scores);
            }
        }

        /// <summary>
        /// Ajoute un nouveau score à la liste des top scores de ce niveau.
        /// Retourne true si le score est ajouté à la liste
        /// Si la top liste compte déjà 10 score on supprime le dernier avant d'ajouter le nouveau score.
        /// </summary>
        /// <param name="score"></param>
        /// <rereturns></rereturns>
        public bool AddNewScore(Score score)
        {
            if (score.Points < _Scores.OrderBy(s => s.Points).First().Points)
                return false;
            if (_Scores.Count >= 10)
                _Scores.Remove(_Scores.OrderBy(s => s.Points).First());
            _Scores.Add(score);
            return true;
        }

        private List<Brique> _Briques = new List<Brique>();
        /// <summary>
        /// Obtient la liste des briques qui composent le niveau.
        /// </summary>
        public ObservableCollection<ACasseBriqueObjet> Briques
        {
            get
            {
                return new ObservableCollection<ACasseBriqueObjet>(_Briques);
            }
        }

        public void CasserBrique(ACasseBriqueObjet brique)
        {
            _Briques.Remove(brique as Brique);
            OnPropertyChanged("Briques");   
        }

        public void AddBrique(int positionX, int positionY)
        {
            _Briques.Add(new Brique(positionX, positionY));
        }

        # region OnPropertyChanged

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        # endregion
    }

    public class Test
    {
        public static Niveau TestNiveau()
        {
            Niveau niveau = new Niveau(new List<Brique>()) 
            {
                Barre = new Barre(10, 10, 50),
                Balle = new Balles(10, 35, 20)
            };

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    niveau.AddBrique(i, j);
                }
            }

            return niveau;
        }
    }
}
