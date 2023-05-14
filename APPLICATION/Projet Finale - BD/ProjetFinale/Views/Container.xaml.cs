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

namespace ProjetFinale.Views
{
    /// <summary>
    /// Logique d'interaction pour Container.xaml
    /// </summary>
    public partial class Container : Window
    {
        int cpt_nav = 0;

        public Container()
        {
            InitializeComponent();
            frame.Navigate(new Home());
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            string title = (frame.Content as Page).Title;
            cpt_nav++;

            PageTitle.Content = title;
        }

        private void Characters_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new CharactersList());
        }

        private void Objects_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ObjectsList());
        }

        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AbilitiesList());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Home());
        }
    }
}
