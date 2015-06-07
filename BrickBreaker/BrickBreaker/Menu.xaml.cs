using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace BrickBreaker
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            VMMenu vm = DataContext as VMMenu;
            vm.ChangementEcran(VMBrickBreaker.Ecran.Editeur);
        }

        private void Button_Jouer_Click(object sender, RoutedEventArgs e)
        {
            VMMenu vm = DataContext as VMMenu;
            vm.ChangementEcran(VMBrickBreaker.Ecran.Jeu);
        }
    }
}
