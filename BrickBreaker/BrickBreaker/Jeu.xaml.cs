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
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu : UserControl
    {
        public Jeu()
        {
            InitializeComponent();
        }

        private void Can_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource is Canvas)
            {
                VMGame vmg = DataContext as VMGame;
                vmg.MoveBarre(Mouse.GetPosition((Canvas)e.OriginalSource).X);
            }
        }

        private void Can_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Canvas)
            {
                VMGame vmg = DataContext as VMGame;
                vmg.GameStarted();
            }
        }

        private void Can_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.OriginalSource is Canvas && DataContext != null)
            {
                VMGame vmg = DataContext as VMGame;
                vmg.LargeurCanvas = e.NewSize.Width;
                vmg.HauteurCanvas = e.NewSize.Height;
            }
        }

        private void Can_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is Canvas && DataContext != null)
            {
                Canvas can = sender as Canvas;
                VMGame vmg = DataContext as VMGame;
                vmg.LargeurCanvas = can.RenderSize.Width;
                vmg.HauteurCanvas = can.RenderSize.Height;
            }
        }
    }
}
