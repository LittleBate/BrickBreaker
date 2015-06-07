using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerObject
{
    public abstract class ACasseBriqueObjet : INotifyPropertyChanged
    {
        private int _PositionX;
        /// <summary>
        /// Définit ou Obtient la position de l'objet sur l'axe horizontale
        /// </summary>
        public int PositionX
        {
            set
            {
                if (_PositionX == value)
                    return;
                _PositionX = value;
                OnPropertyChanged("PositionX");
            }
            get
            {
                return _PositionX;
            }
        }

        private int _PositionY;
        /// <summary>
        /// Définit ou obtient la position de l'objet sur l'axe verticale
        /// </summary>
        public int PositionY
        {
            get { return _PositionY; }
            set
            {
                if (_PositionY == value)
                    return;
                _PositionY = value;
                OnPropertyChanged("PositionY");
            }
        }

        private ObjectType _Type;
        /// <summary>
        /// Définit ou obtient le type de l'objet
        /// </summary>
        public ObjectType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        
        /// <summary>
        /// Enumération des différents types que peuvent avoir les objets du casse brique.
        /// Permet de définir les bonus qui y sont lié.
        /// </summary>
        public enum ObjectType
        {
            normal
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
}
