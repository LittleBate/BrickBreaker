using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ViewModel;
using System.Windows;

namespace Converter
{
    /// <summary>
    /// Si l'écran actif dans le ViewModel correspond à l'écran passé en paramètre alors on retourne visible.
    /// Sinon on retourne collapsed
    /// </summary>
    [System.Windows.Data.ValueConversion(typeof(VMBrickBreaker.Ecran), typeof(Visibility))]
    public class EcranToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VMBrickBreaker.Ecran ecran = (VMBrickBreaker.Ecran)value;
            if (VMBrickBreaker.GetInstance().EcranCourant != ecran)
                return Visibility.Hidden;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
