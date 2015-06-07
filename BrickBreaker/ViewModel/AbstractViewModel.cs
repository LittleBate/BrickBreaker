using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// déclenche l'event OnPropertyChanged pour la propriété Ecran
        /// </summary>
        public void OnEcranChanged()
        {
            OnPropertyChanged("Ecran");
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
